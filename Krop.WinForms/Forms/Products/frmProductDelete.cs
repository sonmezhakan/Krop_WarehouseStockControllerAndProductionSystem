using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Products;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Products
{
    public partial class frmProductDelete : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmProductDelete(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmProductDelete_Load(object sender, EventArgs e)
        {
            await productComboBoxControl.ProductList(_webApiService);
            productComboBoxControl.ProductNameComboBox.SelectedIndexChanged += cmbBoxProductNameSelect_SelectedIndexChanged;
            productComboBoxControl.ProductCodeComboBox.SelectedIndexChanged += cmbBoxProductCodeSelect_SelectedIndexChanged;
            productComboBoxControl.ProductSelect(Id);
        }

        
        private void cmbBoxProductNameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productComboBoxControl.ProductNameComboBox.SelectedValue is not null && productComboBoxControl.ProductCodeComboBox.DataSource is not null)
                productComboBoxControl.ProductCodeComboBox.SelectedValue = productComboBoxControl.ProductNameComboBox.SelectedValue;
        }

        private void cmbBoxProductCodeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productComboBoxControl.ProductCodeComboBox.SelectedValue is not null && productComboBoxControl.ProductNameComboBox.DataSource is not null)
                productComboBoxControl.ProductNameComboBox.SelectedValue = productComboBoxControl.ProductCodeComboBox.SelectedValue;
        }

        private async void bttnProductDelete_Click(object sender, EventArgs e)
        {
            if (productComboBoxControl.ProductNameComboBox.SelectedValue is not null && productComboBoxControl.ProductCodeComboBox.SelectedValue is not null &&
                productComboBoxControl.ProductNameComboBox.SelectedValue == productComboBoxControl.ProductNameComboBox.SelectedValue)
            {
                if (DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"product/delete/{(Guid)productComboBoxControl.ProductNameComboBox.SelectedValue}");

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                    await productComboBoxControl.ProductList(_webApiService);
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
