using Krop.Business.Features.Products.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using Krop.WinForms.HelpersClass.ProductHelpers;

namespace Krop.WinForms.Products
{
    public partial class frmProductDelete : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IProductHelper _productHelper;
        public Guid Id;

        public frmProductDelete(IWebApiService webApiService, IProductHelper productHelper)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _productHelper = productHelper;
        }

        private void frmProductDelete_Load(object sender, EventArgs e)
        {
            ProductList();
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
                cmbBoxProductCodeSelect.SelectedValue = cmbBoxProductNameSelect.SelectedValue;
        }

        private void cmbBoxProductCodeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxProductCodeSelect.SelectedValue is not null && cmbBoxProductNameSelect.DataSource is not null)
                cmbBoxProductNameSelect.SelectedValue = cmbBoxProductCodeSelect.SelectedValue;
        }

        private void bttnProductDelete_Click(object sender, EventArgs e)
        {
            if (cmbBoxProductNameSelect.SelectedValue is null && cmbBoxProductCodeSelect.SelectedValue is null &&
                cmbBoxProductNameSelect.SelectedValue != cmbBoxProductCodeSelect.SelectedValue)
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if(DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
            {
                HttpResponseMessage response = _webApiService.httpClient.DeleteAsync($"product/delete/{cmbBoxProductNameSelect.SelectedValue}").Result;

                if (!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                ProductList();
            }
        }
    }
}
