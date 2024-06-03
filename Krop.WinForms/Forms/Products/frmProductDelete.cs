using Krop.Common.Helpers.WebApiRequests.Products;
using Krop.DTO.Dtos.Products;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Products
{
    public partial class frmProductDelete : Form
    {
        public Guid Id;
        private readonly IProductRequest _productRequest;

        public frmProductDelete(IProductRequest productRequest)
        {
            InitializeComponent();
            _productRequest = productRequest;
        }

        private void frmProductDelete_Load(object sender, EventArgs e)
        {
            ProductList();
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
        private async void ProductNameList(List<GetProductComboBoxDTO> getProductComboBoxDTOs)
        {
            cmbBoxProductNameSelect.DataSource = null;
            cmbBoxProductNameSelect.DisplayMember = "ProductName";
            cmbBoxProductNameSelect.ValueMember = "Id";

            cmbBoxProductNameSelect.SelectedIndexChanged -= cmbBoxProductNameSelect_SelectedIndexChanged;
            cmbBoxProductNameSelect.DataSource =getProductComboBoxDTOs;
            cmbBoxProductNameSelect.SelectedIndex = -1;
            cmbBoxProductNameSelect.SelectedIndexChanged += cmbBoxProductNameSelect_SelectedIndexChanged;
        }
        private async void ProductCodeList(List<GetProductComboBoxDTO> getProductComboBoxDTOs)
        {
            cmbBoxProductCodeSelect.DataSource = null;
            cmbBoxProductCodeSelect.DisplayMember = "ProductCode";
            cmbBoxProductCodeSelect.ValueMember = "Id";

            cmbBoxProductCodeSelect.SelectedIndexChanged -= cmbBoxProductCodeSelect_SelectedIndexChanged;
            cmbBoxProductCodeSelect.DataSource = getProductComboBoxDTOs;
            cmbBoxProductCodeSelect.SelectedIndex = -1;
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

        private async void bttnProductDelete_Click(object sender, EventArgs e)
        {
            if (cmbBoxProductNameSelect.SelectedValue is null && cmbBoxProductCodeSelect.SelectedValue is null &&
                cmbBoxProductNameSelect.SelectedValue != cmbBoxProductCodeSelect.SelectedValue)
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if(DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
            {
                HttpResponseMessage response = await _productRequest.DeleteAsync((Guid)cmbBoxProductNameSelect.SelectedValue);

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
