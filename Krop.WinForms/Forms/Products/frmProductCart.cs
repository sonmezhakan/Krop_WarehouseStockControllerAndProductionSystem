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

        private void frmProductCart_Load(object sender, EventArgs e)
        {
            ProductList();
            txtCriticalQuantity.MaxLength = 10;
            if (cmbBoxProductNameSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxProductNameSelect.SelectedValue = Id;
        }
        private void ProductList()
        {
            List<GetProductComboBoxDTO> result = _productHelper.GetAllComboBoxAsync();
            if (result is null)
                return;

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
        private void cmbBoxProductNameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxProductNameSelect.SelectedValue is not null && cmbBoxProductCodeSelect.DataSource is not null)
            {
                cmbBoxProductCodeSelect.SelectedValue = cmbBoxProductNameSelect.SelectedValue;

                GetProductCartDTO result = _productHelper.GetByProductIdCartAsync((Guid)cmbBoxProductNameSelect.SelectedValue);
                if (result is null)
                    return;

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
