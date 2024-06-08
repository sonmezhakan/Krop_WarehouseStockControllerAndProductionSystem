using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Auths;
using Krop.WinForms.HelpersClass;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.Logins
{
    public partial class frmPasswordReset : Form
    {
        private readonly IWebApiService _webApiService;

        public frmPasswordReset(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private void frmPasswordReset_Load(object sender, EventArgs e)
        {

        }
        private async void bttnPasswordResetMailSender_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"Auth/ResetPasswordEmailSender/{txtEmail.Text}");
                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Mail Adresinizi Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void bttnPasswordSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text) && !string.IsNullOrWhiteSpace(txtResetToken.Text))
            {
                HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("auth/ResetPassword", new ResetPasswordDTO
                {
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    Token = txtResetToken.Text
                });
                if(!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Tüm Alanları Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}