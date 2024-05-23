using Krop.Business.Features.Categories.Dtos;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.CategoryHelpers;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryList : Form
    {
        private readonly ICategoryHelper _categoryHelper;
        private readonly IServiceProvider _serviceProvider;

        public frmCategoryList(ICategoryHelper categoryHelper, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _categoryHelper = categoryHelper;
            _serviceProvider = serviceProvider;
            DgwCategoryListSettings();

        }

        private void DgwCategoryListSettings()
        {
            dgwCategoryList.DataSource = null;
            dgwCategoryList.Columns.Add("Id", "Id");
            dgwCategoryList.Columns.Add("CategoryName", "Kategori Adı");
            dgwCategoryList.Columns[0].Visible = false;
        }
        private async Task CategoryList()
        {
            List<GetCategoryDTO> result = await _categoryHelper.GetAllAsync();

            dgwCategoryList.Rows.Clear();

            foreach (GetCategoryDTO category in result)
            {
                dgwCategoryList.Rows.Add(category.Id, category.CategoryName);
            }
        }

        private async void Search()
        {
            string searchText = txtSearch.Text.ToLower();//girilen değerleri küçülterek ata.
            if (string.IsNullOrWhiteSpace(searchText))//Eğer textBox boş ise tüm verileri getir.
            {
                foreach (DataGridViewRow row in dgwCategoryList.Rows)//satırlarda dön
                {
                    row.Visible = true;//satırları göster
                }
                return;
            }

            foreach (DataGridViewRow row in dgwCategoryList.Rows)//satırlarda dön
            {
                bool statu = false;
                foreach (DataGridViewCell cell in row.Cells)//sütunlarda dön
                {
                    if (cell.Visible != false && cell.Value != null &&
                        cell.Value.ToString().ToLower().Contains(searchText))//sutün gizli değil ise, sütun boş değil ise ve arama sonucu true ise satırı göster.
                    {
                        statu = true;
                        break;
                    }                  
                }
                row.Visible = statu;//arama sonucu false ise satırı gizle
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
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Search();
        }

        private void CategoryCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoryCart frmCategoryCart = _serviceProvider.GetRequiredService<frmCategoryCart>();
            frmCategoryCart.Id = (Guid)dgwCategoryList.CurrentRow.Cells[0].Value;
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
            frmCategoryUpdate.Id = (Guid)dgwCategoryList.CurrentRow.Cells[0].Value;
            FormController.FormOpenController(frmCategoryUpdate);
        }

        private void CategoryDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoryDelete frmCategoryDelete = _serviceProvider.GetRequiredService<frmCategoryDelete>();
            frmCategoryDelete.Id = (Guid)dgwCategoryList.CurrentRow.Cells[0].Value;
            FormController.FormOpenController(frmCategoryDelete);
        }

        private async void CategoryListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await CategoryList();
        }
    }
}
