using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Products;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Products
{
    public partial class frmProductAdd : Form
    {
        private readonly IWebApiService _webApiService;

        public frmProductAdd(IWebApiService webApiService)
        {
            InitializeComponent();
            txtCriticalQuantity.MaxLength = 10;
            _webApiService = webApiService;
        }

        private async void frmProductAdd_Load(object sender, EventArgs e)
        {
            await categoryComboBoxControl1.CategoryList(_webApiService);
            await brandComboBoxControl1.BrandList(_webApiService);
        }

        private async void bttnProductAdd_Click(object sender, EventArgs e)
        {
            if(categoryComboBoxControl1.CategoryComboBox.SelectedValue is not null && brandComboBoxControl1.BrandComboBox.SelectedValue is not null)
            {
                CreateProductDTO createProductDTO = new CreateProductDTO
                {
                    BrandId = (Guid)brandComboBoxControl1.BrandComboBox.SelectedValue,
                    CategoryId = (Guid)categoryComboBoxControl1.CategoryComboBox.SelectedValue,
                    ProductName = txtProductName.Text,
                    ProductCode = txtProductCode.Text,
                    UnitPrice = decimal.Parse(string.IsNullOrEmpty(txtUnitPrice.Text) ? "0" : txtUnitPrice.Text),
                    CriticalStock = int.Parse(string.IsNullOrEmpty(txtCriticalQuantity.Text) ? "0" : txtCriticalQuantity.Text),
                    Description = txtDescription.Text,
                };

                HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("product/Add", createProductDTO);

                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Kategori ve Marka Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxDecimalKeyPress(sender, e);
        }

        private void txtUnitPrice_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBoxHelper.TextBoxDecimalValidating(txtUnitPrice,e);
        }

        private void txtCriticalQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender,e);
        }

        private void txtCriticalQuantity_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBoxHelper.TextBoxInt32Validating(txtCriticalQuantity,e);
        }
    }
}
