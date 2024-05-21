using Krop.Business.Features.Categories.Dtos;
using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using System.Net.Http.Json;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryAdd : Form
    {
        private readonly IWebApiService _webApiService;

        public frmCategoryAdd(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private void frmCategoryAdd_Load(object sender, EventArgs e)
        {


        }

        private async void bttnCategoryAdd_Click(object sender, EventArgs e)
        {
            CreateCategoryDTO createCategoryDTO = new CreateCategoryDTO
            {
                CategoryName = txtCategoryName.Text
            };

            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("category/add", createCategoryDTO);

            if (!response.IsSuccessStatusCode)
            {
                var errorResponseViewModel = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                MessageBox.Show($"{errorResponseViewModel.Detail}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
