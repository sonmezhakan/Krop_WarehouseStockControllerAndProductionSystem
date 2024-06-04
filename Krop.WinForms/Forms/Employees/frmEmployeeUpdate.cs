using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Branches;
using Krop.DTO.Dtos.Departments;
using Krop.DTO.Dtos.Employees;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
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
           await EmployeeList();
           await DepartmentList();
           await BranchList();
            if (cmbBoxAppUserSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxAppUserSelect.SelectedValue = Id;
        }
        private async Task EmployeeList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("employee/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetEmployeeComboBoxDTO>>(response);

            cmbBoxAppUserSelect.DataSource = null;
            cmbBoxAppUserSelect.DisplayMember = "UserName";
            cmbBoxAppUserSelect.ValueMember = "AppUserId";

            cmbBoxAppUserSelect.SelectedIndexChanged -= CmbBoxAppUserSelect_SelectedIndexChanged;
            cmbBoxAppUserSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxAppUserSelect.SelectedValue = -1;
            cmbBoxAppUserSelect.SelectedIndexChanged += CmbBoxAppUserSelect_SelectedIndexChanged;
        }

        private async void CmbBoxAppUserSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxAppUserSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"employee/GetById/{cmbBoxAppUserSelect.SelectedValue}");
                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                var result =await ResponseController.SuccessDataResponseController<GetEmployeeDTO>(response);

                if (result is not null)
                {
                    cmbBoxDepartmentSelect.SelectedValue = result.Data.DepartmentId;
                    cmbBoxBranchSelect.SelectedValue = result.Data.BranchId;
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

        private async Task DepartmentList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("department/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result =await ResponseController.SuccessDataResponseController<List<GetDepartmentComboBoxDTO>>(response);

            cmbBoxDepartmentSelect.DataSource = null;
            cmbBoxDepartmentSelect.DisplayMember = "DepartmentName";
            cmbBoxDepartmentSelect.ValueMember = "Id";

            cmbBoxDepartmentSelect.DataSource = result is not null ? result.Data : null;
        }
        private async Task BranchList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("branch/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result =  await ResponseController.SuccessDataResponseController<List<GetBranchComboBoxDTO>>(response);

            cmbBoxBranchSelect.DataSource = null;
            cmbBoxBranchSelect.DisplayMember = "BranchName";
            cmbBoxBranchSelect.ValueMember = "Id";

            cmbBoxBranchSelect.DataSource = result is not null ? result.Data : null;
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

                    HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("employee/update", updateEmployeeDTO);

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                   await EmployeeList();
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
