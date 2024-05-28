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

        private void frmAppUserRoleDelete_Load(object sender, EventArgs e)
        {
            AppUserRoleList();
            if (cmbBoxAppUserRoleSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxAppUserRoleSelect.SelectedValue = Id;
        }
        private void AppUserRoleList()
        {
            List<GetAppUserRoleDTO> result = _appUserRoleHelper.GetAllAsync();
            if (result is null)
                return;

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
        private void bttnAppUserRoleDelete_Click(object sender, EventArgs e)
        {
            if (cmbBoxAppUserRoleSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = _webApiService.httpClient.DeleteAsync($"appUserRole/delete/{cmbBoxAppUserRoleSelect.SelectedValue}").Result;

                if (!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                AppUserRoleList();
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
