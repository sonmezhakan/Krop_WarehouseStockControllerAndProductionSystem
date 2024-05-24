using Krop.Business.Features.Categories.Dtos;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.CategoryHelpers;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryList : Form
    {
        private readonly ICategoryHelper _categoryHelper;
        private readonly IServiceProvider _serviceProvider;
        private BindingList<GetCategoryDTO> _originalData;
        private BindingList<GetCategoryDTO> _filteredData;

        public frmCategoryList(ICategoryHelper categoryHelper, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _categoryHelper = categoryHelper;
            _serviceProvider = serviceProvider;
        }

        private void DgwCategoryListSettings()
        {
            dgwCategoryList.Columns[0].HeaderText = "Id";
            dgwCategoryList.Columns[1].HeaderText = "Kategori Adı";

            dgwCategoryList.Columns[0].Visible = false;
        }
        private async Task CategoryList()
        {
            List<GetCategoryDTO> result = await _categoryHelper.GetAllAsync();
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

        private async void frmCategoryList_Load(object sender, EventArgs e)
        {
            await CategoryList();
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

        private async void CategoryListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await CategoryList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
