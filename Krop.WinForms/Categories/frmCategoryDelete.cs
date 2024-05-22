using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.WinForms.HelpersClass.Categories;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryDelete : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly Guid _categoryId;

        public frmCategoryDelete(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }
        public frmCategoryDelete(IWebApiService webApiService,Guid categoryId)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _categoryId = categoryId;
        }

        private async void frmCategoryDelete_Load(object sender, EventArgs e)
        {
            await CategoryCustomMetot.CategoryComboBoxList(cmbBoxCategorySelected, _webApiService);
            cmbBoxCategorySelected.SelectedValue = _categoryId;
        }

        private async void bttnCategoryDelete_Click(object sender, EventArgs e)
        {
           if(cmbBoxCategorySelected.SelectedValue is not null)
            {
                DialogResult result = MessageBox.Show("Silmek İstediğinize Emin Misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);//Silmek isteyip istemediğini soruyoruz.

                if (result == DialogResult.Yes)//Cevap evet ise silme işlemleri gerçekleştiriliyor
                {
                    HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"category/Delete/{cmbBoxCategorySelected.SelectedValue}");

                    if (!response.IsSuccessStatusCode)//silinmez ise hata fırlatıyor
                    {
                        ErrorResponseViewModel errorResponseViewModel = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                        MessageBox.Show(errorResponseViewModel.Detail, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    CategoryCustomMetot.CategoryComboBoxList(cmbBoxCategorySelected, _webApiService);//ComboBox'daki listeyi yeniliyor.
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
