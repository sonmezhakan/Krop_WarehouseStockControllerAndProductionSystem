using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Products;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.Products
{
    public partial class frmProductCart : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmProductCart(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }
        private async void frmProductCart_Load(object sender, EventArgs e)
        {
            await productComboBoxControl.ProductList(_webApiService);
            productComboBoxControl.ProductNameComboBox.SelectedIndexChanged += cmbBoxProductNameSelect_SelectedIndexChanged;
            productComboBoxControl.ProductCodeComboBox.SelectedIndexChanged += cmbBoxProductCodeSelect_SelectedIndexChanged;
            productComboBoxControl.ProductSelect(Id);
        }
        private async void cmbBoxProductNameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productComboBoxControl.ProductNameComboBox.SelectedValue is not null && productComboBoxControl.ProductCodeComboBox.DataSource is not null)
            {
                productComboBoxControl.ProductCodeComboBox.SelectedValue = productComboBoxControl.ProductNameComboBox.SelectedValue;

                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"product/GetByIdCart/{(Guid)productComboBoxControl.ProductNameComboBox.SelectedValue}");
                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                var result =await ResponseController.SuccessDataResponseController<GetProductCartDTO>(response);

                if(result is not null)
                {
                    txtUnitPrice.Text = result.Data.UnitPrice.ToString();
                    txtCriticalQuantity.Text = result.Data.CriticalStock.ToString();
                    txtDescription.Text = result.Data.Description;
                    txtBrandName.Text = result.Data.BrandName;
                    txtCategoryName.Text = result.Data.CategoryName;
                }
            }
        }

        private void cmbBoxProductCodeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productComboBoxControl.ProductCodeComboBox.SelectedValue is not null && productComboBoxControl.ProductNameComboBox.DataSource is not null)
            {
                productComboBoxControl.ProductNameComboBox.SelectedValue = productComboBoxControl.ProductCodeComboBox.SelectedValue;
            }
        }
        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtUnitPrice_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void txtCriticalQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtCriticalQuantity_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
