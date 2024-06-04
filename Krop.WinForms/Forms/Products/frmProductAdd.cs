using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Brands;
using Krop.DTO.Dtos.Categroies;
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
           await CategoryList();
           await BrandList();
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
            cmbBoxBrand.SelectedValue = -1;
        }

        private void cmbBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbBoxBrand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void bttnProductAdd_Click(object sender, EventArgs e)
        {
            if(cmbBoxCategory.SelectedValue is not null && cmbBoxBrand.SelectedValue is not null)
            {
                CreateProductDTO createProductDTO = new CreateProductDTO
                {
                    BrandId = (Guid)cmbBoxBrand.SelectedValue,
                    CategoryId = (Guid)cmbBoxCategory.SelectedValue,
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
