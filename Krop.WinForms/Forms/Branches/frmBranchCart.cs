using Krop.Business.Features.Branches.Dtos;
using Krop.WinForms.HelpersClass.BranchHelpers;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Forms.Branches
{
    public partial class frmBranchCart : Form
    {
        private readonly IBranchHelper _branchHelper;
        public Guid Id;

        public frmBranchCart(IBranchHelper branchHelper)
        {
            InitializeComponent();
            _branchHelper = branchHelper;
            txtPhoneNumber.MaxLength = 11;
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private async void frmBranchCart_Load(object sender, EventArgs e)
        {
            await BranchList();
            if (cmbBoxBranchSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxBranchSelect.SelectedValue = Id;
        }
        private async Task BranchList()
        {
            List<GetBranchComboBoxDTO> branches = await _branchHelper.GetAllComboBoxAsync();

            cmbBoxBranchSelect.DataSource = null;

            cmbBoxBranchSelect.DisplayMember = "BranchName";
            cmbBoxBranchSelect.ValueMember = "Id";

            cmbBoxBranchSelect.SelectedIndexChanged -= CmbBoxBranchSelect_SelectedIndexChanged;
            cmbBoxBranchSelect.DataSource = branches;
            cmbBoxBranchSelect.SelectedIndex = -1;
            cmbBoxBranchSelect.SelectedIndexChanged += CmbBoxBranchSelect_SelectedIndexChanged;
        }

        private async void CmbBoxBranchSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxBranchSelect.SelectedValue is not null)
            {
                GetBranchDTO result = await _branchHelper.GetByBranchIdAsync((Guid)cmbBoxBranchSelect.SelectedValue);

                txtPhoneNumber.Text = result.PhoneNumber;
                txtEmail.Text = result.Email;
                txtCountry.Text = result.Country;
                txtCity.Text = result.City;
                txtAddress.Text = result.Addres;
            }
        }
    }
}
