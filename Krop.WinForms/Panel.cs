using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.Categories;
using Krop.WinForms.Products;

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
            frmProductList frmProductList = new frmProductList();
            frmProductList.TopLevel = false;
            panel1.Controls.Add(frmProductList);
            frmProductList.Show();

        }

        private void categoryBttnAdd_Click(object sender, EventArgs e)
        {
            frmCategoryAdd frmCategoryAdd = new frmCategoryAdd(_webApiService);
            frmCategoryAdd.Show();
        }
    }
}
