using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Brands;
using Krop.DTO.Dtos.Categroies;
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
           await ProductList();
           await CategoryList();
           await BrandList();
            txtCriticalQuantity.MaxLength = 10;
            if (cmbBoxProductNameSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxProductNameSelect.SelectedValue = Id;
        }
        private async Task ProductList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("product/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result =await ResponseController.SuccessDataResponseController<List<GetProductComboBoxDTO>>(response);

           await ProductNameList(result.Data);
           await ProductCodeList(result.Data);
        }
        private async Task ProductNameList(List<GetProductComboBoxDTO> products)
        {
            cmbBoxProductNameSelect.DataSource = null; 
            
            cmbBoxProductNameSelect.DisplayMember = "ProductName";
            cmbBoxProductNameSelect.ValueMember = "Id";

            cmbBoxProductNameSelect.SelectedIndexChanged -= cmbBoxProductNameSelect_SelectedIndexChanged;

            cmbBoxProductNameSelect.DataSource = products is not null ? products : null;

            cmbBoxProductNameSelect.SelectedIndex = -1;

            cmbBoxProductNameSelect.SelectedIndexChanged += cmbBoxProductNameSelect_SelectedIndexChanged;
        }
        private async Task ProductCodeList(List<GetProductComboBoxDTO> products)
        {
            cmbBoxProductCodeSelect.DataSource = null;

            cmbBoxProductCodeSelect.DisplayMember = "ProductCode";
            cmbBoxProductCodeSelect.ValueMember = "Id";

            cmbBoxProductCodeSelect.SelectedIndexChanged -= cmbBoxProductCodeSelect_SelectedIndexChanged;

            cmbBoxProductCodeSelect.DataSource = products is not null ? products : null;

            cmbBoxProductCodeSelect.SelectedIndex = -1;

            cmbBoxProductCodeSelect.SelectedIndexChanged += cmbBoxProductCodeSelect_SelectedIndexChanged;
        }
        private async Task CategoryList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("category/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result =await ResponseController.SuccessDataResponseController<List<GetCategoryComboBoxDTO>>(response);

            cmbBoxCategory.DataSource = null;

            cmbBoxCategory.DisplayMember = "CategoryName";
            cmbBoxCategory.ValueMember = "Id";

            cmbBoxCategory.DataSource = result is not null ? result.Data : null;
            cmbBoxCategory.SelectedIndex = -1;
        }
        private async Task BrandList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("brand/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result =await ResponseController.SuccessDataResponseController<List<GetBrandComboBoxDTO>>(response);

            cmbBoxBrand.DataSource = null; 

            cmbBoxBrand.DisplayMember = "BrandName";
            cmbBoxBrand.ValueMember = "Id";

            cmbBoxBrand.DataSource = result is not null ? result.Data : null;
            cmbBoxBrand.SelectedIndex = -1;
        }

        private async void cmbBoxProductNameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxProductNameSelect.SelectedValue is not null && cmbBoxProductCodeSelect.DataSource is not null)
            {
                cmbBoxProductCodeSelect.SelectedValue = cmbBoxProductNameSelect.SelectedValue;

                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"product/GetById/{cmbBoxProductNameSelect.SelectedValue}");
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
                        cmbBoxBrand.SelectedValue = result.Data.BrandId;

                    if (result.Data.BrandId != null)
                        cmbBoxCategory.SelectedValue = result.Data.CategoryId;
                }
            }
        }

        private void cmbBoxProductCodeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxProductCodeSelect.SelectedValue is not null && cmbBoxProductNameSelect.DataSource is not null)
            {
                cmbBoxProductNameSelect.SelectedValue = cmbBoxProductCodeSelect.SelectedValue;
            }
        }

        private async void bttnProductUpdate_Click(object sender, EventArgs e)
        {
            if (cmbBoxProductNameSelect.SelectedValue is not null && cmbBoxProductCodeSelect.SelectedValue is not null &&
                cmbBoxProductNameSelect.SelectedValue.ToString() == cmbBoxProductCodeSelect.SelectedValue.ToString())
            {
                if(cmbBoxCategory.SelectedValue == null)
                {
                    MessageBox.Show("Kategori Seçimi Hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(cmbBoxBrand.SelectedValue == null)
                {
                    MessageBox.Show("Marka Seçimi Hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    UpdateProductDTO updateProductDTO = new UpdateProductDTO
                    {
                        Id = (Guid)cmbBoxProductNameSelect.SelectedValue,
                        ProductName = txtProductName.Text,
                        ProductCode = txtProductCode.Text,
                        UnitPrice = decimal.Parse(string.IsNullOrEmpty(txtUnitPrice.Text) ? "0" : txtUnitPrice.Text),
                        CriticalStock = int.Parse(string.IsNullOrEmpty(txtCriticalQuantity.Text) ? "0" : txtCriticalQuantity.Text),
                        Description = txtDescription.Text,
                        CategoryId = (Guid)cmbBoxCategory.SelectedValue,
                        BrandId = (Guid)cmbBoxBrand.SelectedValue
                    };

                    HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("product/update", updateProductDTO);

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                   await ProductList();
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
