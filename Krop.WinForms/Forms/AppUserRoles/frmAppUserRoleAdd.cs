using Krop.Common.Helpers.WebApiRequests.AppUserRoles;
using Krop.DTO.Dtos.AppUserRoles;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.AppUserRoles
{
    public partial class frmAppUserRoleAdd : Form
    {
        private readonly IAppUserRoleRequest _appUserRoleRequest;

        public frmAppUserRoleAdd(IAppUserRoleRequest appUserRoleRequest)
        {
            InitializeComponent();
            _appUserRoleRequest = appUserRoleRequest;
        }

        private void frmAppUserRoleAdd_Load(object sender, EventArgs e)
        {

        }

        private async void bttnAppUserRoleAdd_Click(object sender, EventArgs e)
        {
            CreateAppUserRoleDTO createAppUserRoleDTO = new CreateAppUserRoleDTO
            {
                Name = txtAppUserRoleName.Text
            };

            HttpResponseMessage response = await _appUserRoleRequest.AddAsync(createAppUserRoleDTO);

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

        }
    }
}
