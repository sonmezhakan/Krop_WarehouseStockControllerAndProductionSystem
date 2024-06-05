using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Categroies;
using Krop.WinForms.HelpersClass;
using System.ComponentModel;

namespace Krop.WinForms.UserControllers.Categories
{
    public partial class CategoryListControl : UserControl
    {
        public BindingList<GetCategoryDTO> _originalData;
        public BindingList<GetCategoryDTO> _filteredData;
        public CategoryListControl()
        {
            InitializeComponent();
        }
        private void DgwCategoryListSettings()
        {
            dgwCategoryList.Columns[0].HeaderText = "Id";
            dgwCategoryList.Columns[1].HeaderText = "Kategori Adı";

            dgwCategoryList.Columns[0].Visible = false;
        }
        public async Task CategoryList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("category/GetAll");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetCategoryDTO>>(response);

            if (response is not null)
            {
                _originalData = new BindingList<GetCategoryDTO>(result.Data);
                _filteredData = new BindingList<GetCategoryDTO>(_originalData.ToList());

                dgwCategoryList.DataSource = _filteredData;
                DgwCategoryListSettings();
            }
        }
        public DataGridView DataGridViewCategoryList
        {
            get { return dgwCategoryList; }
        }
    }
}
