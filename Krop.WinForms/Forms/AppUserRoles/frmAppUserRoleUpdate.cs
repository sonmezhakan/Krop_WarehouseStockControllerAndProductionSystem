using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.AppUserRoles;
using Krop.DTO.Dtos.AppUsers;
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
            await AppUserRoleList();
            if (cmbBoxAppUserRoleSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxAppUserRoleSelect.SelectedValue = Id;
        }
        private async Task AppUserRoleList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("AppUserRole/GetAll");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetAppUserComboBoxDTO>>(response);

            cmbBoxAppUserRoleSelect.DataSource = null;
            cmbBoxAppUserRoleSelect.DisplayMember = "Name";
            cmbBoxAppUserRoleSelect.ValueMember = "Id";

            cmbBoxAppUserRoleSelect.SelectedIndexChanged -= CmbBoxAppUserRoleSelect_SelectedIndexChanged;
            cmbBoxAppUserRoleSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxAppUserRoleSelect.SelectedIndex = -1;
            cmbBoxAppUserRoleSelect.SelectedIndexChanged += CmbBoxAppUserRoleSelect_SelectedIndexChanged;
        }

        private  async void CmbBoxAppUserRoleSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxAppUserRoleSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"appUserRole/GetById/{(Guid)cmbBoxAppUserRoleSelect.SelectedValue}");
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
            if (cmbBoxAppUserRoleSelect.SelectedValue is not null)
            {
                UpdateAppUserRoleDTO updateAppUserRoleDTO = new UpdateAppUserRoleDTO
                {
                    Id = (Guid)cmbBoxAppUserRoleSelect.SelectedValue,
                   Name = txtAppUserRoleName.Text
                };

                HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("appUserRole/update", updateAppUserRoleDTO);

                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                await AppUserRoleList();
            }
            else
            {
                MessageBox.Show("Doğru Seçin Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
