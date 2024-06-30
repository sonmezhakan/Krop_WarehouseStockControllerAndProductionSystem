using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.AppUsers;
using Krop.WinForms.HelpersClass;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.AppUsers
{
    public partial class frmUserUpdateRole : Form
    {
        private readonly IWebApiService _webApiService;

        public frmUserUpdateRole(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmUserAddRole_Load(object sender, EventArgs e)
        {
            await appUserComboBoxControl.AppUserList(_webApiService);
            await appUserRoleCheckedListBoxControl.AppUserRoleList(_webApiService);
        }

        private async void bttnUserUpdateRole_Click(object sender, EventArgs e)
        {
            if(appUserComboBoxControl.AppUserComboBox.SelectedValue != null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("Account/UserUpdateRole", new UpdateAppUserUpdateRoleDTO
                {
                    AppUserId = (Guid)appUserComboBoxControl.AppUserComboBox.SelectedValue,
                    Roles = appUserRoleCheckedListBoxControl.checkedListBox1.CheckedItems.Cast<string>().ToList()
                });

                if(!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }
            }
        }
    }
}
