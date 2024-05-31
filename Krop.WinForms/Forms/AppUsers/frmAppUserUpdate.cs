using Krop.Business.Features.AppUsers.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.AppUserHelpers;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.AppUsers
{
    public partial class frmAppUserUpdate : Form
    {
        private readonly IAppUserHelper _appUserHelper;
        private readonly IWebApiService _webApiService;
        public Guid Id;

        public frmAppUserUpdate(IAppUserHelper appUserHelper, IWebApiService webApiService)
        {
            InitializeComponent();
            _appUserHelper = appUserHelper;
            _webApiService = webApiService;
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private void frmAppUserUpdate_Load(object sender, EventArgs e)
        {
            AppUserList();
            txtPhoneNumber.MaxLength = 11;
            if (cmbBoxAppUserSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxAppUserSelect.SelectedValue = Id;
        }

        private void AppUserList()
        {
            var result = _appUserHelper.GetAllComboBoxAsync();
            if (result is null)
                return;


            cmbBoxAppUserSelect.DataSource = null;

            cmbBoxAppUserSelect.DisplayMember = "UserName";
            cmbBoxAppUserSelect.ValueMember = "Id";

            cmbBoxAppUserSelect.SelectedIndexChanged -= CmbBoxAppUserSelect_SelectedIndexChanged;
            cmbBoxAppUserSelect.DataSource = result;
            cmbBoxAppUserSelect.SelectedIndex = -1;
            cmbBoxAppUserSelect.SelectedIndexChanged += CmbBoxAppUserSelect_SelectedIndexChanged;
        }

        private void CmbBoxAppUserSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxAppUserSelect.SelectedValue is not null)
            {
                var result = _appUserHelper.GetByAppUserIdAsync((Guid)cmbBoxAppUserSelect.SelectedValue);
                if (result is null)
                    return;

                txtFirstName.Text = result.FirstName;
                txtLastName.Text = result.LastName;
                txtEmail.Text = result.Email;
                txtPhoneNumber.Text = result.PhoneNumber;
                txtCity.Text = result.City;
                txtCountry.Text = result.Country;
                txtAddress.Text = result.Addres;
                txtNationalNumber.Text = result.NationalNumber;
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
            if (cmbBoxAppUserSelect.SelectedValue is not null)
            {
                if(DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response;
                    if (checkBoxPasswordReset.Checked)
                    {
                        UpdateAppUserPasswordDTO updateAppUserPasswordDTO = new UpdateAppUserPasswordDTO
                        {
                            Id = (Guid)cmbBoxAppUserSelect.SelectedValue,
                            Password = txtPassword.Text
                        };

                        response = _webApiService.httpClient.PutAsJsonAsync("account/UpdatePassword", updateAppUserPasswordDTO).Result;
                    }
                    else
                    {
                        UpdateAppUserDTO updateAppUserDTO = new UpdateAppUserDTO
                        {
                            Id = (Guid)cmbBoxAppUserSelect.SelectedValue,
                            FirstName = txtFirstName.Text,
                            LastName = txtLastName.Text,
                            Email = txtEmail.Text,
                            PhoneNumber = txtPhoneNumber.Text,
                            City = txtCity.Text,
                            Country = txtCountry.Text,
                            Addres = txtAddress.Text,
                            NationalNumber = txtNationalNumber.Text
                        };

                        response = _webApiService.httpClient.PutAsJsonAsync("account/update", updateAppUserDTO).Result;
                    }

                    if (!response.IsSuccessStatusCode)
                    {
                        ResponseController.ErrorResponseController(response);
                        return;
                    }
                    AppUserList();
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
