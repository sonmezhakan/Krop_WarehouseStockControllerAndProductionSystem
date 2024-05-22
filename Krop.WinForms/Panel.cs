using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.Categories;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms
{
    public partial class Panel : Form
    {
        public readonly IWebApiService _webApiService;
        public Panel(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private void homeBttnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void productBttnList_Click(object sender, EventArgs e)
        {
            /*frmProductList frmProductList = new frmProductList();
            frmProductList.TopLevel = false;
            panel1.Controls.Add(frmProductList);
            frmProductList.Show();*/

        }

        private void categoryBttnAdd_Click(object sender, EventArgs e)
        {
            frmCategoryAdd frmCategoryAdd = new frmCategoryAdd(_webApiService);
            FormController.FormOpenController(frmCategoryAdd);
        }

        private void categoryBttnCard_Click(object sender, EventArgs e)
        {
            frmCategoryCart frmCategoryCart = new frmCategoryCart(_webApiService);
            FormController.FormOpenController(frmCategoryCart);
        }

        private void categoryBttnDelete_Click(object sender, EventArgs e)
        {
            frmCategoryDelete frmCategoryDelete = new frmCategoryDelete(_webApiService);
            FormController.FormOpenController(frmCategoryDelete);
        }

        private void categoryBttnUpdate_Click(object sender, EventArgs e)
        {
            frmCategoryUpdate frmCategoryUpdate = new frmCategoryUpdate(_webApiService);
            FormController.FormOpenController(frmCategoryUpdate);
        }

        private void categoryBttnList_Click(object sender, EventArgs e)
        {
            frmCategoryList frmCategoryList = new frmCategoryList(_webApiService);
            FormController.FormOpenController(frmCategoryList);
        }

        private void Panel_Load(object sender, EventArgs e)
        {

        }
    }
}
