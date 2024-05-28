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
        private void frmCategoryUpdate_Load(object sender, EventArgs e)
        {
            CategoryList();
            if (cmbBoxCategorySelect.DataSource != null && Id != Guid.Empty)
                cmbBoxCategorySelect.SelectedValue = Id;
        }
        private void CategoryList()
        {
            List<GetCategoryComboBoxDTO> result = _categoryHelper.GetAllComboBoxAsync();
            if (result is null)
                return;

            cmbBoxCategorySelect.DataSource = null;

            cmbBoxCategorySelect.DisplayMember = "CategoryName";
            cmbBoxCategorySelect.ValueMember = "Id";

            cmbBoxCategorySelect.SelectedIndexChanged -= cmbBoxCategorySelect_SelectedIndexChanged; 
            cmbBoxCategorySelect.DataSource = result;
            cmbBoxCategorySelect.SelectedIndex = -1;
            cmbBoxCategorySelect.SelectedIndexChanged += cmbBoxCategorySelect_SelectedIndexChanged;
        }

        private void bttnCategoryUpdate_Click(object sender, EventArgs e)
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

                    HttpResponseMessage response = _webApiService.httpClient.PutAsJsonAsync("category/update", updateCategoryDTO).Result;

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

        private void cmbBoxCategorySelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxCategorySelect.SelectedValue is not null)
            {
                GetCategoryDTO result = _categoryHelper.GetByCategoryIdAsync((Guid)cmbBoxCategorySelect.SelectedValue);
                if (result is null)
                    return;

                txtCategoryName.Text = result.CategoryName;
            }
        }
    }
}
