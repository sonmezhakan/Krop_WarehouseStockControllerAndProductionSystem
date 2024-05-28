using Krop.Business.Features.AppUserRoles.Dtos;
using Krop.Common.Helpers.WebApiService;
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

        private void bttnAppUserRoleAdd_Click(object sender, EventArgs e)
        {
            CreateAppUserRoleDTO createAppUserRoleDTO = new CreateAppUserRoleDTO
            {
                Name = txtAppUserRoleName.Text
            };

            HttpResponseMessage response = _webApiService.httpClient.PostAsJsonAsync("appUserRole/Add", createAppUserRoleDTO).Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

        }
    }
}
