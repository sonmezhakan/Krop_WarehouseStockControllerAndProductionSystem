using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.AppUsers;
using Krop.WinForms.HelpersClass;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.Logins
{
    public partial class frmLogin : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;

        public frmLogin(IWebApiService webApiService,IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private async void bttnLogin_Click(object sender, EventArgs e)
        {
            LoginDTO loginDTO = new LoginDTO
            {
                UserName = txtUserName.Text,
                Password = txtPassword.Text
            };
            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("login/login", loginDTO); 
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<Guid>(response);

            Panel panel = new Panel(_webApiService, _serviceProvider);
            panel.AppUserId = result.Data;
            this.Hide();
            panel.Show();
        }
    }
}
