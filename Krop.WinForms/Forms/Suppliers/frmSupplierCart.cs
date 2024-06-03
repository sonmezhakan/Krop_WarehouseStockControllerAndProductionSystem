using Krop.Common.Helpers.WebApiRequests.Suppliers;
using Krop.DTO.Dtos.Suppliers;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.Suppliers
{
    public partial class frmSupplierCart : Form
    {
       
        public Guid Id;
        private readonly ISupplierRequest _supplierRequest;

        public frmSupplierCart(ISupplierRequest supplierRequest)
        {
            InitializeComponent();
            _supplierRequest = supplierRequest;
        }

        private void frmSupplierCart_Load(object sender, EventArgs e)
        {
            SupplierList();
            txtPhoneNumber.MaxLength = 11;
            if (cmbBoxSupplierSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxSupplierSelect.SelectedValue = Id;
        }
        private async void SupplierList()
        {
            HttpResponseMessage response = await _supplierRequest.GetAllComboBoxAsync();
            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetSupplierComboBoxDTO>(response).Data;

            cmbBoxSupplierSelect.DataSource = null;

            cmbBoxSupplierSelect.DisplayMember = "CompanyName";
            cmbBoxSupplierSelect.ValueMember = "Id";

            cmbBoxSupplierSelect.SelectedIndexChanged -= CmbBoxSupplierSelect_SelectedIndexChanged;
            cmbBoxSupplierSelect.DataSource = result;
            cmbBoxSupplierSelect.SelectedIndex = -1;
            cmbBoxSupplierSelect.SelectedIndexChanged += CmbBoxSupplierSelect_SelectedIndexChanged;
        }

        private async void CmbBoxSupplierSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxSupplierSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = await _supplierRequest.GetByIdAsync((Guid)cmbBoxSupplierSelect.SelectedValue);
                if (!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                var result = ResponseController.SuccessDataResponseController<GetSupplierDTO>(response).Data;

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
