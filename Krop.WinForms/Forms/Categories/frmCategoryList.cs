using Krop.Common.Helpers.WebApiRequests.Categories;
using Krop.DTO.Dtos.Categroies;
using Krop.WinForms.HelpersClass;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryList : Form
    {
        private readonly ICategoryRequest _categoryRequest;
        private readonly IServiceProvider _serviceProvider;
        private BindingList<GetCategoryDTO> _originalData;
        private BindingList<GetCategoryDTO> _filteredData;

        public frmCategoryList(ICategoryRequest categoryRequest, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _categoryRequest = categoryRequest;
            _serviceProvider = serviceProvider;
        }

        private void DgwCategoryListSettings()
        {
            dgwCategoryList.Columns[0].HeaderText = "Id";
            dgwCategoryList.Columns[1].HeaderText = "Kategori Adı";

            dgwCategoryList.Columns[0].Visible = false;
        }
        private async void CategoryList()
        {
            HttpResponseMessage response = await _categoryRequest.GetAllAsync();
            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetCategoryDTO>(response).Data;

            _originalData = new BindingList<GetCategoryDTO>(result);
            _filteredData = new BindingList<GetCategoryDTO>(_originalData.ToList());

            dgwCategoryList.DataSource = _filteredData;
            DgwCategoryListSettings();
        }

        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();//girilen değerleri küçülterek ata.
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = _originalData.Where(x =>
                x.CategoryName.ToLower().Contains(searchText));

                _filteredData.Clear();
                foreach (var item in filteredList)
                {
                    _filteredData.Add(item);
                }
            }
            else
            {
                _filteredData.Clear();
                foreach (var item in _originalData)
                {
                    _filteredData.Add(item);
                }
            }
        }

        private void frmCategoryList_Load(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void bttnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void CategoryCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoryCart frmCategoryCart = _serviceProvider.GetRequiredService<frmCategoryCart>();
            frmCategoryCart.Id = (Guid)dgwCategoryList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmCategoryCart);
        }

        private void CategoryAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoryAdd frmCategoryAdd = _serviceProvider.GetRequiredService<frmCategoryAdd>();
            FormController.FormOpenController(frmCategoryAdd);
        }

        private void CategoryUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoryUpdate frmCategoryUpdate = _serviceProvider.GetRequiredService<frmCategoryUpdate>();
            frmCategoryUpdate.Id = (Guid)dgwCategoryList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmCategoryUpdate);
        }

        private void CategoryDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoryDelete frmCategoryDelete = _serviceProvider.GetRequiredService<frmCategoryDelete>();
            frmCategoryDelete.Id = (Guid)dgwCategoryList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmCategoryDelete);
        }

        private void CategoryListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
