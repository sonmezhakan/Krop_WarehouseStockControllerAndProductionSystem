using Krop.Common.Helpers.WebApiRequests.Branches;
using Krop.DTO.Dtos.Branches;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Forms.Branches
{
    public partial class frmBranchCart : Form
    {
        public Guid Id;
        private readonly IBranchRequest _branchRequest;

        public frmBranchCart(IBranchRequest branchRequest)
        {
            InitializeComponent();
            txtPhoneNumber.MaxLength = 11;
            _branchRequest = branchRequest;
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private void frmBranchCart_Load(object sender, EventArgs e)
        {
            BranchList();
            if (cmbBoxBranchSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxBranchSelect.SelectedValue = Id;
        }
        private async void BranchList()
        {
            HttpResponseMessage response = await _branchRequest.GetAllComboBoxAsync();
            if(!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetBranchComboBoxDTO>(response).Data;

            cmbBoxBranchSelect.DataSource = null;

            cmbBoxBranchSelect.DisplayMember = "BranchName";
            cmbBoxBranchSelect.ValueMember = "Id";

            cmbBoxBranchSelect.SelectedIndexChanged -= CmbBoxBranchSelect_SelectedIndexChanged;
            cmbBoxBranchSelect.DataSource = result;
            cmbBoxBranchSelect.SelectedIndex = -1;
            cmbBoxBranchSelect.SelectedIndexChanged += CmbBoxBranchSelect_SelectedIndexChanged;
        }

        private async void CmbBoxBranchSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxBranchSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = await _branchRequest.GetByIdAsync((Guid)cmbBoxBranchSelect.SelectedValue);
                if(!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                var result = ResponseController.SuccessDataResponseController<GetBranchDTO>(response).Data;

                txtPhoneNumber.Text = result.PhoneNumber;
                txtEmail.Text = result.Email;
                txtCountry.Text = result.Country;
                txtCity.Text = result.City;
                txtAddress.Text = result.Addres;
            }
        }
    }
}
