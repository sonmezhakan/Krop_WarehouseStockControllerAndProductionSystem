using Krop.Common.Helpers.WebApiRequests.AppUsers;
using Krop.Common.Helpers.WebApiRequests.Branches;
using Krop.Common.Helpers.WebApiRequests.Departments;
using Krop.Common.Helpers.WebApiRequests.Employees;
using Krop.DTO.Dtos.Branches;
using Krop.DTO.Dtos.Departments;
using Krop.DTO.Dtos.Employees;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Forms.Employees
{
    public partial class frmEmployeeUpdate : Form
    {
        public Guid Id;
        private readonly IEmployeeRequest _employeeRequest;
        private readonly IAppUserRequest _appUserRequest;
        private readonly IBranchRequest _branchRequest;
        private readonly IDepartmentRequest _departmentRequest;

        public frmEmployeeUpdate(IEmployeeRequest employeeRequest,IAppUserRequest appUserRequest,IBranchRequest branchRequest,IDepartmentRequest departmentRequest)
        {
            InitializeComponent();
            _employeeRequest = employeeRequest;
            _appUserRequest = appUserRequest;
            _branchRequest = branchRequest;
            _departmentRequest = departmentRequest;
        }

        private  void frmEmployeeUpdate_Load(object sender, EventArgs e)
        {
            EmployeeList();
            DepartmentList();
            BranchList();
            if (cmbBoxAppUserSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxAppUserSelect.SelectedValue = Id;
        }
        private async void EmployeeList()
        {
            HttpResponseMessage response = await _employeeRequest.GetAllComboBoxAsync();
            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetEmployeeComboBoxDTO>(response).Data;

            cmbBoxAppUserSelect.DataSource = null;
            cmbBoxAppUserSelect.DisplayMember = "UserName";
            cmbBoxAppUserSelect.ValueMember = "AppUserId";

            cmbBoxAppUserSelect.SelectedIndexChanged -= CmbBoxAppUserSelect_SelectedIndexChanged;
            cmbBoxAppUserSelect.DataSource = result;
            cmbBoxAppUserSelect.SelectedValue = -1;
            cmbBoxAppUserSelect.SelectedIndexChanged += CmbBoxAppUserSelect_SelectedIndexChanged;
        }

        private async void CmbBoxAppUserSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxAppUserSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = await _employeeRequest.GetByIdAsync((Guid)cmbBoxAppUserSelect.SelectedValue);
                if (!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                var result = ResponseController.SuccessDataResponseController<GetEmployeeDTO>(response).Data;

                cmbBoxDepartmentSelect.SelectedValue = result.DepartmentId;
                cmbBoxBranchSelect.SelectedValue = result.BranchId;
                txtSalary.Text = result.Salary.ToString();
                dateTimePickerStart.Value = result.StartDateOfWork;
                dateTimePickerEnd.Value = result.EndDateOfWork == null || result.EndDateOfWork == DateTime.MinValue ? DateTime.Now : result.EndDateOfWork;
                if (result.WorkingStatu)
                    radioButtonActive.Checked = true;
                else
                    radioButtonActive.Checked = false;
            }
        }

        private async void DepartmentList()
        {
            HttpResponseMessage response = await _departmentRequest.GetAllComboBoxAsync();
            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetDepartmentComboBoxDTO>(response).Data;

            cmbBoxDepartmentSelect.DataSource = null;
            cmbBoxDepartmentSelect.DisplayMember = "DepartmentName";
            cmbBoxDepartmentSelect.ValueMember = "Id";

            cmbBoxDepartmentSelect.DataSource = result;
        }
        private async void BranchList()
        {
            HttpResponseMessage response = await _branchRequest.GetAllComboBoxAsync();
            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetBranchComboBoxDTO>(response).Data;

            cmbBoxBranchSelect.DataSource = null;
            cmbBoxBranchSelect.DisplayMember = "BranchName";
            cmbBoxBranchSelect.ValueMember = "Id";

            cmbBoxBranchSelect.DataSource = result;
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
            if(cmbBoxAppUserSelect.SelectedValue is not null && cmbBoxDepartmentSelect.SelectedValue is not null &&
                cmbBoxBranchSelect.SelectedValue is not null)
            {
                if(DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    UpdateEmployeeDTO updateEmployeeDTO = new UpdateEmployeeDTO
                    {
                        AppUserId = (Guid)cmbBoxAppUserSelect.SelectedValue,
                        DepartmentId = (Guid)cmbBoxDepartmentSelect.SelectedValue,
                        BranchId = (Guid)cmbBoxBranchSelect.SelectedValue,
                        StartDateOfWork = dateTimePickerStart.Value,
                        EndDateOfWork = checkDateTimePickerEndEnable.Checked ? dateTimePickerEnd.Value : null,
                        Salary = decimal.Parse(txtSalary.Text),
                        WorkingStatu = radioButtonActive.Checked ? true : false
                    };

                    HttpResponseMessage response = await _employeeRequest.UpdateAsync(updateEmployeeDTO);

                    if (!response.IsSuccessStatusCode)
                    {
                        ResponseController.ErrorResponseController(response);
                        return;
                    }

                    EmployeeList();
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
