using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.AppUsers;
using Krop.DTO.Dtos.Branches;
using Krop.DTO.Dtos.Departments;
using Krop.DTO.Dtos.Employees;
using Krop.WinForms.HelpersClass;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.Employees
{
    public partial class frmEmployeeAdd : Form
    {
        private readonly IWebApiService _webApiService;

        public frmEmployeeAdd(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmEmployeeAdd_Load(object sender, EventArgs e)
        {
           await AppUserList();
           await DepartmentList();
           await BranchList();
        }
        private async Task AppUserList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("account/getAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result =await ResponseController.SuccessDataResponseController<List<GetAppUserComboBoxDTO>>(response);

            cmbBoxAppUserSelect.DataSource = null;
            cmbBoxAppUserSelect.DisplayMember = "UserName";
            cmbBoxAppUserSelect.ValueMember = "Id";

            cmbBoxAppUserSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxAppUserSelect.SelectedIndex = -1;

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
            cmbBoxDepartmentSelect.SelectedIndex = -1;
        }
        private async Task BranchList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("branch/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result =await ResponseController.SuccessDataResponseController<List<GetBranchComboBoxDTO>>(response);

            cmbBoxBranchSelect.DataSource = null;
            cmbBoxBranchSelect.DisplayMember = "BranchName";
            cmbBoxBranchSelect.ValueMember = "Id";

            cmbBoxBranchSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxBranchSelect.SelectedIndex = -1;
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

                HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("employee/add", createEmployeeDTO);

                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
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
