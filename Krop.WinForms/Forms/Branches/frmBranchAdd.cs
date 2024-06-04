using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Branches;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.Branches
{
    public partial class frmBranchAdd : Form
    {
        private readonly IWebApiService _webApiService;

        public frmBranchAdd(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private void frmBranchAdd_Load(object sender, EventArgs e)
        {
            txtPhoneNumber.MaxLength = 11;
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(this, e);
        }

        private async void bttnBranchAdd_Click(object sender, EventArgs e)
        {
            CreateBranchDTO createBranchDTO = new CreateBranchDTO
            {
                BranchName = txtBranchName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Email = txtEmail.Text,
                Country = txtCountry.Text,
                City = txtCity.Text,
                Addres = txtAddress.Text
            };

            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("branch/add", createBranchDTO);

            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }
        }
    }
}
