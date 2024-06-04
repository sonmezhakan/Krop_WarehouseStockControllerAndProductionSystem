using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Suppliers;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Suppliers
{
    public partial class frmSupplierDelete : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmSupplierDelete(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmSupplierDelete_Load(object sender, EventArgs e)
        {
           await SupplierList();
            if (cmbBoxSupplierSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxSupplierSelect.SelectedValue = Id;
        }

        private async Task SupplierList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("supplier/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result =await ResponseController.SuccessDataResponseController<List<GetSupplierComboBoxDTO>>(response);

            cmbBoxSupplierSelect.DataSource = null;

            cmbBoxSupplierSelect.DisplayMember = "CompanyName";
            cmbBoxSupplierSelect.ValueMember = "Id";

            cmbBoxSupplierSelect.SelectedIndexChanged -= CmbBoxSupplierSelect_SelectedIndexChanged;
            cmbBoxSupplierSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxSupplierSelect.SelectedIndex = -1;
            cmbBoxSupplierSelect.SelectedIndexChanged += CmbBoxSupplierSelect_SelectedIndexChanged;
        }

        private void CmbBoxSupplierSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {

        }
        private async void bttnSupplierDelete_Click(object sender, EventArgs e)
        {
            if (cmbBoxSupplierSelect.SelectedValue != null)
            {
               if(DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"supplier/delete/{cmbBoxSupplierSelect.SelectedValue}");

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                   await SupplierList();
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçin Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
