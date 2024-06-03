using Krop.Common.Helpers.WebApiRequests.AppUserRoles;
using Krop.DTO.Dtos.AppUserRoles;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.AppUserRoles
{
    public partial class frmAppUserRoleDelete : Form
    {

        public Guid Id;
        private readonly IAppUserRoleRequest _appUserRoleRequest;

        public frmAppUserRoleDelete(IAppUserRoleRequest appUserRoleRequest)
        {
            InitializeComponent();
            _appUserRoleRequest = appUserRoleRequest;
        }

        private void frmAppUserRoleDelete_Load(object sender, EventArgs e)
        {
            AppUserRoleList();
            if (cmbBoxAppUserRoleSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxAppUserRoleSelect.SelectedValue = Id;
        }
        private async void AppUserRoleList()
        {
            HttpResponseMessage response = await _appUserRoleRequest.GetAllAsync();
            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetAppUserRoleDTO>(response).Data;

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
                HttpResponseMessage response = await _appUserRoleRequest.DeleteAsync((Guid)cmbBoxAppUserRoleSelect.SelectedValue);

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
