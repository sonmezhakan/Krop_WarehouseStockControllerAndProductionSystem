using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Products;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Products
{
    public partial class frmProductUpdate : Form
    {

        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmProductUpdate(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmProductUpdate_Load(object sender, EventArgs e)
        {
            txtCriticalQuantity.MaxLength = 10;
            await productComboBoxControl.ProductList(_webApiService);
            productComboBoxControl.ProductNameComboBox.SelectedIndexChanged += cmbBoxProductNameSelect_SelectedIndexChanged;
            productComboBoxControl.ProductCodeComboBox.SelectedIndexChanged += cmbBoxProductCodeSelect_SelectedIndexChanged;
            productComboBoxControl.ProductSelect(Id);

            await categoryComboBoxControl.CategoryList(_webApiService);
            await brandComboBoxControl.BrandList(_webApiService);
        }
        private async void cmbBoxProductNameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productComboBoxControl.ProductNameComboBox.SelectedValue is not null && productComboBoxControl.ProductCodeComboBox.DataSource is not null)
            {
                productComboBoxControl.ProductCodeComboBox.SelectedValue = productComboBoxControl.ProductNameComboBox.SelectedValue;

                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"product/GetById/{(Guid)productComboBoxControl.ProductNameComboBox.SelectedValue}");
                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                var result = await ResponseController.SuccessDataResponseController<GetProductDTO>(response);

                if(result is not null)
                {
                    txtProductName.Text = result.Data.ProductName;
                    txtProductCode.Text = result.Data.ProductCode;
                    txtUnitPrice.Text = result.Data.UnitPrice.ToString();
                    txtCriticalQuantity.Text = result.Data.CriticalStock.ToString();
                    txtDescription.Text = result.Data.Description;

                    if (result.Data.BrandId != null)
                        brandComboBoxControl.BrandComboBox.SelectedValue = result.Data.BrandId;

                    if (result.Data.BrandId != null)
                        categoryComboBoxControl.CategoryComboBox.SelectedValue = result.Data.CategoryId;
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

        private async void bttnProductUpdate_Click(object sender, EventArgs e)
        {
            if (productComboBoxControl.ProductNameComboBox.SelectedValue is not null && productComboBoxControl.ProductCodeComboBox.SelectedValue is not null &&
                productComboBoxControl.ProductNameComboBox.SelectedValue.ToString() == productComboBoxControl.ProductCodeComboBox.SelectedValue.ToString())
            {
                if(categoryComboBoxControl.CategoryComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Kategori Seçimi Hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(brandComboBoxControl.BrandComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Marka Seçimi Hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    UpdateProductDTO updateProductDTO = new UpdateProductDTO
                    {
                        Id = (Guid)productComboBoxControl.ProductNameComboBox.SelectedValue,
                        ProductName = txtProductName.Text,
                        ProductCode = txtProductCode.Text,
                        UnitPrice = decimal.Parse(string.IsNullOrEmpty(txtUnitPrice.Text) ? "0" : txtUnitPrice.Text),
                        CriticalStock = int.Parse(string.IsNullOrEmpty(txtCriticalQuantity.Text) ? "0" : txtCriticalQuantity.Text),
                        Description = txtDescription.Text,
                        CategoryId = (Guid)categoryComboBoxControl.CategoryComboBox.SelectedValue,
                        BrandId = (Guid)brandComboBoxControl.BrandComboBox.SelectedValue
                    };

                    HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("product/update", updateProductDTO);

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

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxDecimalKeyPress(sender, e);
        }

        private void txtUnitPrice_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBoxHelper.TextBoxDecimalValidating(txtUnitPrice, e);
        }

        private void txtCriticalQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private void txtCriticalQuantity_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBoxHelper.TextBoxInt32Validating(txtCriticalQuantity, e);
        }
    }
}
