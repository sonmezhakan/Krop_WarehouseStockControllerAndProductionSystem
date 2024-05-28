using Krop.Business.Features.Categories.Dtos;
using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.WinForms.HelpersClass;
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

        private void bttnCategoryAdd_Click(object sender, EventArgs e)
        {
            CreateCategoryDTO createCategoryDTO = new CreateCategoryDTO
            {
                CategoryName = txtAppUserRoleName.Text
            };

            HttpResponseMessage response = _webApiService.httpClient.PostAsJsonAsync("category/add", createCategoryDTO).Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

        }

        private void bttnCategoryAddRange_Click(object sender, EventArgs e)
        {
            frmCategoryAddRange frmCategoryAddRange = new frmCategoryAddRange(_webApiService);
            frmCategoryAddRange.ShowDialog();
        }
    }
}
