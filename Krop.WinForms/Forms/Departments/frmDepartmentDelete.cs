using Krop.Common.Helpers.WebApiRequests.Departments;
using Krop.DTO.Dtos.Departments;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Forms.Departments
{
    public partial class frmDepartmentDelete : Form
    {
        public Guid Id;
        private readonly IDepartmentRequest _departmentRequest;

        public frmDepartmentDelete(IDepartmentRequest departmentRequest)
        {
            InitializeComponent();
            _departmentRequest = departmentRequest;
        }

        private void frmDepartmentDelete_Load(object sender, EventArgs e)
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

        private void CmbBoxDepartmentSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {

        }

        private async void bttnDelete_Click(object sender, EventArgs e)
        {
            if (cmbBoxDepartmentSelect.SelectedValue is not null)
            {
                if (DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = await _departmentRequest.DeleteAsync((Guid)cmbBoxDepartmentSelect.SelectedValue);

                    if (!response.IsSuccessStatusCode)
                    {
                        ResponseController.ErrorResponseController(response);
                        return;
                    }

                    DepartmentList();
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
