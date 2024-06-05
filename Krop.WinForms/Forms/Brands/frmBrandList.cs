using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.WinForms.Brands
{
    public partial class frmBrandList : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;

        public frmBrandList(IWebApiService webApiService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
        }

        private async void frmBrandList_Load(object sender, EventArgs e)
        {
            await brandListControl.BrandList(_webApiService);
        }
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();//girilen değerleri küçülterek ata.
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = brandListControl._originalData.Where(x =>
                (x.BrandName != null && x.BrandName.ToLower().Contains(searchText)) ||
                (x.PhoneNumber != null && x.PhoneNumber.ToString().ToLower().Contains(searchText)) ||
                (x.Email != null && x.Email.ToLower().Contains(searchText)));

                brandListControl._filteredData.Clear();
                foreach (var item in filteredList)
                {
                    brandListControl._filteredData.Add(item);
                }
            }
            else
            {
                brandListControl._filteredData.Clear();
                foreach (var item in brandListControl._originalData)
                {
                    brandListControl._filteredData.Add(item);
                }
            }
        }

        private void bttnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void brandCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBrandCart frmBrandCart = _serviceProvider.GetRequiredService<frmBrandCart>();
            frmBrandCart.Id = (Guid)brandListControl.DataGridViewBrandList.SelectedRows[0].Cells[0].Value;
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
            frmBrandUpdate.Id = (Guid)brandListControl.DataGridViewBrandList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmBrandUpdate);
        }

        private void brandDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBrandDelete frmBrandDelete = _serviceProvider.GetRequiredService<frmBrandDelete>();
            frmBrandDelete.Id = (Guid)brandListControl.DataGridViewBrandList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmBrandDelete);
        }

        private async void brandListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await brandListControl.BrandList(_webApiService);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
