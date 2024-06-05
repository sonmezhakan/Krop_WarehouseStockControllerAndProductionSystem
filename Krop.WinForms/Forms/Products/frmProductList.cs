using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.WinForms.Products
{
    public partial class frmProductList : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;

        public frmProductList(IWebApiService webApiService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
        }

        private async void frmProductList_Load(object sender, EventArgs e)
        {
            await productListControl.ProductList(_webApiService);
        }
        
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredLits = productListControl._originalData.Where(x =>
                (x.ProductName != null && x.ProductName.ToLower().Contains(searchText)) ||
                (x.ProductCode != null && x.ProductCode.ToLower().Contains(searchText)) ||
                (x.CategoryName != null && x.CategoryName.ToLower().Contains(searchText)) ||
                (x.BrandName != null && x.BrandName.ToLower().Contains(searchText)) ||
                (x.UnitPrice != null && x.UnitPrice.ToString().Contains(searchText)) ||
                (x.CriticalStock != null && x.CriticalStock.ToString().Contains(searchText)) ||
                (x.Description != null && x.Description.ToLower().Contains(searchText)));

                productListControl._filteredData.Clear();
                foreach (var item in filteredLits)
                {
                    productListControl._filteredData.Add(item);
                }
            }
            else
            {
                productListControl._filteredData.Clear();
                foreach (var item in productListControl._originalData)
                {
                    productListControl._filteredData.Add(item);
                }
            }
        }
        private void bttnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void productCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductCart frmProductCart = _serviceProvider.GetRequiredService<frmProductCart>();
            frmProductCart.Id = (Guid)productListControl.DataGridViewProductList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmProductCart);
        }

        private void productAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductAdd frmProductAdd = _serviceProvider.GetRequiredService<frmProductAdd>();
            FormController.FormOpenController(frmProductAdd);
        }

        private void productUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductUpdate frmProductUpdate = _serviceProvider.GetRequiredService<frmProductUpdate>();
            frmProductUpdate.Id = (Guid)productListControl.DataGridViewProductList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmProductUpdate);
        }

        private void productDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductDelete frmProductDelete = _serviceProvider.GetRequiredService<frmProductDelete>();
            frmProductDelete.Id = (Guid)productListControl.DataGridViewProductList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmProductDelete);
        }

        private async void produuctListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await productListControl.ProductList(_webApiService);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
