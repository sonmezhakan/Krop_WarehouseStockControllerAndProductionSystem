using Krop.Common.Helpers.WebApiRequests.Departments;
using Krop.DTO.Dtos.Departments;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.Forms.Departments
{
    public partial class frmDepartmentCart : Form
    {
        
        public Guid Id;
        private readonly IDepartmentRequest _departmentRequest;

        public frmDepartmentCart(IDepartmentRequest departmentRequest)
        {
            InitializeComponent();
            _departmentRequest = departmentRequest;
        }

        private void frmDepartmentCart_Load(object sender, EventArgs e)
        {
            DepartmentList();
            if (cmbBoxDepartmentSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxDepartmentSelect.SelectedValue = Id;
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

            cmbBoxDepartmentSelect.SelectedIndexChanged -= CmbBoxDepartmentSelect_SelectedIndexChanged;
            cmbBoxDepartmentSelect.DataSource = result;
            cmbBoxDepartmentSelect.SelectedIndex = -1;
            cmbBoxDepartmentSelect.SelectedIndexChanged += CmbBoxDepartmentSelect_SelectedIndexChanged;
        }

        private async void CmbBoxDepartmentSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxDepartmentSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = await _departmentRequest.GetByIdAsync((Guid)cmbBoxDepartmentSelect.SelectedValue);
                if (!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                var result = ResponseController.SuccessDataResponseController<GetDepartmentDTO>(response).Data;

                txtDescription.Text = result.Description;
            }
        }
    }
}
