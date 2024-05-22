using Krop.Business.Features.Categories.Dtos;
using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.WinForms.HelpersClass.Categories;
using System.Net.Http.Json;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryUpdate : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly Guid _categoryId;

        public frmCategoryUpdate(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }
        public frmCategoryUpdate(IWebApiService webApiService,Guid categoryId)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _categoryId = categoryId;
        }

        private async void frmCategoryUpdate_Load(object sender, EventArgs e)
        {
            await CategoryCustomMetot.CategoryComboBoxList(cmbBoxCategorySelected, _webApiService);
            cmbBoxCategorySelected.SelectedValue = _categoryId;
        }

        private async void bttnCategoryUpdate_Click(object sender, EventArgs e)
        {
            if(cmbBoxCategorySelected.SelectedValue is not null)
            {
                DialogResult result = MessageBox.Show("Güncellemek İstediğinize Emin Misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    UpdateCategoryDTO updateCategoryDTO = new UpdateCategoryDTO
                    {
                        Id = (Guid)cmbBoxCategorySelected.SelectedValue,
                        CategoryName = txtCategoryName.Text
                    };

                    HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("category/update", updateCategoryDTO);

                    if(!response.IsSuccessStatusCode)
                    {
                        ErrorResponseViewModel errorResponseViewModel = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                        MessageBox.Show(errorResponseViewModel.Detail, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    CategoryCustomMetot.CategoryComboBoxList(cmbBoxCategorySelected, _webApiService);
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
