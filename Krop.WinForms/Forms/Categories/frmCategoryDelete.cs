using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Categroies;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryDelete : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmCategoryDelete(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }
        private async void frmCategoryDelete_Load(object sender, EventArgs e)
        {
           await CategoryList();
            if(cmbBoxCategorySelect.DataSource != null && Id != Guid.Empty)
                cmbBoxCategorySelect.SelectedValue = Id;
        }
        private async Task CategoryList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("category/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetCategoryComboBoxDTO>>(response);

            cmbBoxCategorySelect.DataSource = null;

            cmbBoxCategorySelect.DisplayMember = "CategoryName";
            cmbBoxCategorySelect.ValueMember = "Id";
            cmbBoxCategorySelect.SelectedIndexChanged -= cmbBoxCategorySelect_SelectedIndexChanged;

            cmbBoxCategorySelect.DataSource = result is not null ? result.Data : null;
            cmbBoxCategorySelect.SelectedIndex = -1;
            
            cmbBoxCategorySelect.SelectedIndexChanged += cmbBoxCategorySelect_SelectedIndexChanged;
        }

        private async void bttnCategoryDelete_Click(object sender, EventArgs e)
        {
            if (cmbBoxCategorySelect.SelectedValue is not null)
            {
                if (DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)//Cevap evet ise silme işlemleri gerçekleştiriliyor
                {
                    HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"category/Delete/{cmbBoxCategorySelect.SelectedValue}");

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

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
