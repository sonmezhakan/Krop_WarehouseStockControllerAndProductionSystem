using Krop.Common.Helpers.WebApiRequests.AppUserRoles;
using Krop.DTO.Dtos.AppUserRoles;
using Krop.DTO.Dtos.AppUsers;
using Krop.WinForms.HelpersClass;
using System.Net.Http.Json;

namespace Krop.WinForms.AppUserRoles
{
    public partial class frmAppUserRoleUpdate : Form
    {
        public Guid Id;
        private readonly IAppUserRoleRequest _appUserRoleRequest;

        public frmAppUserRoleUpdate(IAppUserRoleRequest appUserRoleRequest)
        {
            InitializeComponent();
            _appUserRoleRequest = appUserRoleRequest;
        }

        private void frmAppUserRoleUpdate_Load(object sender, EventArgs e)
        {
            AppUserRoleList();
            if (cmbBoxAppUserRoleSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxAppUserRoleSelect.SelectedValue = Id;
        }
        private async void AppUserRoleList()
        {
            HttpResponseMessage response = await _appUserRoleRequest.GetAllAsync();
            if(!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetAppUserComboBoxDTO>(response).Data;

            cmbBoxAppUserRoleSelect.DataSource = null;
            cmbBoxAppUserRoleSelect.DisplayMember = "Name";
            cmbBoxAppUserRoleSelect.ValueMember = "Id";

            cmbBoxAppUserRoleSelect.SelectedIndexChanged -= CmbBoxAppUserRoleSelect_SelectedIndexChanged;
            cmbBoxAppUserRoleSelect.DataSource = result;
            cmbBoxAppUserRoleSelect.SelectedIndex = -1;
            cmbBoxAppUserRoleSelect.SelectedIndexChanged += CmbBoxAppUserRoleSelect_SelectedIndexChanged;
        }

        private  async void CmbBoxAppUserRoleSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxAppUserRoleSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = await _appUserRoleRequest.GetByIdAsync((Guid)cmbBoxAppUserRoleSelect.SelectedValue);
                if(!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                var result = ResponseController.SuccessDataResponseController<GetAppUserRoleDTO>(response).Data;

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

                HttpResponseMessage response = await _appUserRoleRequest.UpdateAsync(updateAppUserRoleDTO);

                if (!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                AppUserRoleList();
            }
            else
            {
                MessageBox.Show("Doğru Seçin Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
