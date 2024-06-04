using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Products;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.Products
{
    public partial class frmProductCart : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmProductCart(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmProductCart_Load(object sender, EventArgs e)
        {
           await ProductList();
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

            cmbBoxProductNameSelect.DataSource = null;
            cmbBoxProductCodeSelect.DataSource = null;

            cmbBoxProductNameSelect.DisplayMember = "ProductName";
            cmbBoxProductNameSelect.ValueMember = "Id";

            cmbBoxProductCodeSelect.DisplayMember = "ProductCode";
            cmbBoxProductCodeSelect.ValueMember = "Id";

            cmbBoxProductNameSelect.SelectedIndexChanged -= cmbBoxProductNameSelect_SelectedIndexChanged;
            cmbBoxProductCodeSelect.SelectedIndexChanged -= cmbBoxProductCodeSelect_SelectedIndexChanged;

            cmbBoxProductNameSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxProductCodeSelect.DataSource = result  is not null ? result.Data : null;

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

                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"product/GetByIdCart/{cmbBoxProductNameSelect.SelectedValue}");
                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                var result =await ResponseController.SuccessDataResponseController<GetProductCartDTO>(response);

                if(result is not null)
                {
                    txtUnitPrice.Text = result.Data.UnitPrice.ToString();
                    txtCriticalQuantity.Text = result.Data.CriticalStock.ToString();
                    txtDescription.Text = result.Data.Description;
                    txtBrandName.Text = result.Data.BrandName;
                    txtCategoryName.Text = result.Data.CategoryName;
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
