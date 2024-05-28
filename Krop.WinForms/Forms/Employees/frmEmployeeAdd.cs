using Krop.Business.Features.Employees.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.Entities.Enums;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.AppUserHelpers;
using Krop.WinForms.HelpersClass.BranchHelpers;
using Krop.WinForms.HelpersClass.Departments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krop.WinForms.Forms.Employees
{
    public partial class frmEmployeeAdd : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IDepartmentHelper _departmentHelper;
        private readonly IBranchHelper _branchHelper;
        private readonly IAppUserHelper _appUserHelper;

        public frmEmployeeAdd(IWebApiService webApiService, IDepartmentHelper departmentHelper, IBranchHelper branchHelper, IAppUserHelper appUserHelper)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _departmentHelper = departmentHelper;
            _branchHelper = branchHelper;
            _appUserHelper = appUserHelper;
        }

        private void frmEmployeeAdd_Load(object sender, EventArgs e)
        {
            AppUserList();
            DepartmentList();
            BranchList();
        }
        private void AppUserList()
        {
            var result = _appUserHelper.GetAllComboBoxAsync();
            if (result is null)
                return;

            cmbBoxAppUserSelect.DataSource = null;
            cmbBoxAppUserSelect.DisplayMember = "UserName";
            cmbBoxAppUserSelect.ValueMember = "Id";

            cmbBoxAppUserSelect.DataSource = result;

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

        private void bttnAdd_Click(object sender, EventArgs e)
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

                HttpResponseMessage response = _webApiService.httpClient.PostAsJsonAsync("employee/add", createEmployeeDTO).Result;

                if(!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
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
