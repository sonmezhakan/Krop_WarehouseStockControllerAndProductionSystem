using Krop.Common.Helpers.WebApiRequests.Departments;
using Krop.DTO.Dtos.Departments;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Forms.Departments
{
    public partial class frmDepartmentUpdate : Form
    {
        public Guid Id;
        private readonly IDepartmentRequest _departmentRequest;

        public frmDepartmentUpdate(IDepartmentRequest departmentRequest)
        {
            InitializeComponent();
            _departmentRequest = departmentRequest;
        }

        private  void frmDepartmentUpdate_Load(object sender, EventArgs e)
        {
             DepartmentList();
            if(cmbBoxDepartmentSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxDepartmentSelect.SelectedValue = Id;
        }
        private  async void DepartmentList()
        {
            HttpResponseMessage response = await _departmentRequest.GetAllComboBoxAsync();
            if(!response.IsSuccessStatusCode)
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

        private  async void CmbBoxDepartmentSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if(cmbBoxDepartmentSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = await _departmentRequest.GetByIdAsync((Guid)cmbBoxDepartmentSelect.SelectedValue);
                if(!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                var result = ResponseController.SuccessDataResponseController<GetDepartmentDTO>(response).Data;

                txtDepartmentName.Text = result.DepartmentName;
                txtDescription.Text = result.Description;
            }
        }

        private async void bttnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbBoxDepartmentSelect.SelectedValue is not null)
            {
                if(DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    UpdateDepartmentDTO updateDepartmentDTO = new UpdateDepartmentDTO
                    {
                        Id = (Guid)cmbBoxDepartmentSelect.SelectedValue,
                        DepartmentName = txtDepartmentName.Text,
                        Description = txtDescription.Text
                    };

                    HttpResponseMessage response = await _departmentRequest.UpdateAsync(updateDepartmentDTO);

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
