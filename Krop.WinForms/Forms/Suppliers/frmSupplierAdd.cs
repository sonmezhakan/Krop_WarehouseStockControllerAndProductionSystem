using Krop.Business.Features.Suppliers.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Suppliers
{
    public partial class frmSupplierAdd : Form
    {
        private readonly IWebApiService _webApiService;

        public frmSupplierAdd(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void bttnSupplierAdd_Click(object sender, EventArgs e)
        {
            CreateSupplierDTO createSupplierDTO = new CreateSupplierDTO
            {
                CompanyName = txtCompanyName.Text,
                ContactName = txtContactName.Text,
                ContactTitle = txtContactTitle.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Country = txtCountry.Text,
                City = txtCity.Text,
                Addres = txtAddress.Text,
                WebSite = txtWebSiteUrl.Text
            };

            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("supplier/Add", createSupplierDTO);

            await ResponseController.ErrorResponseController(response);

        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private void frmSupplierAdd_Load(object sender, EventArgs e)
        {
            txtPhoneNumber.MaxLength = 11;
        }
    }
}
