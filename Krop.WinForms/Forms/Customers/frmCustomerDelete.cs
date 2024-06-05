using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Customers
{
    public partial class frmCustomerDelete : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmCustomerDelete(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmCustomerDelete_Load(object sender, EventArgs e)
        {
            await customerComboBoxControl.CustomerList(_webApiService);
            customerComboBoxControl.CustomerSelect(Id);
        }
        private async void bttnCustomerDelete_Click(object sender, EventArgs e)
        {
            if (customerComboBoxControl.CustomerComboBox.SelectedValue != null)
            {
                if (DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"customer/delete/{(Guid)customerComboBoxControl.CustomerComboBox.SelectedValue}");

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                    await customerComboBoxControl.CustomerList(_webApiService);
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçin Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
