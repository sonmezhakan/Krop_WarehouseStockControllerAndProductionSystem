using Krop.Business.Features.Products.Dtos;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.ProductHelpers;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Krop.WinForms.Products
{
    public partial class frmProductList : Form
    {
        private readonly IProductHelper _productHelper;
        private readonly IServiceProvider _serviceProvider;
        private BindingList<GetProductListDTO> _originalData;
        private BindingList<GetProductListDTO> _filteredData;

        public frmProductList(IProductHelper productHelper, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _productHelper = productHelper;
            _serviceProvider = serviceProvider;
        }

        private async void frmProductList_Load(object sender, EventArgs e)
        {
            await ProductList();
        }
        private void DgwProductListSetting()
        {
            dgwProductList.Columns[0].HeaderText = "Id";
            dgwProductList.Columns[1].HeaderText = "Ürün Adı";
            dgwProductList.Columns[2].HeaderText = "Ürün Kdou";
            dgwProductList.Columns[3].HeaderText = "Kategori Adı";
            dgwProductList.Columns[4].HeaderText = "Marka Adı";
            dgwProductList.Columns[5].HeaderText = "Fiyat";
            dgwProductList.Columns[6].HeaderText = "Resim";
            dgwProductList.Columns[7].HeaderText = "Kritik Stok";
            dgwProductList.Columns[8].HeaderText = "Açıklama";

            dgwProductList.Columns[0].Visible = false;
            dgwProductList.Columns[6].Visible = false;
        }

        private async Task ProductList()
        {
            List<GetProductListDTO> products = await _productHelper.GetAllAsync();

            _originalData = new BindingList<GetProductListDTO>(products);
            _filteredData = new BindingList<GetProductListDTO>(_originalData.ToList());
            dgwProductList.DataSource = _filteredData;

            DgwProductListSetting();
        }
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredLits = _originalData.Where(x =>
                (x.ProductName != null && x.ProductName.ToLower().Contains(searchText)) ||
                (x.ProductCode != null && x.ProductCode.ToLower().Contains(searchText)) ||
                (x.CategoryName != null && x.CategoryName.ToLower().Contains(searchText)) ||
                (x.BrandName != null && x.BrandName.ToLower().Contains(searchText)) ||
                (x.UnitPrice != null && x.UnitPrice.ToString().ToLower().Contains(searchText)) ||
                (x.CriticalStock != null && x.CriticalStock.ToString().ToLower().Contains(searchText)) ||
                (x.Description != null && x.Description.ToLower().Contains(searchText)));

                _filteredData.Clear();
                foreach (var item in filteredLits)
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
        private void bttnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void productCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductCart frmProductCart = _serviceProvider.GetRequiredService<frmProductCart>();
            frmProductCart.Id = (Guid)dgwProductList.SelectedRows[0].Cells[0].Value;
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
            frmProductUpdate.Id = (Guid)dgwProductList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmProductUpdate);
        }

        private void productDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductDelete frmProductDelete = _serviceProvider.GetRequiredService<frmProductDelete>();
            frmProductDelete.Id = (Guid)dgwProductList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmProductDelete);
        }

        private async void produuctListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ProductList();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
