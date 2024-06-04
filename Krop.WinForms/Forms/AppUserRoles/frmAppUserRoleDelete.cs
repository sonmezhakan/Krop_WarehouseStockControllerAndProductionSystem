using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.AppUserRoles;
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

            var result = await ResponseController.SuccessDataResponseController<List<GetAppUserRoleDTO>>(response);

            cmbBoxAppUserRoleSelect.DataSource = null;
            cmbBoxAppUserRoleSelect.DisplayMember = "Name";
            cmbBoxAppUserRoleSelect.ValueMember = "Id";

            cmbBoxAppUserRoleSelect.SelectedIndexChanged -= CmbBoxAppUserRoleSelect_SelectedIndexChanged;
            cmbBoxAppUserRoleSelect.DataSource = result is not null ? result.Data:null;
            cmbBoxAppUserRoleSelect.SelectedIndex = -1;
            cmbBoxAppUserRoleSelect.SelectedIndexChanged += CmbBoxAppUserRoleSelect_SelectedIndexChanged;
        }

        private void CmbBoxAppUserRoleSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {

        }
        private async void bttnAppUserRoleDelete_Click(object sender, EventArgs e)
        {
            if (cmbBoxAppUserRoleSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"appUserRole/Delete/{(Guid)cmbBoxAppUserRoleSelect.SelectedValue}");

                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

               await AppUserRoleList();
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
