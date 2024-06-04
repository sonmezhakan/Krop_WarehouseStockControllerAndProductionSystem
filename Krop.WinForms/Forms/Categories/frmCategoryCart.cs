using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Categroies;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryCart : Form
    {

        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmCategoryCart(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }
        private async void frmCategoryCart_Load(object sender, EventArgs e)
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

            cmbBoxCategorySelect.SelectedIndexChanged -= cmbCategorySelect_SelectedIndexChanged;
            cmbBoxCategorySelect.DataSource = result is not null ? result.Data : null;
            cmbBoxCategorySelect.SelectedIndex = -1;
            cmbBoxCategorySelect.SelectedIndexChanged += cmbCategorySelect_SelectedIndexChanged;
        }

        private void cmbCategorySelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
