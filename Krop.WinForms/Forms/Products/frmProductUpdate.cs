using Krop.Business.Features.Brands.Dtos;
using Krop.Business.Features.Categories.Dtos;
using Krop.Business.Features.Products.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Utilits.Result;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.BrandHelpers;
using Krop.WinForms.HelpersClass.CategoryHelpers;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using Krop.WinForms.HelpersClass.ProductHelpers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Krop.WinForms.Products
{
    public partial class frmProductUpdate : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IProductHelper _productHelper;
        private readonly ICategoryHelper _categoryHelper;
        private readonly IBrandHelper _brandHelper;
        public Guid Id;

        public frmProductUpdate(IWebApiService webApiService, IProductHelper productHelper, ICategoryHelper categoryHelper, IBrandHelper brandHelper)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _productHelper = productHelper;
            _categoryHelper = categoryHelper;
            _brandHelper = brandHelper;
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
            List<GetProductComboBoxDTO> result = await _productHelper.GetAllComboBoxAsync();

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
        private async Task CategoryList()
        {
            List<GetCategoryComboBoxDTO> result = await _categoryHelper.GetAllComboBoxAsync();

            cmbBoxCategory.DataSource = null;
            cmbBoxCategory.DataSource = result;

            cmbBoxCategory.DisplayMember = "CategoryName";
            cmbBoxCategory.ValueMember = "Id";
        }
        private async Task BrandList()
        {
            List<GetBrandComboBoxDTO> result = await _brandHelper.GetAllComboBoxAsync();

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

                GetProductDTO result = await _productHelper.GetProductByIdAsync((Guid)cmbBoxProductNameSelect.SelectedValue);

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

                    HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("product/update", updateProductDTO);

                    await ResponseController.ErrorResponseController(response);

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
