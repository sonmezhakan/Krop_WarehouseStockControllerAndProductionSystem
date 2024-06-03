using Krop.Common.Helpers.WebApiRequests.Suppliers;
using Krop.DTO.Dtos.Suppliers;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Suppliers
{
    public partial class frmSupplierUpdate : Form
    {
        public Guid Id;
        private readonly ISupplierRequest _supplierRequest;

        public frmSupplierUpdate(ISupplierRequest supplierRequest)
        {
            InitializeComponent();
            _supplierRequest = supplierRequest;
        }

        private void frmSupplierUpdate_Load(object sender, EventArgs e)
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

                txtCompanyName.Text = result.CompanyName;
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
        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }
        private async void bttnSupplierUpdate_Click(object sender, EventArgs e)
        {
            if (cmbBoxSupplierSelect.SelectedValue is not null)
            {
                if (DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    UpdateSupplierDTO updateSupplierDTO = new UpdateSupplierDTO
                    {
                        Id = (Guid)cmbBoxSupplierSelect.SelectedValue,
                        CompanyName = txtCompanyName.Text,
                        ContactName = txtContactName.Text,
                        ContactTitle = txtContactTitle.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        Email = txtEmail.Text,
                        Country = txtCountry.Text,
                        City = txtCity.Text,
                        Addres = txtAddress.Text,
                        WebSite = txtWebSiteUrl.Text
                    };

                    HttpResponseMessage response = await _supplierRequest.UpdateAsync(updateSupplierDTO);

                    if (!response.IsSuccessStatusCode)
                    {
                        ResponseController.ErrorResponseController(response);
                        return;
                    }

                    SupplierList();
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçin Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
