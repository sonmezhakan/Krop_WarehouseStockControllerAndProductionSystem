using Krop.Business.Features.Suppliers.Dtos;
using Krop.WinForms.HelpersClass.SupplierHelpers;

namespace Krop.WinForms.Suppliers
{
    public partial class frmSupplierCart : Form
    {
        private readonly ISupplierHelper _supplierHelper;
        public Guid Id;

        public frmSupplierCart(ISupplierHelper supplierHelper)
        {
            InitializeComponent();
            _supplierHelper = supplierHelper;
        }

        private async void frmSupplierCart_Load(object sender, EventArgs e)
        {
            await SupplierList();
            txtPhoneNumber.MaxLength = 11;
            if (cmbBoxSupplierSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxSupplierSelect.SelectedValue = Id;
        }
        private async Task SupplierList()
        {
            List<GetSupplierComboBoxDTO> suppliers = await _supplierHelper.GetAllComboBoxAsync();

            cmbBoxSupplierSelect.DataSource = null;

            cmbBoxSupplierSelect.DisplayMember = "CompanyName";
            cmbBoxSupplierSelect.ValueMember = "Id";

            cmbBoxSupplierSelect.SelectedIndexChanged -= CmbBoxSupplierSelect_SelectedIndexChanged;
            cmbBoxSupplierSelect.DataSource = suppliers;
            cmbBoxSupplierSelect.SelectedIndex = -1;
            cmbBoxSupplierSelect.SelectedIndexChanged += CmbBoxSupplierSelect_SelectedIndexChanged;
        }

        private async void CmbBoxSupplierSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxSupplierSelect.SelectedValue is not null)
            {
                var result = await _supplierHelper.GetBySupplierIdAsync((Guid)cmbBoxSupplierSelect.SelectedValue);

                txtContactName.Text = result.ContactName;
                txtContactTitle.Text = result.ContactTitle;
                txtPhoneNumber.Text = result.PhoneNumber;
                txtEmail.Text = result.Email;
                txtCountry.Text = result.Country;
                txtCity.Text = result.City;
                txtAddress.Text = result.Addres;
                txtWebSiteUrl.Text = result.WebSite;
            }
        }
    }
}
