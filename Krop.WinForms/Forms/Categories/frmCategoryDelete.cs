using Krop.Common.Helpers.WebApiRequests.Categories;
using Krop.DTO.Dtos.Categroies;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryDelete : Form
    {
        public Guid Id;
        private readonly ICategoryRequest _categoryRequest;

        public frmCategoryDelete(ICategoryRequest categoryRequest)
        {
            InitializeComponent();
            _categoryRequest = categoryRequest;
        }
        private void frmCategoryDelete_Load(object sender, EventArgs e)
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
            cmbBoxCategorySelect.SelectedIndexChanged -= cmbBoxCategorySelect_SelectedIndexChanged;

            cmbBoxCategorySelect.DataSource = result;
            cmbBoxCategorySelect.SelectedIndex = -1;
            
            cmbBoxCategorySelect.SelectedIndexChanged += cmbBoxCategorySelect_SelectedIndexChanged;
        }

        private async void bttnCategoryDelete_Click(object sender, EventArgs e)
        {
            if (cmbBoxCategorySelect.SelectedValue is not null)
            {
                if (DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)//Cevap evet ise silme işlemleri gerçekleştiriliyor
                {
                    HttpResponseMessage response = await _categoryRequest.DeleteAsync((Guid)cmbBoxCategorySelect.SelectedValue);

                    if (!response.IsSuccessStatusCode)
                    {
                        ResponseController.ErrorResponseController(response);
                        return;
                    }

                    CategoryList();//ComboBox'daki listeyi yeniliyor.
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbBoxCategorySelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
