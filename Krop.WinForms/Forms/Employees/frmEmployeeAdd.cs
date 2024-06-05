using Krop.Common.Helpers.WebApiService;
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
            await appUserComboBoxControl.AppUserList(_webApiService);
            await departmentComboBoxControl.DepartmentList(_webApiService);
            await branchComboBoxControl.BranchList(_webApiService);
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
            if (appUserComboBoxControl.AppUserComboBox.SelectedValue is not null && departmentComboBoxControl.DepartmentComboBox.SelectedValue is not null && branchComboBoxControl.BranchComboBox.SelectedValue is not null)
            {
                CreateEmployeeDTO createEmployeeDTO = new CreateEmployeeDTO
                {
                    AppUserId = (Guid)appUserComboBoxControl.AppUserComboBox.SelectedValue,
                    DepartmentId = (Guid)departmentComboBoxControl.DepartmentComboBox.SelectedValue,
                    BranchId = (Guid)branchComboBoxControl.BranchComboBox.SelectedValue,
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
