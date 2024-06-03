using Krop.Common.Helpers.WebApiRequests.Branches;
using Krop.DTO.Dtos.Branches;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Forms.Branches
{
    public partial class frmBranchAdd : Form
    {
        private readonly IBranchRequest _branchRequest;

        public frmBranchAdd(IBranchRequest branchRequest)
        {
            InitializeComponent();
            _branchRequest = branchRequest;
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

            HttpResponseMessage response = await _branchRequest.AddAsync(createBranchDTO);

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }
        }
    }
}
