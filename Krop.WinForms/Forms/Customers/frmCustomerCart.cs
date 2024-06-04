using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Customers;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Customers
{
    public partial class frmCustomerCart : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmCustomerCart(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmCustomerCart_Load(object sender, EventArgs e)
        {
           await CustomerList();
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

                var result =await ResponseController.SuccessDataResponseController<GetCustomerDTO>(response);

                if(result is not null)
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

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }
    }
}
