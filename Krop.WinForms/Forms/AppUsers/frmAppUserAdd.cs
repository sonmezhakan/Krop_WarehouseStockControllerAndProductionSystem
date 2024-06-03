using Krop.Common.Helpers.WebApiRequests.AppUsers;
using Krop.DTO.Dtos.AppUsers;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Forms.AppUsers
{
    public partial class frmAppUserAdd : Form
    {
        private readonly IAppUserRequest _appUserRequest;

        public frmAppUserAdd(IAppUserRequest appUserRequest)
        {
            InitializeComponent();
            _appUserRequest = appUserRequest;
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private void frmAppUserAdd_Load(object sender, EventArgs e)
        {
            txtPhoneNumber.MaxLength = 11;
        }

        private async void bttnAppUserAdd_Click(object sender, EventArgs e)
        {
            CreateAppUserDTO createAppUserDTO = new CreateAppUserDTO
            {
                UserName = txtUserName.Text,
                Password = txtPassword.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                NationalNumber = txtNationalNumber.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Country = txtCountry.Text,
                City = txtCity.Text,
                Addres = txtAddress.Text
            };

            var response = await _appUserRequest.AddAsync(createAppUserDTO);

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }
        }

        private void txtNationalNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }
    }
}
