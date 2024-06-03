using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.AppUserRoles;
using Krop.WinForms.Brands;
using Krop.WinForms.Categories;
using Krop.WinForms.Customers;
using Krop.WinForms.Forms.AppUsers;
using Krop.WinForms.Forms.Branches;
using Krop.WinForms.Forms.Departments;
using Krop.WinForms.Forms.Employees;
using Krop.WinForms.Forms.Productions;
using Krop.WinForms.Forms.StockInputs;
using Krop.WinForms.Forms.StockTransfers;
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
        internal Guid AppUserId = Guid.Parse("00f69e9b-a621-4568-d50d-08dc827538a0");

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

        private void customerBttnList_Click(object sender, EventArgs e)
        {
            frmCustomerList frmCustomerList = _serviceProvider.GetRequiredService<frmCustomerList>();
            FormController.FormOpenController(frmCustomerList);
        }

        private void customerBttnCard_Click(object sender, EventArgs e)
        {
            frmCustomerCart frmCustomerCart = _serviceProvider.GetRequiredService<frmCustomerCart>();
            FormController.FormOpenController(frmCustomerCart);
        }

        private void customerBttnAdd_Click(object sender, EventArgs e)
        {
            frmCustomerAdd frmCustomerAdd = _serviceProvider.GetRequiredService<frmCustomerAdd>();
            FormController.FormOpenController(frmCustomerAdd);
        }

        private void customerBttnUpdate_Click(object sender, EventArgs e)
        {
            frmCustomerUpdate frmCustomerUpdate = _serviceProvider.GetRequiredService<frmCustomerUpdate>();
            FormController.FormOpenController(frmCustomerUpdate);
        }

        private void customerBttnDelete_Click(object sender, EventArgs e)
        {
            frmCustomerDelete frmCustomerDelete = _serviceProvider.GetRequiredService<frmCustomerDelete>();
            FormController.FormOpenController(frmCustomerDelete);
        }

        private void branchBttnList_Click(object sender, EventArgs e)
        {
            frmBranchList frmBranchList = _serviceProvider.GetRequiredService<frmBranchList>();
            FormController.FormOpenController(frmBranchList);
        }

        private void branchBttnCart_Click(object sender, EventArgs e)
        {
            frmBranchCart frmBranchCart = _serviceProvider.GetRequiredService<frmBranchCart>();
            FormController.FormOpenController(frmBranchCart);
        }

        private void branchBttnAdd_Click(object sender, EventArgs e)
        {
            frmBranchAdd frmBranchAdd = _serviceProvider.GetRequiredService<frmBranchAdd>();
            FormController.FormOpenController(frmBranchAdd);
        }

        private void branchBttnUpdate_Click(object sender, EventArgs e)
        {
            frmBranchUpdate frmBranchUpdate = _serviceProvider.GetRequiredService<frmBranchUpdate>();
            FormController.FormOpenController(frmBranchUpdate);
        }

        private void branchBttnDelete_Click(object sender, EventArgs e)
        {
            frmBranchDelete frmBranchDelete = _serviceProvider.GetRequiredService<frmBranchDelete>();
            FormController.FormOpenController(frmBranchDelete);
        }

        private void bttnAppUserRoleList_Click(object sender, EventArgs e)
        {
            frmAppUserRoleList frmAppUserRoleList = _serviceProvider.GetRequiredService<frmAppUserRoleList>();
            FormController.FormOpenController(frmAppUserRoleList);
        }

        private void bttnAppUserRoleAdd_Click(object sender, EventArgs e)
        {
            frmAppUserRoleAdd frmAppUserRoleAdd = _serviceProvider.GetRequiredService<frmAppUserRoleAdd>();
            FormController.FormOpenController(frmAppUserRoleAdd);
        }

        private void bttnAppUserRoleUpdate_Click(object sender, EventArgs e)
        {
            frmAppUserRoleUpdate frmAppUserRoleUpdate = _serviceProvider.GetRequiredService<frmAppUserRoleUpdate>();
            FormController.FormOpenController(frmAppUserRoleUpdate);
        }

        private void bttnAppUserRoleDelete_Click(object sender, EventArgs e)
        {
            frmAppUserRoleDelete frmAppUserRoleDelete = _serviceProvider.GetRequiredService<frmAppUserRoleDelete>();
            FormController.FormOpenController(frmAppUserRoleDelete);
        }

        private void userBttnList_Click(object sender, EventArgs e)
        {
            frmAppUserList frmAppUserList = _serviceProvider.GetRequiredService<frmAppUserList>();
            FormController.FormOpenController(frmAppUserList);
        }

        private void userBttnCard_Click(object sender, EventArgs e)
        {
            frmAppUserCart frmAppUserCart = _serviceProvider.GetRequiredService<frmAppUserCart>();
            FormController.FormOpenController(frmAppUserCart);
        }

        private void userBttnAdd_Click(object sender, EventArgs e)
        {
            frmAppUserAdd frmAppUserAdd = _serviceProvider.GetRequiredService<frmAppUserAdd>();
            FormController.FormOpenController(frmAppUserAdd);
        }

        private void userBttnUpdate_Click(object sender, EventArgs e)
        {
            frmAppUserUpdate frmAppUserUpdate = _serviceProvider.GetRequiredService<frmAppUserUpdate>();
            FormController.FormOpenController(frmAppUserUpdate);
        }

        private void departmentBttnList_Click(object sender, EventArgs e)
        {
            frmDepartmentList frmDepartmentList = _serviceProvider.GetRequiredService<frmDepartmentList>();
            FormController.FormOpenController(frmDepartmentList);
        }

        private void departmentBttnCart_Click(object sender, EventArgs e)
        {
            frmDepartmentCart frmDepartmentCart = _serviceProvider.GetRequiredService<frmDepartmentCart>();
            FormController.FormOpenController(frmDepartmentCart);
        }

        private void departmentBttnAdd_Click(object sender, EventArgs e)
        {
            frmDepartmentAdd frmDepartmentAdd = _serviceProvider.GetRequiredService<frmDepartmentAdd>();
            FormController.FormOpenController(frmDepartmentAdd);
        }

        private void departmentBttnUpdate_Click(object sender, EventArgs e)
        {
            frmDepartmentUpdate frmDepartmentUpdate = _serviceProvider.GetRequiredService<frmDepartmentUpdate>();
            FormController.FormOpenController(frmDepartmentUpdate);
        }

        private void departmentBttnDelete_Click(object sender, EventArgs e)
        {
            frmDepartmentDelete frmDepartmentDelete = _serviceProvider.GetRequiredService<frmDepartmentDelete>();
            FormController.FormOpenController(frmDepartmentDelete);
        }

        private void employeeBttnList_Click(object sender, EventArgs e)
        {
            frmEmployeeList frmEmployeeList = _serviceProvider.GetRequiredService<frmEmployeeList>();
            FormController.FormOpenController(frmEmployeeList);
        }

        private void employeeBttnCard_Click(object sender, EventArgs e)
        {
            frmEmployeeCart frmEmployeeCart = _serviceProvider.GetRequiredService<frmEmployeeCart>();
            FormController.FormOpenController(frmEmployeeCart);
        }

        private void employeeBttnAdd_Click(object sender, EventArgs e)
        {
            frmEmployeeAdd frmEmployeeAdd = _serviceProvider.GetRequiredService<frmEmployeeAdd>();
            FormController.FormOpenController(frmEmployeeAdd);
        }

        private void employeeBttnUpdate_Click(object sender, EventArgs e)
        {
            frmEmployeeUpdate frmEmployeeUpdate = _serviceProvider.GetRequiredService<frmEmployeeUpdate>();
            FormController.FormOpenController(frmEmployeeUpdate);
        }
        private void stockBttnInput_Click(object sender, EventArgs e)
        {
            frmStockInput frmStockInput = _serviceProvider.GetRequiredService<frmStockInput>();
            frmStockInput.AppUserId = AppUserId;
            FormController.FormOpenController(frmStockInput);
        }

        private void stockBttnTransfer_Click(object sender, EventArgs e)
        {
            frmStockTransfer frmStockTransfer = _serviceProvider.GetRequiredService<frmStockTransfer>();
            frmStockTransfer.AppUserId = AppUserId;
            FormController.FormOpenController(frmStockTransfer);
        }

        private void productionBttnProduce_Click(object sender, EventArgs e)
        {
            frmProduction frmProduction = _serviceProvider.GetRequiredService<frmProduction>();
            frmProduction.appUserId = AppUserId;
            FormController.FormOpenController(frmProduction);
        }
    }
}
