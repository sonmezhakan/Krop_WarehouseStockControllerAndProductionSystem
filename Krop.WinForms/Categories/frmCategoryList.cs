using Krop.Business.Features.Categories.Dtos;
using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryList : Form
    {
        private readonly IWebApiService _webApiService;

        public frmCategoryList(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
            DgwCategoryListSettings();
           
        }

        private void DgwCategoryListSettings()
        {
            dgwCategoryList.DataSource = null;
            dgwCategoryList.Columns.Add("Id", "Id");
            dgwCategoryList.Columns.Add("CategoryName", "Kategori Adı");
            dgwCategoryList.Columns[0].Visible = false;
        }
        private async void DgwCategoryListed()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("category/getall");

            if (!response.IsSuccessStatusCode)
            {
                ErrorResponseViewModel errorResponseViewModel = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                MessageBox.Show(errorResponseViewModel.Detail, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SuccessResponseViewModel<GetCategoryDTO> successResponseViewModel = await JsonHelper.DeserializeAsync<SuccessResponseViewModel<GetCategoryDTO>>(response);

            dgwCategoryList.Rows.Clear();

            foreach (GetCategoryDTO category in successResponseViewModel.Data)
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
                bool found = false;
                foreach (DataGridViewCell cell in row.Cells)//sütunlarda dön
                {
                    if (cell.Visible != false && cell.Value != null &&
                        cell.Value.ToString().ToLower().Contains(searchText))//sutün gizli değil ise, sütun boş değil ise ve arama sonucu true ise satırı göster.
                    {
                        found = true;
                        break;
                    }
                }
                row.Visible = found;//arama sonucu false ise satırı gizle
            }
        }

        private void frmCategoryList_Load(object sender, EventArgs e)
        {
            DgwCategoryListed();
        }

        private void bttnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Search();
        }

        private void productCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoryCart frmCategoryCart = new frmCategoryCart(_webApiService, 
                (Guid)dgwCategoryList.CurrentRow.Cells[0].Value);
            FormController.FormOpenController(frmCategoryCart);
        }

        private void productAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoryAdd frmCategoryAdd = new frmCategoryAdd(_webApiService);
            FormController.FormOpenController(frmCategoryAdd);
        }

        private void productUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoryUpdate frmCategoryUpdate = new frmCategoryUpdate(_webApiService, (Guid)dgwCategoryList.CurrentRow.Cells[0].Value);
            FormController.FormOpenController(frmCategoryUpdate);
        }

        private void productDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoryDelete frmCategoryDelete = new frmCategoryDelete(_webApiService, (Guid)dgwCategoryList.CurrentRow.Cells[0].Value);
            FormController.FormOpenController(frmCategoryDelete);
        }

        private void produuctListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DgwCategoryListed();
        }
    }
}
