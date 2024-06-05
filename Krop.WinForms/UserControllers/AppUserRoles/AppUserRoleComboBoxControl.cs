using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.AppUserRoles;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.UserControllers.AppUserRoles
{
    public partial class AppUserRoleComboBoxControl : UserControl
    {
        public AppUserRoleComboBoxControl()
        {
            InitializeComponent();
            
        }
        public async Task AppUserRoleList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("AppUserRole/GetAll");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetAppUserRoleDTO>>(response);

            cmbBoxAppUserRoleSelect.DataSource = null;
            cmbBoxAppUserRoleSelect.DisplayMember = "Name";
            cmbBoxAppUserRoleSelect.ValueMember = "Id";

            cmbBoxAppUserRoleSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxAppUserRoleSelect.SelectedIndex = -1;
        }
        public void AppUserRoleSelected(Guid id)
        {
            if (cmbBoxAppUserRoleSelect.DataSource != null && id != Guid.Empty)
                cmbBoxAppUserRoleSelect.SelectedValue = id;
        }
        public ComboBox AppUserRoleComboBoxList
        {
            get{ return cmbBoxAppUserRoleSelect; }
        }
    }
}
