using Krop.Business.Features.Employees.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.BranchHelpers;
using Krop.WinForms.HelpersClass.Departments;
using Krop.WinForms.HelpersClass.Employees;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.Employees
{
    public partial class frmEmployeeUpdate : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IDepartmentHelper _departmentHelper;
        private readonly IBranchHelper _branchHelper;
        private readonly IEmployeeHelper _employeeHelper;
        public Guid Id;

        public frmEmployeeUpdate(IWebApiService webApiService, IDepartmentHelper departmentHelper, IBranchHelper branchHelper, IEmployeeHelper employeeHelper)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _departmentHelper = departmentHelper;
            _branchHelper = branchHelper;
            _employeeHelper = employeeHelper;
        }

        private  void frmEmployeeUpdate_Load(object sender, EventArgs e)
        {
            EmployeeList();
            DepartmentList();
            BranchList();
            if (cmbBoxAppUserSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxAppUserSelect.SelectedValue = Id;
        }
        private void EmployeeList()
        {
            var result = _employeeHelper.GetAllComboBoxAsync();
            if (result is null)
                return;

            cmbBoxAppUserSelect.DataSource = null;
            cmbBoxAppUserSelect.DisplayMember = "UserName";
            cmbBoxAppUserSelect.ValueMember = "AppUserId";

            cmbBoxAppUserSelect.SelectedIndexChanged -= CmbBoxAppUserSelect_SelectedIndexChanged;
            cmbBoxAppUserSelect.DataSource = result;
            cmbBoxAppUserSelect.SelectedValue = -1;
            cmbBoxAppUserSelect.SelectedIndexChanged += CmbBoxAppUserSelect_SelectedIndexChanged;
        }

        private void CmbBoxAppUserSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxAppUserSelect.SelectedValue is not null)
            {
                var result = _employeeHelper.GetByEmployeeIdAsync((Guid)cmbBoxAppUserSelect.SelectedValue);
                if (result is null)
                    return;

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

        private void DepartmentList()
        {
            var result = _departmentHelper.GetAllComboBoxAsync();
            if (result is null)
                return;

            cmbBoxDepartmentSelect.DataSource = null;
            cmbBoxDepartmentSelect.DisplayMember = "DepartmentName";
            cmbBoxDepartmentSelect.ValueMember = "Id";

            cmbBoxDepartmentSelect.DataSource = result;
        }
        private void BranchList()
        {
            var result = _branchHelper.GetAllComboBoxAsync();
            if (result is null) return;

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

        private void bttnUpdate_Click(object sender, EventArgs e)
        {
            if(cmbBoxAppUserSelect.SelectedValue is not null && cmbBoxDepartmentSelect.SelectedValue is not null &&
                cmbBoxBranchSelect.SelectedValue is not null)
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

                HttpResponseMessage response = _webApiService.httpClient.PutAsJsonAsync("employee/update", updateEmployeeDTO).Result;
                
                if(!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                EmployeeList();
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
