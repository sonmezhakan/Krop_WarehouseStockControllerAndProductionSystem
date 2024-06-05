using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.AppUserRoles;
using Krop.WinForms.HelpersClass;
using System.Net.Http.Json;

namespace Krop.WinForms.AppUserRoles
{
    public partial class frmAppUserRoleUpdate : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmAppUserRoleUpdate(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmAppUserRoleUpdate_Load(object sender, EventArgs e)
        {
            await appUserRoleComboBoxListControl.AppUserRoleList(_webApiService);
            appUserRoleComboBoxListControl.AppUserRoleComboBoxList.SelectedIndexChanged += CmbBoxAppUserRoleSelect_SelectedIndexChanged;
            appUserRoleComboBoxListControl.AppUserRoleSelected(Id);
        }

        private  async void CmbBoxAppUserRoleSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (appUserRoleComboBoxListControl.AppUserRoleComboBoxList.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"appUserRole/GetById/{(Guid)appUserRoleComboBoxListControl.AppUserRoleComboBoxList.SelectedValue}");
                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                var result = await ResponseController.SuccessDataResponseController<GetAppUserRoleDTO>(response);

                if(result is not null)
                {
                    txtAppUserRoleName.Text = result.Data.Name;
                }         
            }
        }
        private async void bttnAppUserRoleUpdate_Click(object sender, EventArgs e)
        {
            if (appUserRoleComboBoxListControl.AppUserRoleComboBoxList.SelectedValue is not null)
            {
                UpdateAppUserRoleDTO updateAppUserRoleDTO = new UpdateAppUserRoleDTO
                {
                    Id = (Guid)appUserRoleComboBoxListControl.AppUserRoleComboBoxList.SelectedValue,
                   Name = txtAppUserRoleName.Text
                };

                HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("appUserRole/update", updateAppUserRoleDTO);

                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

               await appUserRoleComboBoxListControl.AppUserRoleList(_webApiService);
            }
            else
            {
                MessageBox.Show("Doğru Seçin Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
