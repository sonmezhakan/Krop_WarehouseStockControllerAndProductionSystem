using Krop.Common.Helpers.WebApiRequests.Branches;
using Krop.DTO.Dtos.Branches;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Forms.Branches
{
    public partial class frmBranchUpdate : Form
    {
        public Guid Id;
        private readonly IBranchRequest _branchRequest;

        public frmBranchUpdate(IBranchRequest branchRequest)
        {
            InitializeComponent();
            _branchRequest = branchRequest;
        }

        private void frmBranchUpdate_Load(object sender, EventArgs e)
        {
            BranchList();
            txtPhoneNumber.MaxLength = 11;
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

                txtBranchName.Text = result.BranchName;
                txtPhoneNumber.Text = result.PhoneNumber;
                txtEmail.Text = result.Email;
                txtCountry.Text = result.Country;
                txtCity.Text = result.City;
                txtAddress.Text = result.Addres;
            }
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private async void bttnBranchUpdate_Click(object sender, EventArgs e)
        {
            if (cmbBoxBranchSelect.SelectedValue is not null)
            {
                if (DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    UpdateBranchDTO updateBranchDTO = new UpdateBranchDTO
                    {
                        Id = (Guid)cmbBoxBranchSelect.SelectedValue,
                        BranchName = txtBranchName.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        Email = txtEmail.Text,
                        Country = txtCountry.Text,
                        City = txtCity.Text,
                        Addres = txtAddress.Text
                    };
                    HttpResponseMessage response = await _branchRequest.UpdateAsync(updateBranchDTO);

                    if (!response.IsSuccessStatusCode)
                    {
                        ResponseController.ErrorResponseController(response);
                        return;
                    }
                    BranchList();
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
