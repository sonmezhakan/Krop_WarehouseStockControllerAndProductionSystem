using Krop.Business.Features.AppUserRoles.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.AppUserRoleHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.AppUserRoles
{
    public partial class frmAppUserRoleUpdate : Form
    {
        private readonly IAppUserRoleHelper _appUserRoleHelper;
        private readonly IWebApiService _webApiService;
        public Guid Id;

        public frmAppUserRoleUpdate(IAppUserRoleHelper appUserRoleHelper, IWebApiService webApiService)
        {
            InitializeComponent();
            _appUserRoleHelper = appUserRoleHelper;
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
            List<GetAppUserRoleDTO> result = await _appUserRoleHelper.GetAllAsync();

            cmbBoxAppUserRoleSelect.DataSource = null;
            cmbBoxAppUserRoleSelect.DisplayMember = "Name";
            cmbBoxAppUserRoleSelect.ValueMember = "Id";

            cmbBoxAppUserRoleSelect.SelectedIndexChanged -= CmbBoxAppUserRoleSelect_SelectedIndexChanged;
            cmbBoxAppUserRoleSelect.DataSource = result;
            cmbBoxAppUserRoleSelect.SelectedIndex = -1;
            cmbBoxAppUserRoleSelect.SelectedIndexChanged += CmbBoxAppUserRoleSelect_SelectedIndexChanged;
        }

        private async void CmbBoxAppUserRoleSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxAppUserRoleSelect.SelectedValue is not null)
            {
                GetAppUserRoleDTO result = await _appUserRoleHelper.GetByAppUserRoleIdAsync((Guid)cmbBoxAppUserRoleSelect.SelectedValue);

                txtAppUserRoleName.Text = result.Name;
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

                await ResponseController.ErrorResponseController(response);

                await AppUserRoleList();
            }
            else
            {
                MessageBox.Show("Doğru Seçin Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
