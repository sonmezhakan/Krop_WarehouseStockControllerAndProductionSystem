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
            await categoryComboBoxControl.CategoryList(_webApiService);
        }
         private async void bttnCategoryDelete_Click(object sender, EventArgs e)
        {
            if (categoryComboBoxControl.CategoryComboBox.SelectedValue is not null)
            {
                if (DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)//Cevap evet ise silme işlemleri gerçekleştiriliyor
                {
                    HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"category/Delete/{(Guid)categoryComboBoxControl.CategoryComboBox.SelectedValue}");

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                    await categoryComboBoxControl.CategoryList(_webApiService);
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
