using Krop.WinForms.HelpersClass.Departments;

namespace Krop.WinForms.Forms.Departments
{
    public partial class frmDepartmentCart : Form
    {
        private readonly IDepartmentHelper _departmentHelper;
        public Guid Id;

        public frmDepartmentCart(IDepartmentHelper departmentHelper)
        {
            InitializeComponent();
            _departmentHelper = departmentHelper;
        }

        private void frmDepartmentCart_Load(object sender, EventArgs e)
        {
            DepartmentList();
            if (cmbBoxDepartmentSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxDepartmentSelect.SelectedValue = Id;
        }
        private void DepartmentList()
        {
            var result =  _departmentHelper.GetAllComboBoxAsync();
            if (result is null)
                return;

            cmbBoxDepartmentSelect.DataSource = null;

            cmbBoxDepartmentSelect.DisplayMember = "DepartmentName";
            cmbBoxDepartmentSelect.ValueMember = "Id";

            cmbBoxDepartmentSelect.SelectedIndexChanged -= CmbBoxDepartmentSelect_SelectedIndexChanged;
            cmbBoxDepartmentSelect.DataSource = result;
            cmbBoxDepartmentSelect.SelectedIndex = -1;
            cmbBoxDepartmentSelect.SelectedIndexChanged += CmbBoxDepartmentSelect_SelectedIndexChanged;
        }

        private void CmbBoxDepartmentSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxDepartmentSelect.SelectedValue is not null)
            {
                var result = _departmentHelper.GetByDepartmentId((Guid)cmbBoxDepartmentSelect.SelectedValue);
                if (result is null)
                    return;

                txtDescription.Text = result.Description;
            }
        }
    }
}
