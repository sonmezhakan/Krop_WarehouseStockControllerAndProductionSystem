using Krop.Business.Features.AppUserRoles.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.AppUserRoleHelpers;

namespace Krop.WinForms.AppUserRoles
{
    public partial class frmAppUserRoleDelete : Form
    {
        private readonly IAppUserRoleHelper _appUserRoleHelper;
        private readonly IWebApiService _webApiService;
        public Guid Id;

        public frmAppUserRoleDelete(IAppUserRoleHelper appUserRoleHelper,IWebApiService webApiService)
        {
            InitializeComponent();
            _appUserRoleHelper = appUserRoleHelper;
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
            List<GetAppUserRoleDTO> result = await _appUserRoleHelper.GetAllAsync();

            cmbBoxAppUserRoleSelect.DataSource = null;
            cmbBoxAppUserRoleSelect.DisplayMember = "Name";
            cmbBoxAppUserRoleSelect.ValueMember = "Id";

            cmbBoxAppUserRoleSelect.SelectedIndexChanged -= CmbBoxAppUserRoleSelect_SelectedIndexChanged;
            cmbBoxAppUserRoleSelect.DataSource = result;
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
                HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"appUserRole/delete/{cmbBoxAppUserRoleSelect.SelectedValue}");

                await ResponseController.ErrorResponseController(response);

                await AppUserRoleList();
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
