using Krop.Common.Helpers.WebApiRequests.AppUsers;
using Krop.DTO.Dtos.AppUsers;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Forms.AppUsers
{
    public partial class frmAppUserCart : Form
    {
        public Guid Id;
        private readonly IAppUserRequest _appUserRequest;

        public frmAppUserCart(IAppUserRequest appUserRequest)
        {
            InitializeComponent();
            _appUserRequest = appUserRequest;
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private void txtNationalNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private void frmAppUserCart_Load(object sender, EventArgs e)
        {
            AppUserList();
            txtPhoneNumber.MaxLength = 11;
            if (cmbBoxAppUserSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxAppUserSelect.SelectedValue = Id;
        }
        private async void AppUserList()
        {
            HttpResponseMessage response = await _appUserRequest.GetAllComboBoxAsync();
            if(!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetAppUserComboBoxDTO>(response).Data;

            cmbBoxAppUserSelect.DataSource = null;

            cmbBoxAppUserSelect.DisplayMember = "UserName";
            cmbBoxAppUserSelect.ValueMember = "Id";

            cmbBoxAppUserSelect.SelectedIndexChanged -= CmbBoxAppUserSelect_SelectedIndexChanged;
            cmbBoxAppUserSelect.DataSource = result;
            cmbBoxAppUserSelect.SelectedIndex = -1;
            cmbBoxAppUserSelect.SelectedIndexChanged += CmbBoxAppUserSelect_SelectedIndexChanged;
        }

        private async void CmbBoxAppUserSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxAppUserSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = await _appUserRequest.GetByAppUserIdAsync((Guid)cmbBoxAppUserSelect.SelectedValue);
                if(!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                var result = ResponseController.SuccessDataResponseController<GetAppUserDTO>(response).Data;

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

        private async void bttnActivasyonMailSender_Click(object sender, EventArgs e)
        {
            if (cmbBoxAppUserSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = await _appUserRequest.ConfirmationMailSender((Guid)cmbBoxAppUserSelect.SelectedValue);

                if (!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }
            }
        }

        private async void bttnPasswordResetMailSender_Click(object sender, EventArgs e)
        {
            if(cmbBoxAppUserSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = await _appUserRequest.ResetPasswordMailSender((Guid)cmbBoxAppUserSelect.SelectedValue);

                if (!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }
            }
        }
    }
}
