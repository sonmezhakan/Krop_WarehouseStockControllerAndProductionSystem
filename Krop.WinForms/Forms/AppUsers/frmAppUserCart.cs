using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.AppUsers;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Forms.AppUsers
{
    public partial class frmAppUserCart : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmAppUserCart(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private void txtNationalNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private async void frmAppUserCart_Load(object sender, EventArgs e)
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
                if (!response.IsSuccessStatusCode)
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

        private async void bttnActivasyonMailSender_Click(object sender, EventArgs e)
        {
            if (appUserComboBoxControl.AppUserComboBox.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"account/ConfirmationMailSender/{(Guid)appUserComboBoxControl.AppUserComboBox.SelectedValue}");

                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }
            }
        }

        private async void bttnPasswordResetMailSender_Click(object sender, EventArgs e)
        {
            if (appUserComboBoxControl.AppUserComboBox.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"account/ResetPasswordMailSender/{(Guid)appUserComboBoxControl.AppUserComboBox.SelectedValue}");

                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }
            }
        }
    }
}
