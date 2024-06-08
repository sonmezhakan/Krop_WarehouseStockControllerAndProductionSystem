using Krop.Common.Helpers.WebApiService;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryCart : Form
    {

        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmCategoryCart(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }
        private async void frmCategoryCart_Load(object sender, EventArgs e)
        {
            await categoryComboBoxControl.CategoryList(_webApiService);
            categoryComboBoxControl.CategorySelect(Id);
        }
    }
}
