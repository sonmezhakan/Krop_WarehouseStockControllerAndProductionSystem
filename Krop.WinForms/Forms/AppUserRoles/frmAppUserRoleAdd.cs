using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.AppUserRoles;
using Krop.WinForms.HelpersClass;
using System.Net.Http.Json;

namespace Krop.WinForms.AppUserRoles
{
    public partial class frmAppUserRoleAdd : Form
    {
        private readonly IWebApiService _webApiService;

        public frmAppUserRoleAdd(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
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

            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("appUserRole/Add", createAppUserRoleDTO);

            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

        }
    }
}
