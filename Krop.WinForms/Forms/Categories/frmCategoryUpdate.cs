using Krop.Common.Helpers.WebApiRequests.Categories;
using Krop.DTO.Dtos.Categroies;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryUpdate : Form
    {
        public Guid Id;
        private readonly ICategoryRequest _categoryRequest;

        public frmCategoryUpdate(ICategoryRequest categoryRequest)
        {
            InitializeComponent();
            _categoryRequest = categoryRequest;
        }
        private void frmCategoryUpdate_Load(object sender, EventArgs e)
        {
            CategoryList();
            if (cmbBoxCategorySelect.DataSource != null && Id != Guid.Empty)
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

            cmbBoxCategorySelect.SelectedIndexChanged -= cmbBoxCategorySelect_SelectedIndexChanged; 
            cmbBoxCategorySelect.DataSource = result;
            cmbBoxCategorySelect.SelectedIndex = -1;
            cmbBoxCategorySelect.SelectedIndexChanged += cmbBoxCategorySelect_SelectedIndexChanged;
        }

        private async void bttnCategoryUpdate_Click(object sender, EventArgs e)
        {
            if (cmbBoxCategorySelect.SelectedValue is not null)
            {
                if (DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    UpdateCategoryDTO updateCategoryDTO = new UpdateCategoryDTO
                    {
                        Id = (Guid)cmbBoxCategorySelect.SelectedValue,
                        CategoryName = txtCategoryName.Text
                    };

                    HttpResponseMessage response = await _categoryRequest.UpdateAsync(updateCategoryDTO);

                    if (!response.IsSuccessStatusCode)
                    {
                        ResponseController.ErrorResponseController(response);
                        return;
                    }

                    CategoryList();
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cmbBoxCategorySelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxCategorySelect.SelectedValue is not null)
            {
                HttpResponseMessage response = await _categoryRequest.GetByIdAsync((Guid)cmbBoxCategorySelect.SelectedValue);
                if(!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                var result = ResponseController.SuccessDataResponseController<GetCategoryDTO>(response).Data;

                txtCategoryName.Text = result.CategoryName;
            }
        }
    }
}
