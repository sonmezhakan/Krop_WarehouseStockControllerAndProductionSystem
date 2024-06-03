using Krop.Common.Helpers.WebApiRequests.Categories;
using Krop.DTO.Dtos.Categroies;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryCart : Form
    {

        public Guid Id;
        private readonly ICategoryRequest _categoryRequest;

        public frmCategoryCart(ICategoryRequest categoryRequest)
        {
            InitializeComponent();
            _categoryRequest = categoryRequest;
        }
        private void frmCategoryCart_Load(object sender, EventArgs e)
        {
            CategoryList();
            if(cmbBoxCategorySelect.DataSource != null && Id != Guid.Empty)
                cmbBoxCategorySelect.SelectedValue = Id;

        }

        private async void CategoryList()
        {
            HttpResponseMessage response = await _categoryRequest.GetAllComboBoxAsync();
            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetCategoryComboBoxDTO>(response).Data;

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
