using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.AppUsers;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using Krop.WinForms.UserControllers.AppUsers;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.AppUsers
{
    public partial class frmAppUserUpdate : Form
    {
        
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmAppUserUpdate(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private async void frmAppUserUpdate_Load(object sender, EventArgs e)
        {
            txtPhoneNumber.MaxLength = 11;
            await appUserComboBoxControl.AppUserList(_webApiService);
            appUserComboBoxControl.AppUserComboBox.SelectedIndexChanged += CmbBoxAppUserSelect_SelectedIndexChanged;
            appUserComboBoxControl.AppUserSelected(Id);
        }

        private async void CmbBoxAppUserSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (appUserComboBoxControl.AppUserComboBox.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"account/GetById/{(Guid)appUserComboBoxControl.AppUserComboBox.SelectedValue}"); 
                if(!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                var result = await ResponseController.SuccessDataResponseController<GetAppUserDTO>(response);

                if (result is not null)
                {
                    txtFirstName.Text = result.Data.FirstName;
                    txtLastName.Text = result.Data.LastName;
                    txtEmail.Text = result.Data.Email;
                    txtPhoneNumber.Text = result.Data.PhoneNumber;
                    txtCity.Text = result.Data.City;
                    txtCountry.Text = result.Data.Country;
                    txtAddress.Text = result.Data.Addres;
                    txtNationalNumber.Text = result.Data.NationalNumber;
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

        private void txtNationalNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private async void bttnAppUserUpdate_Click(object sender, EventArgs e)
        {
            if (appUserComboBoxControl.AppUserComboBox.SelectedValue is not null)
            {
                if(DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response;
                    if (checkBoxPasswordReset.Checked)
                    {
                        UpdateAppUserPasswordDTO updateAppUserPasswordDTO = new UpdateAppUserPasswordDTO
                        {
                            Id = (Guid)appUserComboBoxControl.AppUserComboBox.SelectedValue,
                            Password = txtPassword.Text
                        };

                        response = await _webApiService.httpClient.PutAsJsonAsync("account/UpdatePassword", updateAppUserPasswordDTO);
                    }
                    else
                    {
                        UpdateAppUserDTO updateAppUserDTO = new UpdateAppUserDTO
                        {
                            Id = (Guid)appUserComboBoxControl.AppUserComboBox.SelectedValue,
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
                    await appUserComboBoxControl.AppUserList(_webApiService);
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
