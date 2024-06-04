using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Categroies;
using Krop.WinForms.HelpersClass;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryAdd : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;

        public frmCategoryAdd(IWebApiService webApiService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
        }

        private void frmCategoryAdd_Load(object sender, EventArgs e)
        {

        }

        private async void bttnCategoryAdd_Click(object sender, EventArgs e)
        {
            CreateCategoryDTO createCategoryDTO = new CreateCategoryDTO
            {
                CategoryName = txtAppUserRoleName.Text
            };

            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("category/Add", createCategoryDTO);

            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

        }

        private void bttnCategoryAddRange_Click(object sender, EventArgs e)
        {
            frmCategoryAddRange frmCategoryAddRange = _serviceProvider.GetRequiredService<frmCategoryAddRange>();
            FormController.FormOpenController(frmCategoryAddRange);
        }
    }
}
