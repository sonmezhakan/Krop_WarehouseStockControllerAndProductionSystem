using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.AppUserHelpers;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Forms.AppUsers
{
    public partial class frmAppUserCart : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IAppUserHelper _appUserHelper;
        public Guid Id;

        public frmAppUserCart(IWebApiService webApiService, IAppUserHelper appUserHelper)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _appUserHelper = appUserHelper;
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

        private void bttnActivasyonMailSender_Click(object sender, EventArgs e)
        {
            if (cmbBoxAppUserSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = _webApiService.httpClient.GetAsync($"account/ConfirmationMailSender/{cmbBoxAppUserSelect.SelectedValue}").Result;

                if (!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }
            }
        }

        private void bttnPasswordResetMailSender_Click(object sender, EventArgs e)
        {
            if(cmbBoxAppUserSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = _webApiService.httpClient.GetAsync($"account/ResetPasswordMailSender/{cmbBoxAppUserSelect.SelectedValue}").Result;

                if (!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }
            }
        }
    }
}
