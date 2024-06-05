using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryList : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;

        public frmCategoryList(IWebApiService webApiService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
        }
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();//girilen değerleri küçülterek ata.
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = categoryListControl._originalData.Where(x =>
                x.CategoryName.ToLower().Contains(searchText));

                categoryListControl._filteredData.Clear();
                foreach (var item in filteredList)
                {
                    categoryListControl._filteredData.Add(item);
                }
            }
            else
            {
                categoryListControl._filteredData.Clear();
                foreach (var item in categoryListControl._originalData)
                {
                    categoryListControl._filteredData.Add(item);
                }
            }
        }

        private async void frmCategoryList_Load(object sender, EventArgs e)
        {
            await categoryListControl.CategoryList(_webApiService);
        }

        private void bttnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void CategoryCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoryCart frmCategoryCart = _serviceProvider.GetRequiredService<frmCategoryCart>();
            frmCategoryCart.Id = (Guid)categoryListControl.DataGridViewCategoryList.SelectedRows[0].Cells[0].Value;
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
            frmCategoryUpdate.Id = (Guid)categoryListControl.DataGridViewCategoryList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmCategoryUpdate);
        }

        private void CategoryDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoryDelete frmCategoryDelete = _serviceProvider.GetRequiredService<frmCategoryDelete>();
            frmCategoryDelete.Id = (Guid)categoryListControl.DataGridViewCategoryList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmCategoryDelete);
        }

        private async void CategoryListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await categoryListControl.CategoryList(_webApiService);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
