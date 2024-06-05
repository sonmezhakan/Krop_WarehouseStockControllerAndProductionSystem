using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Categroies;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryUpdate : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmCategoryUpdate(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }
        private async void frmCategoryUpdate_Load(object sender, EventArgs e)
        {
            await categoryComboBoxControl.CategoryList(_webApiService);
            categoryComboBoxControl.CategoryComboBox.SelectedIndexChanged += cmbBoxCategorySelect_SelectedIndexChanged;
            categoryComboBoxControl.CategorySelect(Id);
        }

        private async void bttnCategoryUpdate_Click(object sender, EventArgs e)
        {
            if (categoryComboBoxControl.CategoryComboBox.SelectedValue is not null)
            {
                if (DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    UpdateCategoryDTO updateCategoryDTO = new UpdateCategoryDTO
                    {
                        Id = (Guid)categoryComboBoxControl.CategoryComboBox.SelectedValue,
                        CategoryName = txtCategoryName.Text
                    };

                    HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("category/update", updateCategoryDTO);

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

        private async void cmbBoxCategorySelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoryComboBoxControl.CategoryComboBox.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"category/GetById/{(Guid)categoryComboBoxControl.CategoryComboBox.SelectedValue}");
                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                var result =await ResponseController.SuccessDataResponseController<GetCategoryDTO>(response);
                if (result is not null)
                {
                    txtCategoryName.Text = result.Data.CategoryName;
                }          
            }
        }
    }
}
