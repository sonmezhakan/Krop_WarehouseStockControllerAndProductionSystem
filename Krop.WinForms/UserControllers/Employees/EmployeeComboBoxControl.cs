using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Employees;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.UserControllers.Employees
{
    public partial class EmployeeComboBoxControl : UserControl
    {
        public EmployeeComboBoxControl()
        {
            InitializeComponent();
        }

        public async Task EmployeeList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("employee/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetEmployeeComboBoxDTO>>(response);

            cmbBoxAppUserSelect.DataSource = null;
            cmbBoxAppUserSelect.DisplayMember = "UserName";
            cmbBoxAppUserSelect.ValueMember = "AppUserId";

            cmbBoxAppUserSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxAppUserSelect.SelectedValue = -1;
        }
        public void EmployeeSelect(Guid id)
        {
            if (cmbBoxAppUserSelect.DataSource != null && id != Guid.Empty)
                cmbBoxAppUserSelect.SelectedValue = id;
        }
        public ComboBox EmployeeComboBox
        {
            get { return cmbBoxAppUserSelect; }
        }
    }
}
