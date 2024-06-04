using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Products;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Products
{
    public partial class frmProductDelete : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmProductDelete(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmProductDelete_Load(object sender, EventArgs e)
        {
            await ProductList();
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

            var result = await ResponseController.SuccessDataResponseController<List<GetProductComboBoxDTO>>(response);

            if (result is not null)
            {
                await ProductNameList(result.Data);
                await ProductCodeList(result.Data);
            }
        }
        private async Task ProductNameList(List<GetProductComboBoxDTO> getProductComboBoxDTOs)
        {
            cmbBoxProductNameSelect.DataSource = null;
            cmbBoxProductNameSelect.DisplayMember = "ProductName";
            cmbBoxProductNameSelect.ValueMember = "Id";

            cmbBoxProductNameSelect.SelectedIndexChanged -= cmbBoxProductNameSelect_SelectedIndexChanged;
            cmbBoxProductNameSelect.DataSource = getProductComboBoxDTOs;
            cmbBoxProductNameSelect.SelectedIndex = -1;
            cmbBoxProductNameSelect.SelectedIndexChanged += cmbBoxProductNameSelect_SelectedIndexChanged;
        }
        private async Task ProductCodeList(List<GetProductComboBoxDTO> getProductComboBoxDTOs)
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
            if (cmbBoxProductNameSelect.SelectedValue is not null && cmbBoxProductCodeSelect.SelectedValue is not null &&
                cmbBoxProductNameSelect.SelectedValue == cmbBoxProductCodeSelect.SelectedValue)
            {
                if (DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"product/delete/{cmbBoxProductNameSelect.SelectedValue}");

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                    await ProductList();
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
