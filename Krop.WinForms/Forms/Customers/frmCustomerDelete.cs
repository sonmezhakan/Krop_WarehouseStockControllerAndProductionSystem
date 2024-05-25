using Krop.Business.Features.Customers.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.CustomerHelpers;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Customers
{
    public partial class frmCustomerDelete : Form
    {
        private readonly ICustomerHelper _customerHelper;
        private readonly IWebApiService _webApiService;
        public Guid Id;

        public frmCustomerDelete(ICustomerHelper customerHelper,IWebApiService webApiService)
        {
            InitializeComponent();
            _customerHelper = customerHelper;
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
            List<GetCustomerComboBoxDTO> customers = await _customerHelper.GetAllComboBoxAsync();

            cmbBoxCustomerSelect.DataSource = null;

            cmbBoxCustomerSelect.DisplayMember = "CompanyName";
            cmbBoxCustomerSelect.ValueMember = "Id";

            cmbBoxCustomerSelect.SelectedIndexChanged -= CmbBoxCustomerSelect_SelectedIndexChanged;
            cmbBoxCustomerSelect.DataSource = customers;
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
                    HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"customer/delete/{cmbBoxCustomerSelect.SelectedValue}");

                    await ResponseController.ErrorResponseController(response);

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
