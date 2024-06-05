using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Brands;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.UserControllers.Brands
{
    public partial class BrandComboBoxControl : UserControl
    {
        public BrandComboBoxControl()
        {
            InitializeComponent();
        }

        private void BrandComboBoxControl_Load(object sender, EventArgs e)
        {

        }
        public async Task BrandList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("brand/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetBrandComboBoxDTO>>(response);

            cmbBoxBrandSelect.DataSource = null;

            cmbBoxBrandSelect.DisplayMember = "BrandName";
            cmbBoxBrandSelect.ValueMember = "Id";

            cmbBoxBrandSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxBrandSelect.SelectedIndex = -1;
        }
        public void BrandSelect(Guid id)
        {
            if (cmbBoxBrandSelect.DataSource != null && id != Guid.Empty)
                cmbBoxBrandSelect.SelectedValue = id;
        }
        public ComboBox BrandComboBox
        {
            get { return cmbBoxBrandSelect; }
        }
    }
}
