using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Branches;
using Krop.DTO.Dtos.Departments;
using Krop.DTO.Dtos.Employees;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using Krop.WinForms.UserControllers.Branches;
using Krop.WinForms.UserControllers.Departments;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.Employees
{
    public partial class frmEmployeeUpdate : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmEmployeeUpdate(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private  async void frmEmployeeUpdate_Load(object sender, EventArgs e)
        {
            await employeeComboBoxControl.EmployeeList(_webApiService);
            employeeComboBoxControl.EmployeeComboBox.SelectedIndexChanged += CmbBoxAppUserSelect_SelectedIndexChanged;
            employeeComboBoxControl.EmployeeSelect(Id);
            await departmentComboBoxControl.DepartmentList(_webApiService);
            await branchComboBoxControl.BranchList(_webApiService);
        }
        
        private async void CmbBoxAppUserSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (employeeComboBoxControl.EmployeeComboBox.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"employee/GetById/{(Guid)employeeComboBoxControl.EmployeeComboBox.SelectedValue}");
                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                var result =await ResponseController.SuccessDataResponseController<GetEmployeeDTO>(response);

                if (result is not null)
                {
                    departmentComboBoxControl.DepartmentComboBox.SelectedValue = result.Data.DepartmentId;
                    branchComboBoxControl.BranchComboBox.SelectedValue = result.Data.BranchId;
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
        private void checkDateTimePickerEndEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDateTimePickerEndEnable.Checked)
                dateTimePickerEnd.Enabled = true;
            else
                dateTimePickerEnd.Enabled = false;
        }

        private async void bttnUpdate_Click(object sender, EventArgs e)
        {
            if(employeeComboBoxControl.EmployeeComboBox.SelectedValue is not null && departmentComboBoxControl.DepartmentComboBox.SelectedValue is not null &&
                branchComboBoxControl.BranchComboBox.SelectedValue is not null)
            {
                if(DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    UpdateEmployeeDTO updateEmployeeDTO = new UpdateEmployeeDTO
                    {
                        AppUserId = (Guid)employeeComboBoxControl.EmployeeComboBox.SelectedValue,
                        DepartmentId = (Guid)departmentComboBoxControl.DepartmentComboBox.SelectedValue,
                        BranchId = (Guid)branchComboBoxControl.BranchComboBox.SelectedValue,
                        StartDateOfWork = dateTimePickerStart.Value,
                        EndDateOfWork = checkDateTimePickerEndEnable.Checked ? dateTimePickerEnd.Value : null,
                        Salary = decimal.Parse(txtSalary.Text),
                        WorkingStatu = radioButtonActive.Checked ? true : false
                    };

                    HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("employee/update", updateEmployeeDTO);

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                    await employeeComboBoxControl.EmployeeList(_webApiService);
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
