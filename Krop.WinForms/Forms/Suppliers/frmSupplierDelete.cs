using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Suppliers;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using Krop.WinForms.UserControllers.Suppliers;

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
            await supplierComboBoxControl.SupplierList(_webApiService);
            supplierComboBoxControl.SupplierSelect(Id);
        }
        private async void bttnSupplierDelete_Click(object sender, EventArgs e)
        {
            if (supplierComboBoxControl.SupplierComboBox.SelectedValue != null)
            {
               if(DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"supplier/delete/{(Guid)supplierComboBoxControl.SupplierComboBox.SelectedValue}");

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                    await supplierComboBoxControl.SupplierList(_webApiService);
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçin Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
