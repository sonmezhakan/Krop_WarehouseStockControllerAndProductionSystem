using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Customers;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Customers
{
    public partial class frmCustomerAdd : Form
    {
        private readonly IWebApiService _webApiService;

        public frmCustomerAdd(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private void frmCustomerAdd_Load(object sender, EventArgs e)
        {
            txtPhoneNumber.MaxLength = 11;
        }

        private async void bttnCustomerAdd_Click(object sender, EventArgs e)
        {
            CreateCustomerDTO createCustomerDTO = new CreateCustomerDTO
            {
                CompanyName = txtCompanyName.Text,
                ContactName = txtContactName.Text,
                ContactTitle = txtContactTitle.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Country = txtCountry.Text,
                City = txtCity.Text,
                Addres = txtAddress.Text,
                Invoice = radioBttnPerson.Checked ? Entities.Enums.InvoiceEnum.Bireysel : Entities.Enums.InvoiceEnum.Kurumsal
            };

            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("customer/Add", createCustomerDTO);

            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }
        }
    }
}
