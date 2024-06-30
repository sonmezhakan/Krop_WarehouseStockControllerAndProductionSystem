using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.AppUsers;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.Settings.AppUserSettings
{
    public partial class frmAppUserSetting : Form
    {
        private readonly IWebApiService _webApiService;

        public frmAppUserSetting(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmAppUserSetting_Load(object sender, EventArgs e)
        {
            if (Panel._appUserId != Guid.Empty)
                await GetByAppUserId(Panel._appUserId);
            else
                Application.Exit();
        }
        private async Task GetByAppUserId(Guid appUserId)
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"account/GetById/{appUserId}");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<GetAppUserDTO>(response);

            txtUserName.Text = result.Data.UserName;
            txtFirstName.Text = result.Data.FirstName;
            txtLastName.Text = result.Data.LastName;
            txtEmail.Text = result.Data.Email;
            txtPhoneNumber.Text = result.Data.PhoneNumber;
            txtNationalNumber.Text = result.Data.NationalNumber;
            txtCountry.Text = result.Data.Country;
            txtCity.Text = result.Data.City;
            txtAddress.Text = result.Data.Addres;
        }

        private async void bttnAppUserUpdate_Click(object sender, EventArgs e)
        {
            if (DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
            {
                HttpResponseMessage response;
                if (checkBoxPasswordReset.Checked)
                {
                    UpdateAppUserPasswordDTO updateAppUserPasswordDTO = new UpdateAppUserPasswordDTO
                    {
                        Id = Panel._appUserId,
                        Password = txtPassword.Text
                    };

                    response = await _webApiService.httpClient.PutAsJsonAsync("account/UpdatePassword", updateAppUserPasswordDTO);
                }
                else
                {
                    UpdateAppUserDTO updateAppUserDTO = new UpdateAppUserDTO
                    {
                        Id = Panel._appUserId,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        City = txtCity.Text,
                        Country = txtCountry.Text,
                        Addres = txtAddress.Text,
                        NationalNumber = txtNationalNumber.Text
                    };

                    response = await _webApiService.httpClient.PutAsJsonAsync("account/update", updateAppUserDTO);
                }

                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }
            }
        }

        private void checkBoxPasswordReset_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPasswordReset.Checked)
            {
                txtPassword.Enabled = true;
                txtFirstName.Enabled = false;
                txtLastName.Enabled = false;
                txtEmail.Enabled = false;
                txtPhoneNumber.Enabled = false;
                txtCity.Enabled = false;
                txtCountry.Enabled = false;
                txtAddress.Enabled = false;
                txtNationalNumber.Enabled = false;

            }
            else
            {
                txtPassword.Enabled = false;
                txtFirstName.Enabled = true;
                txtLastName.Enabled = true;
                txtEmail.Enabled = true;
                txtPhoneNumber.Enabled = true;
                txtCity.Enabled = true;
                txtCountry.Enabled = true;
                txtAddress.Enabled = true;
                txtNationalNumber.Enabled = true;
            }
        }
    }
}
