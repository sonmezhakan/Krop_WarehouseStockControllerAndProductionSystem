using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.AppUserRoles
{
    public partial class frmAppUserRoleDelete : Form
    {

        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmAppUserRoleDelete(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }
        private async void frmAppUserRoleDelete_Load(object sender, EventArgs e)
        {
            await appUserRoleComboBoxListControl.AppUserRoleList(_webApiService);
            appUserRoleComboBoxListControl.AppUserRoleSelected(Id);
        }
        private async void bttnAppUserRoleDelete_Click(object sender, EventArgs e)
        {
            if (appUserRoleComboBoxListControl.AppUserRoleComboBoxList.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"appUserRole/Delete/{(Guid)appUserRoleComboBoxListControl.AppUserRoleComboBoxList.SelectedValue}");

                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

               await appUserRoleComboBoxListControl.AppUserRoleList(_webApiService);
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
