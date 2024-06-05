using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Departments;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.UserControllers.Departments
{
    public partial class DepartmentComboBoxControl : UserControl
    {
        public DepartmentComboBoxControl()
        {
            InitializeComponent();
        }
        public async Task DepartmentList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("department/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetDepartmentComboBoxDTO>>(response);

            cmbBoxDepartmentSelect.DataSource = null;

            cmbBoxDepartmentSelect.DisplayMember = "DepartmentName";
            cmbBoxDepartmentSelect.ValueMember = "Id";

            cmbBoxDepartmentSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxDepartmentSelect.SelectedIndex = -1;
        }
        public void DepartmentSelect(Guid id)
        {
            if (cmbBoxDepartmentSelect.DataSource != null && id != Guid.Empty)
                cmbBoxDepartmentSelect.SelectedValue = id;
        }
        public ComboBox DepartmentComboBox
        {
            get { return cmbBoxDepartmentSelect; }
        }
    }
}
