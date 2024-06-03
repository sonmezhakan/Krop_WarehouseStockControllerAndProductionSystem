using Krop.Common.Helpers.WebApiRequests.Employees;
using Krop.DTO.Dtos.Employees;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.Forms.Employees
{
    public partial class frmEmployeeCart : Form
    {
        public Guid Id;
        private readonly IEmployeeRequest _employeeRequest;

        public frmEmployeeCart(IEmployeeRequest employeeRequest)
        {
            InitializeComponent();
            _employeeRequest = employeeRequest;
        }

        private void frmEmployeeCart_Load(object sender, EventArgs e)
        {
            EmployeeList();
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
                HttpResponseMessage response = await _employeeRequest.GetByIdCartAsync((Guid)cmbBoxAppUserSelect.SelectedValue);
                if (!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                var result = ResponseController.SuccessDataResponseController<GetEmployeeCartDTO>(response).Data;

                txtDepartmentName.Text = result.DepartmentName;
                txtBranchName.Text = result.BranchName;
                txtSalary.Text = result.Salary.ToString() + " ₺";
                dateTimePickerStart.Value = result.StartDateOfWork;
                dateTimePickerEnd.Value = result.EndDateOfWork == null || result.EndDateOfWork == DateTime.MinValue ? DateTime.Now : result.EndDateOfWork;
                if (result.WorkingStatu)
                    radioButtonActive.Checked = true;
                else
                    radioButtonPassive.Checked = true;
            }
        }
    }
}
