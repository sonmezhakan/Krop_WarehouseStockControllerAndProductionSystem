using Krop.Business.Features.Categories.Dtos;
using Krop.WinForms.HelpersClass.CategoryHelpers;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryCart : Form
    {

        public Guid Id;
        private readonly ICategoryHelper _categoryHelper;

        public frmCategoryCart(ICategoryHelper categoryHelper)
        {
            InitializeComponent();
            _categoryHelper = categoryHelper;
        }
        private async void frmCategoryCart_Load(object sender, EventArgs e)
        {
            await CategoryList();
            cmbBoxCategorySelect.SelectedValue = Id;
        }

        private async Task CategoryList()
        {
            List<GetCategoryComboBoxDTO> result = await _categoryHelper.GetAllComboBoxAsync();

            cmbBoxCategorySelect.SelectedIndexChanged -= cmbCategorySelect_SelectedIndexChanged;
            cmbBoxCategorySelect.DataSource = null;

            cmbBoxCategorySelect.DataSource = result;

            cmbBoxCategorySelect.DisplayMember = "CategoryName";
            cmbBoxCategorySelect.ValueMember = "Id";

            cmbBoxCategorySelect.SelectedIndexChanged += cmbCategorySelect_SelectedIndexChanged;
        }

        private void cmbCategorySelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
