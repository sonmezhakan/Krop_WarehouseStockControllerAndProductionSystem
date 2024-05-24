using Krop.Business.Features.Categories.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.CategoryHelpers;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryUpdate : Form
    {
        private readonly ICategoryHelper _categoryHelper;
        private readonly IWebApiService _webApiService;
        public Guid Id;


        public frmCategoryUpdate(ICategoryHelper categoryHelper, IWebApiService webApiService)
        {
            InitializeComponent();
            _categoryHelper = categoryHelper;
            _webApiService = webApiService;
        }
        private async void frmCategoryUpdate_Load(object sender, EventArgs e)
        {
            await CategoryList();
            if (cmbBoxCategorySelect.DataSource != null && Id != Guid.Empty)
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

                    HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("category/update", updateCategoryDTO);

                    await ResponseController.ErrorResponseController(response);

                    await CategoryList();
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
                GetCategoryDTO result = await _categoryHelper.GetByCategoryIdAsync((Guid)cmbBoxCategorySelect.SelectedValue);

                txtCategoryName.Text = result.CategoryName;
            }
        }
    }
}
