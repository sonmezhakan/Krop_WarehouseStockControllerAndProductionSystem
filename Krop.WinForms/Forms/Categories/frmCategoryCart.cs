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
        private void frmCategoryCart_Load(object sender, EventArgs e)
        {
            CategoryList();
            if(cmbBoxCategorySelect.DataSource != null && Id != Guid.Empty)
                cmbBoxCategorySelect.SelectedValue = Id;

        }

        private void CategoryList()
        {
            List<GetCategoryComboBoxDTO> result = _categoryHelper.GetAllComboBoxAsync();
            if (result is null)
                return;

            cmbBoxCategorySelect.DataSource = null;
            
            cmbBoxCategorySelect.DisplayMember = "CategoryName";
            cmbBoxCategorySelect.ValueMember = "Id";

            cmbBoxCategorySelect.SelectedIndexChanged -= cmbCategorySelect_SelectedIndexChanged;
            cmbBoxCategorySelect.DataSource = result;
            cmbBoxCategorySelect.SelectedIndex = -1;
            cmbBoxCategorySelect.SelectedIndexChanged += cmbCategorySelect_SelectedIndexChanged;
        }

        private void cmbCategorySelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
