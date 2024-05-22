using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass.Categories;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryCart : Form
    {
        private readonly IWebApiService _webApiService;
        private Guid _categoryId;

        public frmCategoryCart(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }
        public frmCategoryCart(IWebApiService webApiService, Guid categoryId)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _categoryId = categoryId;
        }

        private async void frmCategoryCart_Load(object sender, EventArgs e)
        {
            await CategoryCustomMetot.CategoryComboBoxList(cmbCategorySelect, _webApiService);
            cmbCategorySelect.SelectedValue = _categoryId;
        }

    }
}
