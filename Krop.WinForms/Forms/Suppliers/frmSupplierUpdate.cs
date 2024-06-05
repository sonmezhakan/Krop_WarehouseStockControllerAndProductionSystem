using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Suppliers;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Suppliers
{
    public partial class frmSupplierUpdate : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmSupplierUpdate(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmSupplierUpdate_Load(object sender, EventArgs e)
        {
            await supplierComboBoxControl.SupplierList(_webApiService);
            supplierComboBoxControl.SupplierComboBox.SelectedIndexChanged += CmbBoxSupplierSelect_SelectedIndexChanged;
            supplierComboBoxControl.SupplierSelect(Id);
        }
        private async void CmbBoxSupplierSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (supplierComboBoxControl.SupplierComboBox.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"supplier/GetById/{(Guid)supplierComboBoxControl.SupplierComboBox.SelectedValue}");
                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                var result = await ResponseController.SuccessDataResponseController<GetSupplierDTO>(response);

                if (result is not null)
                {
                    txtCompanyName.Text = result.Data.CompanyName;
                    txtContactName.Text = result.Data.ContactName;
                    txtContactTitle.Text = result.Data.ContactTitle;
                    txtPhoneNumber.Text = result.Data.PhoneNumber;
                    txtEmail.Text = result.Data.Email;
                    txtCountry.Text = result.Data.Country;
                    txtCity.Text = result.Data.City;
                    txtAddress.Text = result.Data.Addres;
                    txtWebSiteUrl.Text = result.Data.WebSite;
                }     
            }
        }
        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }
        private async void bttnSupplierUpdate_Click(object sender, EventArgs e)
        {
            if (supplierComboBoxControl.SupplierComboBox.SelectedValue is not null)
            {
                if (DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    UpdateSupplierDTO updateSupplierDTO = new UpdateSupplierDTO
                    {
                        Id = (Guid)supplierComboBoxControl.SupplierComboBox.SelectedValue,
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

                    HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("supplier/update", updateSupplierDTO);

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                    await supplierComboBoxControl.SupplierList(_webApiService);
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçin Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
