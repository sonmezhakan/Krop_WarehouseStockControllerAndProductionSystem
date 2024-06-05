using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Customers;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.UserControllers.Customers
{
    public partial class CustomerComboBoxControl : UserControl
    {
        public CustomerComboBoxControl()
        {
            InitializeComponent();
        }

        private void CustomerComboBoxControl_Load(object sender, EventArgs e)
        {

        }
        public async Task CustomerList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("customer/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetCustomerComboBoxDTO>>(response);

            cmbBoxCustomerSelect.DataSource = null;

            cmbBoxCustomerSelect.DisplayMember = "CompanyName";
            cmbBoxCustomerSelect.ValueMember = "Id";

            cmbBoxCustomerSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxCustomerSelect.SelectedIndex = -1;
        }
        public void CustomerSelect(Guid id)
        {
            if (cmbBoxCustomerSelect.DataSource != null && id != Guid.Empty)
                cmbBoxCustomerSelect.SelectedValue = id;
        }
        public ComboBox CustomerComboBox
        {
            get { return cmbBoxCustomerSelect; }
        }
    }
}
