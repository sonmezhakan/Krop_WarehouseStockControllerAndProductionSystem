using Krop.Common.Helpers.WebApiRequests.Branches;
using Krop.Common.Helpers.WebApiRequests.Brands;
using Krop.Common.Helpers.WebApiRequests.Categories;
using Krop.Common.Helpers.WebApiRequests.Products;
using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.AppUsers;
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
        private readonly IBrandRequest _brandRequest;
        private readonly ICategoryRequest _categoryRequest;
        private readonly IProductRequest _productRequest;

        public frmProductAdd(IBrandRequest brandRequest,ICategoryRequest categoryRequest, IProductRequest productRequest)
        {
            InitializeComponent();

            txtCriticalQuantity.MaxLength = 10;
            _brandRequest = brandRequest;
            _categoryRequest = categoryRequest;
            _productRequest = productRequest;
        }

        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            CategoryList();
            BrandList();
        }

        private async void CategoryList()
        {
            HttpResponseMessage response = await _categoryRequest.GetAllComboBoxAsync();
            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetCategoryComboBoxDTO>(response).Data;

            cmbBoxCategory.DataSource = null;

            cmbBoxCategory.DisplayMember = "CategoryName";
            cmbBoxCategory.ValueMember = "Id";

            cmbBoxCategory.DataSource = result;
        }
        private async void BrandList()
        {
            HttpResponseMessage response = await _brandRequest.GetAllComboBoxAsync();
            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetBrandComboBoxDTO>(response).Data;

            cmbBoxBrand.DataSource = null;
            
            cmbBoxBrand.DisplayMember = "BrandName";
            cmbBoxBrand.ValueMember = "Id";

            cmbBoxBrand.DataSource = result;
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

                HttpResponseMessage response = await _productRequest.AddAsync(createProductDTO);

                if (!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
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
