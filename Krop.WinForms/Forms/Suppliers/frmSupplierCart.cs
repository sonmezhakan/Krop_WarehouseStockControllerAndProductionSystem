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

        private void frmSupplierCart_Load(object sender, EventArgs e)
        {
            SupplierList();
            txtPhoneNumber.MaxLength = 11;
            if (cmbBoxSupplierSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxSupplierSelect.SelectedValue = Id;
        }
        private void SupplierList()
        {
            List<GetSupplierComboBoxDTO> result = _supplierHelper.GetAllComboBoxAsync();
            if (result is null)
                return;

            cmbBoxSupplierSelect.DataSource = null;

            cmbBoxSupplierSelect.DisplayMember = "CompanyName";
            cmbBoxSupplierSelect.ValueMember = "Id";

            cmbBoxSupplierSelect.SelectedIndexChanged -= CmbBoxSupplierSelect_SelectedIndexChanged;
            cmbBoxSupplierSelect.DataSource = result;
            cmbBoxSupplierSelect.SelectedIndex = -1;
            cmbBoxSupplierSelect.SelectedIndexChanged += CmbBoxSupplierSelect_SelectedIndexChanged;
        }

        private void CmbBoxSupplierSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxSupplierSelect.SelectedValue is not null)
            {
                var result = _supplierHelper.GetBySupplierIdAsync((Guid)cmbBoxSupplierSelect.SelectedValue);
                if (result is null)
                    return;

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
