using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Auths;
using Krop.WinForms.HelpersClass;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.Logins
{
    public partial class frmLogin : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;

        public frmLogin(IWebApiService webApiService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.UserName != null)
            {
                checkRemmemberMe.Checked = true;
                txtUserName.Text = Properties.Settings.Default.UserName;
            }
        }

        private async void bttnLogin_Click(object sender, EventArgs e)
        {
            LoginDTO loginDTO = new LoginDTO
            {
                UserName = txtUserName.Text,
                Password = txtPassword.Text
            };
            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("auth/login", loginDTO);
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            if (checkRemmemberMe.Checked)
            {
                Properties.Settings.Default.UserName = txtUserName.Text;
                Properties.Settings.Default.Save();
            }

            var result = await ResponseController.SuccessDataResponseController<LoginResponseDTO>(response);

            Panel panel = new Panel(_webApiService, _serviceProvider,result.Data.Id,result.Data.Token);
            this.Hide();
            panel.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            frmPasswordReset frmPasswordReset = new frmPasswordReset(_webApiService);
            frmPasswordReset.ShowDialog();
        }
    }
}
