using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Customers;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Customers
{
    public partial class frmCustomerUpdate : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmCustomerUpdate(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private async void frmCustomerUpdate_Load(object sender, EventArgs e)
        {
           await CustomerList();
            txtPhoneNumber.MaxLength = 11;
            if (cmbBoxCustomerSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxCustomerSelect.SelectedValue = Id;
        }

        private async Task CustomerList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("customer/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetCustomerComboBoxDTO>>(response);

            cmbBoxCustomerSelect.DataSource = null;

            cmbBoxCustomerSelect.DisplayMember = "CompanyName";
            cmbBoxCustomerSelect.ValueMember = "Id";

            cmbBoxCustomerSelect.SelectedIndexChanged -= CmbBoxCustomerSelect_SelectedIndexChanged;
            cmbBoxCustomerSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxCustomerSelect.SelectedIndex = -1;
            cmbBoxCustomerSelect.SelectedIndexChanged += CmbBoxCustomerSelect_SelectedIndexChanged;
        }

        private async void CmbBoxCustomerSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxCustomerSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"customer/GetById/{cmbBoxCustomerSelect.SelectedValue}");
                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                var result = await ResponseController.SuccessDataResponseController<GetCustomerDTO>(response);

                if (result is not null)
                {
                    if (result.Data.Invoice == Entities.Enums.InvoiceEnum.Bireysel)
                        radioBttnPerson.Checked = true;
                    else
                        radioBttnCompany.Checked = true;

                    txtContactName.Text = result.Data.ContactName;
                    txtContactTitle.Text = result.Data.ContactTitle;
                    txtPhoneNumber.Text = result.Data.PhoneNumber;
                    txtEmail.Text = result.Data.Email;
                    txtCountry.Text = result.Data.Country;
                    txtCity.Text = result.Data.City;
                    txtAddress.Text = result.Data.Addres;
                }
            }
        }

        private async void bttnCustomerUpdate_Click(object sender, EventArgs e)
        {
            if (cmbBoxCustomerSelect.SelectedValue is not null)
            {
                if (DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    UpdateCustomerDTO updateCustomerDTO = new UpdateCustomerDTO
                    {
                        Id = (Guid)cmbBoxCustomerSelect.SelectedValue,
                        CompanyName = txtCompanyName.Text,
                        ContactName = txtContactName.Text,
                        ContactTitle = txtContactTitle.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        Email = txtEmail.Text,
                        Country = txtCountry.Text,
                        City = txtCity.Text,
                        Addres = txtAddress.Text,
                        Invoice = radioBttnPerson.Checked ? Entities.Enums.InvoiceEnum.Bireysel : Entities.Enums.InvoiceEnum.Kurumsal
                    };

                    HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("customer/update", updateCustomerDTO);

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                   await CustomerList();
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
