using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Brands;
using Krop.WinForms.HelpersClass;
using System.Net.Http.Json;

namespace Krop.WinForms.Brands
{
    public partial class frmBrandAdd : Form
    {
        private readonly IWebApiService _webApiService;

        public frmBrandAdd(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private void frmBrandAdd_Load(object sender, EventArgs e)
        {

        }

        private async void bttnBrandAdd_Click(object sender, EventArgs e)
        {
            CreateBrandDTO createBrandDTO = new CreateBrandDTO
            {
                BrandName = txtBrandName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Email = txtEmail.Text
            };

            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("brand/add", createBrandDTO);

            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

        }
    }
}
