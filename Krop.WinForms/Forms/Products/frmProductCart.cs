using Krop.Business.Features.Brands.Dtos;
using Krop.Business.Features.Categories.Dtos;
using Krop.Business.Features.Products.Dtos;
using Krop.WinForms.HelpersClass.BrandHelpers;
using Krop.WinForms.HelpersClass.CategoryHelpers;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using Krop.WinForms.HelpersClass.ProductHelpers;

namespace Krop.WinForms.Products
{
    public partial class frmProductCart : Form
    {
        private readonly IProductHelper _productHelper;
        private readonly IBrandHelper _brandHelper;
        private readonly ICategoryHelper _categoryHelper;
        public Guid Id;

        public frmProductCart(IProductHelper productHelper,IBrandHelper brandHelper,ICategoryHelper categoryHelper)
        {
            InitializeComponent();
            _productHelper = productHelper;
            _brandHelper = brandHelper;
            _categoryHelper = categoryHelper;
        }

        private async void frmProductCart_Load(object sender, EventArgs e)
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
            List<GetProductComboBoxDTO> result = await _productHelper.GetAllComboBoxAsync();

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
        private async Task CategoryList()
        {
            List<GetCategoryComboBoxDTO> result = await _categoryHelper.GetAllComboBoxAsync();

            cmbBoxCategory.DataSource = null;
            
            cmbBoxCategory.DisplayMember = "CategoryName";
            cmbBoxCategory.ValueMember = "Id";

            cmbBoxCategory.DataSource = result;
        }
        private async Task BrandList()
        {
            List<GetBrandComboBoxDTO> result = await _brandHelper.GetAllComboBoxAsync();

            cmbBoxBrand.DataSource = null;

            cmbBoxBrand.DisplayMember = "BrandName";
            cmbBoxBrand.ValueMember = "Id";

            cmbBoxBrand.DataSource = result;
        }

        private async void cmbBoxProductNameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxProductNameSelect.SelectedValue is not null && cmbBoxProductCodeSelect.DataSource is not null)
            {
                cmbBoxProductCodeSelect.SelectedValue = cmbBoxProductNameSelect.SelectedValue;

                GetProductDTO result = await _productHelper.GetProductByIdAsync((Guid)cmbBoxProductNameSelect.SelectedValue);

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
