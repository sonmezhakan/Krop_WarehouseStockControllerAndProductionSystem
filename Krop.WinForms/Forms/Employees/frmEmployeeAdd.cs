using Krop.Common.Helpers.WebApiRequests.AppUsers;
using Krop.Common.Helpers.WebApiRequests.Branches;
using Krop.Common.Helpers.WebApiRequests.Departments;
using Krop.Common.Helpers.WebApiRequests.Employees;
using Krop.DTO.Dtos.AppUsers;
using Krop.DTO.Dtos.Branches;
using Krop.DTO.Dtos.Departments;
using Krop.DTO.Dtos.Employees;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.Forms.Employees
{
    public partial class frmEmployeeAdd : Form
    {
        private readonly IDepartmentRequest _departmentRequest;
        private readonly IAppUserRequest _appUserRequest;
        private readonly IBranchRequest _branchRequest;
        private readonly IEmployeeRequest _employeeRequest;

        public frmEmployeeAdd(IDepartmentRequest departmentRequest,IAppUserRequest appUserRequest,IBranchRequest branchRequest,IEmployeeRequest employeeRequest)
        {
            InitializeComponent();
            _departmentRequest = departmentRequest;
            _appUserRequest = appUserRequest;
            _branchRequest = branchRequest;
            _employeeRequest = employeeRequest;
        }

        private void frmEmployeeAdd_Load(object sender, EventArgs e)
        {
            AppUserList();
            DepartmentList();
            BranchList();
        }
        private async void AppUserList()
        {
            HttpResponseMessage response = await _appUserRequest.GetAllComboBoxAsync();
            if(!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetAppUserComboBoxDTO>(response).Data;

            cmbBoxAppUserSelect.DataSource = null;
            cmbBoxAppUserSelect.DisplayMember = "UserName";
            cmbBoxAppUserSelect.ValueMember = "Id";

            cmbBoxAppUserSelect.DataSource = result;

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

        private async void bttnAdd_Click(object sender, EventArgs e)
        {
            if(cmbBoxAppUserSelect.SelectedValue is not null && cmbBoxDepartmentSelect.SelectedValue is not null && cmbBoxBranchSelect.SelectedValue is not null)
            {
                CreateEmployeeDTO createEmployeeDTO = new CreateEmployeeDTO
                {
                    AppUserId = (Guid)cmbBoxAppUserSelect.SelectedValue,
                    DepartmentId = (Guid)cmbBoxDepartmentSelect.SelectedValue,
                    BranchId = (Guid)cmbBoxBranchSelect.SelectedValue,
                    StartDateOfWork = dateTimePickerStart.Value,
                    EndDateOfWork = checkDateTimePickerEndEnable.Checked ? dateTimePickerEnd.Value : null,
                    Salary = decimal.Parse(txtSalary.Text),
                    WorkingStatu = radioButtonActive.Checked ? true : false
                };

                HttpResponseMessage response = await _employeeRequest.AddAsync(createEmployeeDTO);

                if(!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
