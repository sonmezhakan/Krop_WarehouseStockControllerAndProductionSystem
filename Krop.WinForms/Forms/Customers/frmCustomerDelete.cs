using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Customers;
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
           await CustomerList();
            if (cmbBoxCustomerSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxCustomerSelect.SelectedValue = Id;
        }
        private async Task CustomerList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("customer/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetCustomerComboBoxDTO>>(response);

            cmbBoxCustomerSelect.DataSource = null;

            cmbBoxCustomerSelect.DisplayMember = "CompanyName";
            cmbBoxCustomerSelect.ValueMember = "Id";

            cmbBoxCustomerSelect.SelectedIndexChanged -= CmbBoxCustomerSelect_SelectedIndexChanged;
            cmbBoxCustomerSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxCustomerSelect.SelectedIndex = -1;
            cmbBoxCustomerSelect.SelectedIndexChanged += CmbBoxCustomerSelect_SelectedIndexChanged;
        }

        private void CmbBoxCustomerSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {

        }

        private async void bttnCustomerDelete_Click(object sender, EventArgs e)
        {
            if(cmbBoxCustomerSelect.SelectedValue != null)
            {
                if(DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response =  await _webApiService.httpClient.DeleteAsync($"customer/delete/{cmbBoxCustomerSelect.SelectedValue}");

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                   await CustomerList();
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçin Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
