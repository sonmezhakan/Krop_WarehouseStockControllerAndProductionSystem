using Krop.WinForms.HelpersClass.AppUserHelpers;
using Krop.WinForms.HelpersClass.BranchHelpers;
using Krop.WinForms.HelpersClass.Employees;

namespace Krop.WinForms.Forms.Employees
{
    public partial class frmEmployeeCart : Form
    {
        private readonly IEmployeeHelper _employeeHelper;
        public Guid Id;

        public frmEmployeeCart(IEmployeeHelper employeeHelper)
        {
            InitializeComponent();
            _employeeHelper = employeeHelper;
        }

        private void frmEmployeeCart_Load(object sender, EventArgs e)
        {
            EmployeeList();
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
                var result = _employeeHelper.GetByEmployeeIdCartAsync((Guid)cmbBoxAppUserSelect.SelectedValue);
                if (result is null)
                    return;

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
