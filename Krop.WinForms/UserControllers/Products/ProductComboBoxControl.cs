using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Products;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.UserControllers.Products
{
    public partial class ProductComboBoxControl : UserControl
    {
        public ProductComboBoxControl()
        {
            InitializeComponent();
        }

        public async Task ProductList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("product/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetProductComboBoxDTO>>(response);

            await ProductNameList(result.Data);
            await ProductCodeList(result.Data);
        }
        private async Task ProductNameList(List<GetProductComboBoxDTO> products)
        {
            cmbBoxProductNameSelect.DataSource = null;

            cmbBoxProductNameSelect.DisplayMember = "ProductName";
            cmbBoxProductNameSelect.ValueMember = "Id";

            cmbBoxProductNameSelect.DataSource = products is not null ? products : null;
            cmbBoxProductNameSelect.SelectedIndex = -1;
        }
        private async Task ProductCodeList(List<GetProductComboBoxDTO> products)
        {
            cmbBoxProductCodeSelect.DataSource = null;

            cmbBoxProductCodeSelect.DisplayMember = "ProductCode";
            cmbBoxProductCodeSelect.ValueMember = "Id";

            cmbBoxProductCodeSelect.DataSource = products is not null ? products : null;
            cmbBoxProductCodeSelect.SelectedIndex = -1;
        }
        public void ProductSelect(Guid id)
        {
            if (cmbBoxProductNameSelect.DataSource != null &&id != Guid.Empty)
                cmbBoxProductNameSelect.SelectedValue = id;
        }
        public ComboBox ProductNameComboBox
        {
            get { return cmbBoxProductNameSelect; }
        }
        public ComboBox ProductCodeComboBox
        {
            get { return cmbBoxProductCodeSelect; }
        }
    }
}
