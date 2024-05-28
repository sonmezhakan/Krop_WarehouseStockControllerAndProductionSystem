using Krop.Business.Features.Departments.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.Departments;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.Departments
{
    public partial class frmDepartmentUpdate : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IDepartmentHelper _departmentHelper;
        public Guid Id;

        public frmDepartmentUpdate(IWebApiService webApiService, IDepartmentHelper departmentHelper)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _departmentHelper = departmentHelper;
        }

        private  void frmDepartmentUpdate_Load(object sender, EventArgs e)
        {
             DepartmentList();
            if(cmbBoxDepartmentSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxDepartmentSelect.SelectedValue = Id;
        }
        private  void DepartmentList()
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

        private  void CmbBoxDepartmentSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if(cmbBoxDepartmentSelect.SelectedValue is not null)
            {
                var result =  _departmentHelper.GetByDepartmentId((Guid)cmbBoxDepartmentSelect.SelectedValue);
                if (result is null)
                    return;

                txtDepartmentName.Text = result.DepartmentName;
                txtDescription.Text = result.Description;
            }
        }

        private void bttnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbBoxDepartmentSelect.SelectedValue is not null)
            {
                UpdateDepartmentDTO updateDepartmentDTO = new UpdateDepartmentDTO
                {
                    Id = (Guid)cmbBoxDepartmentSelect.SelectedValue,
                    DepartmentName = txtDepartmentName.Text,
                    Description = txtDescription.Text
                };

                HttpResponseMessage response = _webApiService.httpClient.PutAsJsonAsync("department/Update", updateDepartmentDTO).Result;

                if (!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                DepartmentList();
            }
        }
    }
}
