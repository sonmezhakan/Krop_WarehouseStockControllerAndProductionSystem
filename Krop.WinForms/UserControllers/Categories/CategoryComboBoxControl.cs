using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Categroies;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.UserControllers.Categories
{
    public partial class CategoryComboBoxControl : UserControl
    {
        public CategoryComboBoxControl()
        {
            InitializeComponent();
        }
        public async Task CategoryList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("category/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetCategoryComboBoxDTO>>(response);

            cmbBoxCategorySelect.DataSource = null;

            cmbBoxCategorySelect.DisplayMember = "CategoryName";
            cmbBoxCategorySelect.ValueMember = "Id";

            cmbBoxCategorySelect.DataSource = result is not null ? result.Data : null;
            cmbBoxCategorySelect.SelectedIndex = -1;
        }
        public void CategorySelect(Guid id)
        {
            if (cmbBoxCategorySelect.DataSource != null && id != Guid.Empty)
                cmbBoxCategorySelect.SelectedValue = id;
        }
        public ComboBox CategoryComboBox
        {
            get { return cmbBoxCategorySelect; }
        }
    }
}
