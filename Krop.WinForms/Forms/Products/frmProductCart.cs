using Krop.Common.Helpers.WebApiRequests.Brands;
using Krop.Common.Helpers.WebApiRequests.Categories;
using Krop.Common.Helpers.WebApiRequests.Products;
using Krop.DTO.Dtos.Products;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.Products
{
    public partial class frmProductCart : Form
    {
        public Guid Id;
        private readonly IProductRequest _productRequest;

        public frmProductCart(IProductRequest productRequest)
        {
            InitializeComponent();
            _productRequest = productRequest;
        }

        private void frmProductCart_Load(object sender, EventArgs e)
        {
            ProductList();
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

            cmbBoxProductNameSelect.DataSource = null;
            cmbBoxProductCodeSelect.DataSource = null;

            cmbBoxProductNameSelect.DisplayMember = "ProductName";
            cmbBoxProductNameSelect.ValueMember = "Id";

            cmbBoxProductCodeSelect.DisplayMember = "ProductCode";
            cmbBoxProductCodeSelect.ValueMember = "Id";

            cmbBoxProductNameSelect.SelectedIndexChanged -= cmbBoxProductNameSelect_SelectedIndexChanged;
            cmbBoxProductCodeSelect.SelectedIndexChanged -= cmbBoxProductCodeSelect_SelectedIndexChanged;

            cmbBoxProductNameSelect.DataSource = result.Select(x => new GetProductComboBoxDTO { Id = x.Id, ProductName = x.ProductName }).ToList();
            cmbBoxProductCodeSelect.DataSource = result.Select(x => new GetProductComboBoxDTO { Id = x.Id, ProductCode = x.ProductCode }).ToList();

            cmbBoxProductNameSelect.SelectedIndex = -1;
            cmbBoxProductCodeSelect.SelectedIndex = -1;

            cmbBoxProductNameSelect.SelectedIndexChanged += cmbBoxProductNameSelect_SelectedIndexChanged;
            cmbBoxProductCodeSelect.SelectedIndexChanged += cmbBoxProductCodeSelect_SelectedIndexChanged;
        }
        private async void cmbBoxProductNameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxProductNameSelect.SelectedValue is not null && cmbBoxProductCodeSelect.DataSource is not null)
            {
                cmbBoxProductCodeSelect.SelectedValue = cmbBoxProductNameSelect.SelectedValue;

                HttpResponseMessage response = await _productRequest.GetByIdAsync((Guid)cmbBoxProductNameSelect.SelectedValue);
                if (!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                var result = ResponseController.SuccessDataResponseController<GetProductCartDTO>(response).Data;

                txtUnitPrice.Text = result.UnitPrice.ToString();
                txtCriticalQuantity.Text = result.CriticalStock.ToString();
                txtDescription.Text = result.Description;
                txtBrandName.Text = result.BrandName;
                txtCategoryName.Text = result.CategoryName;
            }
        }

        private void cmbBoxProductCodeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxProductCodeSelect.SelectedValue is not null && cmbBoxProductNameSelect.DataSource is not null)
            {
                cmbBoxProductNameSelect.SelectedValue = cmbBoxProductCodeSelect.SelectedValue;
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
