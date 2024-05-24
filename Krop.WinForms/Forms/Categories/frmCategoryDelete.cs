using Krop.Business.Features.Categories.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.CategoryHelpers;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryDelete : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly ICategoryHelper _categoryHelper;
        public Guid Id;

        public frmCategoryDelete(IWebApiService webApiService, ICategoryHelper categoryHelper)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _categoryHelper = categoryHelper;
        }
        private async void frmCategoryDelete_Load(object sender, EventArgs e)
        {
            await CategoryList();
            if(cmbBoxCategorySelect.DataSource != null && Id != Guid.Empty)
                cmbBoxCategorySelect.SelectedValue = Id;
        }
        private async Task CategoryList()
        {
            List<GetCategoryComboBoxDTO> result = await _categoryHelper.GetAllComboBoxAsync();

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
                if (DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)//Cevap evet ise silme işlemleri gerçekleştiriliyor
                {
                    HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"category/Delete/{cmbBoxCategorySelect.SelectedValue}");

                    await ResponseController.ErrorResponseController(response);//response hata kontrolü

                    await CategoryList();//ComboBox'daki listeyi yeniliyor.
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
