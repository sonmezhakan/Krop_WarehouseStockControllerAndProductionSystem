using Krop.Business.Features.Brands.Dtos;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.BrandHelpers;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.WinForms.Brands
{
    public partial class frmBrandList : Form
    {
        private readonly IBrandHelper _brandHelper;
        private readonly IServiceProvider _serviceProvider;

        public frmBrandList(IBrandHelper brandHelper, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _brandHelper = brandHelper;
            _serviceProvider = serviceProvider;
            DgwBrandListSettings();
        }

        private async void frmBrandList_Load(object sender, EventArgs e)
        {
            await BrandList();
        }
        private void DgwBrandListSettings()
        {
            dgwBrandList.Columns.Add("Id", "Id");
            dgwBrandList.Columns.Add("BrandName", "Marka Adı");
            dgwBrandList.Columns.Add("PhoneNumber", "Telefon Numarası");
            dgwBrandList.Columns.Add("Email", "Email");

            dgwBrandList.Columns[0].Visible = false;
        }
        private async Task BrandList()
        {
            List<GetBrandDTO> result = await _brandHelper.GetAllAsync();

            dgwBrandList.Rows.Clear();

            foreach (GetBrandDTO brand in result)
            {
                dgwBrandList.Rows.Add(
                    brand.Id,
                    brand.BrandName,
                    brand.PhoneNumber,
                    brand.Email
                );
            }
        }
        private async void Search()
        {
            string searchText = txtSearch.Text.ToLower();//girilen değerleri küçülterek ata.
            if (string.IsNullOrWhiteSpace(searchText))//Eğer textBox boş ise tüm verileri getir.
            {
                foreach (DataGridViewRow row in dgwBrandList.Rows)//satırlarda dön
                {
                    row.Visible = true;//satırları göster
                }
                return;
            }

            foreach (DataGridViewRow row in dgwBrandList.Rows)//satırlarda dön
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

        private void bttnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Search();
        }
        
        private void brandCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBrandCart frmBrandCart = _serviceProvider.GetRequiredService<frmBrandCart>();
            frmBrandCart.Id = (Guid)dgwBrandList.CurrentRow.Cells[0].Value;
            FormController.FormOpenController(frmBrandCart);
        }

        private void brandAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBrandAdd frmBrandAdd = _serviceProvider.GetRequiredService<frmBrandAdd>();
            FormController.FormOpenController(frmBrandAdd);
        }

        private void brandUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBrandUpdate frmBrandUpdate = _serviceProvider.GetRequiredService<frmBrandUpdate>();
            frmBrandUpdate.Id = (Guid)dgwBrandList.CurrentRow.Cells[0].Value;
            FormController.FormOpenController(frmBrandUpdate);
        }

        private void brandDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBrandDelete frmBrandDelete = _serviceProvider.GetRequiredService<frmBrandDelete>();
            frmBrandDelete.Id = (Guid)dgwBrandList.CurrentRow.Cells[0].Value;
            FormController.FormOpenController(frmBrandDelete);
        }

        private async void brandListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await BrandList();
        }
    }
}
