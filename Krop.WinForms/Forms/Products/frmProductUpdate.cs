using Krop.Common.Helpers.WebApiRequests.Brands;
using Krop.Common.Helpers.WebApiRequests.Categories;
using Krop.Common.Helpers.WebApiRequests.Products;
using Krop.DTO.Dtos.Brands;
using Krop.DTO.Dtos.Categroies;
using Krop.DTO.Dtos.Products;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Products
{
    public partial class frmProductUpdate : Form
    {

        public Guid Id;
        private readonly IProductRequest _productRequest;
        private readonly IBrandRequest _brandRequest;
        private readonly ICategoryRequest _categoryRequest;

        public frmProductUpdate(IProductRequest productRequest,IBrandRequest brandRequest,ICategoryRequest categoryRequest)
        {
            InitializeComponent();
            _productRequest = productRequest;
            _brandRequest = brandRequest;
            _categoryRequest = categoryRequest;
        }

        private void frmProductUpdate_Load(object sender, EventArgs e)
        {
            ProductList();
            CategoryList();
            BrandList();
            txtCriticalQuantity.MaxLength = 10;
            if (cmbBoxProductNameSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxProductNameSelect.SelectedValue = Id;
        }
        private async void ProductList()
        {
            HttpResponseMessage response = await _productRequest.GetAllComboBoxAsync();
            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetProductComboBoxDTO>(response).Data;

            ProductNameList(result);
            ProductCodeList(result);
        }
        private void ProductNameList(List<GetProductComboBoxDTO> products)
        {
            cmbBoxProductNameSelect.DataSource = null; 
            
            cmbBoxProductNameSelect.DisplayMember = "ProductName";
            cmbBoxProductNameSelect.ValueMember = "Id";

            cmbBoxProductNameSelect.SelectedIndexChanged -= cmbBoxProductNameSelect_SelectedIndexChanged;
            
            cmbBoxProductNameSelect.DataSource = products.Select(x => new GetProductComboBoxDTO { Id = x.Id, ProductName = x.ProductName }).ToList();

            cmbBoxProductNameSelect.SelectedIndex = -1;

            cmbBoxProductNameSelect.SelectedIndexChanged += cmbBoxProductNameSelect_SelectedIndexChanged;
        }
        private void ProductCodeList(List<GetProductComboBoxDTO> products)
        {
            cmbBoxProductCodeSelect.DataSource = null;

            cmbBoxProductCodeSelect.DisplayMember = "ProductCode";
            cmbBoxProductCodeSelect.ValueMember = "Id";

            cmbBoxProductCodeSelect.SelectedIndexChanged -= cmbBoxProductCodeSelect_SelectedIndexChanged;

            cmbBoxProductCodeSelect.DataSource = products.Select(x => new GetProductComboBoxDTO { Id = x.Id, ProductCode = x.ProductCode }).ToList();

            cmbBoxProductCodeSelect.SelectedIndex = -1;

            cmbBoxProductCodeSelect.SelectedIndexChanged += cmbBoxProductCodeSelect_SelectedIndexChanged;
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
            cmbBoxCategory.DataSource = result;

            cmbBoxCategory.DisplayMember = "CategoryName";
            cmbBoxCategory.ValueMember = "Id";
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
            cmbBoxBrand.DataSource = result;

            cmbBoxBrand.DisplayMember = "BrandName";
            cmbBoxBrand.ValueMember = "Id";
        }

        private async void cmbBoxProductNameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxProductNameSelect.SelectedValue is not null && cmbBoxProductCodeSelect.DataSource is not null)
            {
                cmbBoxProductCodeSelect.SelectedValue = cmbBoxProductNameSelect.SelectedValue;

                HttpResponseMessage response = await _productRequest.GetByIdAsync((Guid)cmbBoxProductNameSelect.SelectedValue);
                if(!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                var result = ResponseController.SuccessDataResponseController<GetProductDTO>(response).Data;

                txtProductName.Text = result.ProductName;
                txtProductCode.Text = result.ProductCode;
                txtUnitPrice.Text = result.UnitPrice.ToString();
                txtCriticalQuantity.Text = result.CriticalStock.ToString();
                txtDescription.Text = result.Description;

                if (result.BrandId != null)
                    cmbBoxBrand.SelectedValue = result.BrandId;

                if (result.BrandId != null)
                    cmbBoxCategory.SelectedValue = result.CategoryId;
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

                    HttpResponseMessage response = await _productRequest.UpdateAsync(updateProductDTO);

                    if (!response.IsSuccessStatusCode)
                    {
                        ResponseController.ErrorResponseController(response);
                        return;
                    }

                    ProductList();
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
