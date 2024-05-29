﻿using Krop.Business.Features.Brands.Dtos;
using Krop.Business.Features.Categories.Dtos;
using Krop.Business.Features.Products.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.BrandHelpers;
using Krop.WinForms.HelpersClass.CategoryHelpers;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Products
{
    public partial class frmProductAdd : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IBrandHelper _brandHelper;
        private readonly ICategoryHelper _categoryHelper;

        public frmProductAdd(IWebApiService webApiService, IBrandHelper brandHelper, ICategoryHelper categoryHelper)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _brandHelper = brandHelper;
            _categoryHelper = categoryHelper;

            txtCriticalQuantity.MaxLength = 10;
        }

        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            CategoryList();
            BrandList();
        }

        private void CategoryList()
        {
            List<GetCategoryComboBoxDTO> result = _categoryHelper.GetAllComboBoxAsync();
            if (result is null)
                return;

            cmbBoxCategory.DataSource = null;

            cmbBoxCategory.DisplayMember = "CategoryName";
            cmbBoxCategory.ValueMember = "Id";

            cmbBoxCategory.DataSource = result;
        }
        private void BrandList()
        {
            List<GetBrandComboBoxDTO> result = _brandHelper.GetAllComboBoxAsync();
            if (result is null)
                return;

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

        private void bttnProductAdd_Click(object sender, EventArgs e)
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

                HttpResponseMessage response = _webApiService.httpClient.PostAsJsonAsync("product/Add", createProductDTO).Result;

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