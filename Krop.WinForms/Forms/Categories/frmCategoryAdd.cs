using Krop.Common.Helpers.WebApiRequests.Categories;
using Krop.DTO.Dtos.Categroies;
using Krop.WinForms.HelpersClass;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryAdd : Form
    {
        private readonly ICategoryRequest _categoryRequest;
        private readonly IServiceProvider _serviceProvider;

        public frmCategoryAdd(ICategoryRequest categoryRequest, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _categoryRequest = categoryRequest;
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

            HttpResponseMessage response = await _categoryRequest.AddAsync(createCategoryDTO);

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
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
