using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.Brands;
using Krop.WinForms.Categories;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.Products;
using Krop.WinForms.Suppliers;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.WinForms
{
    public partial class Panel : Form
    {
        public readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;

        public Panel(IWebApiService webApiService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
        }

        private void homeBttnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void productBttnList_Click(object sender, EventArgs e)
        {
            frmProductList frmProductList = _serviceProvider.GetRequiredService<frmProductList>();
            FormController.FormOpenController(frmProductList);
        }

        private void categoryBttnAdd_Click(object sender, EventArgs e)
        {
            frmCategoryAdd frmCategoryAdd = _serviceProvider.GetRequiredService<frmCategoryAdd>();
            FormController.FormOpenController(frmCategoryAdd);
        }

        private void categoryBttnCard_Click(object sender, EventArgs e)
        {
            frmCategoryCart frmCategoryCart = _serviceProvider.GetRequiredService<frmCategoryCart>();
            FormController.FormOpenController(frmCategoryCart);
        }

        private void categoryBttnDelete_Click(object sender, EventArgs e)
        {
            frmCategoryDelete frmCategoryDelete = _serviceProvider.GetRequiredService<frmCategoryDelete>();
            FormController.FormOpenController(frmCategoryDelete);
        }

        private void categoryBttnUpdate_Click(object sender, EventArgs e)
        {
            frmCategoryUpdate frmCategoryUpdate = _serviceProvider.GetRequiredService<frmCategoryUpdate>();
            FormController.FormOpenController(frmCategoryUpdate);
        }

        private void categoryBttnList_Click(object sender, EventArgs e)
        {
            frmCategoryList frmCategoryList = _serviceProvider.GetRequiredService<frmCategoryList>();
            FormController.FormOpenController(frmCategoryList);
        }

        private void Panel_Load(object sender, EventArgs e)
        {

        }

        private void bttnBrandAdd_Click(object sender, EventArgs e)
        {
            frmBrandAdd frmBrandAdd = _serviceProvider.GetRequiredService<frmBrandAdd>();
            FormController.FormOpenController(frmBrandAdd);
        }

        private void bttnBrandUpdate_Click(object sender, EventArgs e)
        {
            frmBrandUpdate frmBrandUpdate = _serviceProvider.GetRequiredService<frmBrandUpdate>();
            FormController.FormOpenController(frmBrandUpdate);
        }

        private void bttnBrandDelete_Click(object sender, EventArgs e)
        {
            frmBrandDelete frmBrandDelete = _serviceProvider.GetRequiredService<frmBrandDelete>();
            FormController.FormOpenController(frmBrandDelete);
        }

        private void bttnBrandList_Click(object sender, EventArgs e)
        {
            frmBrandList frmBrandList = _serviceProvider.GetRequiredService<frmBrandList>();
            FormController.FormOpenController(frmBrandList);
        }

        private void bttnBrandCart_Click(object sender, EventArgs e)
        {
            frmBrandCart frmBrandCart = _serviceProvider.GetRequiredService<frmBrandCart>();
            FormController.FormOpenController(frmBrandCart);
        }

        private void productBttnAdd_Click(object sender, EventArgs e)
        {
            frmProductAdd frmProductAdd = _serviceProvider.GetRequiredService<frmProductAdd>();
            FormController.FormOpenController(frmProductAdd);
        }

        private void productBttnDelete_Click(object sender, EventArgs e)
        {
            frmProductDelete frmProductDelete = _serviceProvider.GetRequiredService<frmProductDelete>();
            FormController.FormOpenController(frmProductDelete);
        }

        private void productBttnUpdate_Click(object sender, EventArgs e)
        {
            frmProductUpdate frmProductUpdate = _serviceProvider.GetRequiredService<frmProductUpdate>();
            FormController.FormOpenController(frmProductUpdate);
        }

        private void productBttnCard_Click(object sender, EventArgs e)
        {
            frmProductCart frmProductCart = _serviceProvider.GetRequiredService<frmProductCart>();
            FormController.FormOpenController(frmProductCart);
        }

        private void productBttnRecipe_Click(object sender, EventArgs e)
        {
            frmProductReceipt frmProductReceipt = _serviceProvider.GetRequiredService<frmProductReceipt>();
            FormController.FormOpenController(frmProductReceipt);
        }

        private void supplierBttnAdd_Click(object sender, EventArgs e)
        {
            frmSupplierAdd frmSupplierAdd = _serviceProvider.GetRequiredService<frmSupplierAdd>();
            FormController.FormOpenController(frmSupplierAdd);
        }

        private void supplierBttnUpdate_Click(object sender, EventArgs e)
        {
            frmSupplierUpdate frmSupplierUpdate = _serviceProvider.GetRequiredService<frmSupplierUpdate>();
            FormController.FormOpenController(frmSupplierUpdate);
        }

        private void supplierBttnDelete_Click(object sender, EventArgs e)
        {
            frmSupplierDelete frmSupplierDelete = _serviceProvider.GetRequiredService<frmSupplierDelete>();
            FormController.FormOpenController(frmSupplierDelete);
        }

        private void supplierBttnCard_Click(object sender, EventArgs e)
        {
            frmSupplierCart frmSupplierCart = _serviceProvider.GetRequiredService<frmSupplierCart>();
            FormController.FormOpenController(frmSupplierCart);
        }

        private void supplierBttnList_Click(object sender, EventArgs e)
        {
            frmSupplierList frmSupplierList = _serviceProvider.GetRequiredService<frmSupplierList>();
            FormController.FormOpenController(frmSupplierList);
        }
    }
}
