using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Employees;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.Forms.Employees
{
    public partial class frmEmployeeCart : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmEmployeeCart(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmEmployeeCart_Load(object sender, EventArgs e)
        {
            await employeeComboBoxControl1.EmployeeList(_webApiService);
            employeeComboBoxControl1.EmployeeComboBox.SelectedIndexChanged += CmbBoxAppUserSelect_SelectedIndexChanged;
            employeeComboBoxControl1.EmployeeSelect(Id);
        }
        

        private async void CmbBoxAppUserSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (employeeComboBoxControl1.EmployeeComboBox.SelectedValue is not null)
            {
                HttpResponseMessage response =await _webApiService.httpClient.GetAsync($"employee/GetById/{(Guid)employeeComboBoxControl1.EmployeeComboBox.SelectedValue}");
                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                var result =await ResponseController.SuccessDataResponseController<GetEmployeeCartDTO>(response);

                if(result is not null)
                {
                    txtDepartmentName.Text = result.Data.DepartmentName;
                    txtBranchName.Text = result.Data.BranchName;
                    txtSalary.Text = result.Data.Salary.ToString() + " ₺";
                    dateTimePickerStart.Value = result.Data.StartDateOfWork;
                    dateTimePickerEnd.Value = result.Data.EndDateOfWork == null || result.Data.EndDateOfWork == DateTime.MinValue ? DateTime.Now : result.Data.EndDateOfWork;
                    if (result.Data.WorkingStatu)
                        radioButtonActive.Checked = true;
                    else
                        radioButtonPassive.Checked = true;
                }
            }
        }
    }
}
