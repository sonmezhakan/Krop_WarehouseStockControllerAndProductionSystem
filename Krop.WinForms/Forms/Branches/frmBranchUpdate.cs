using Krop.Business.Features.Branches.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Utilits.Result;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.BranchHelpers;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.Branches
{
    public partial class frmBranchUpdate : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IBranchHelper _branchHelper;
        public Guid Id;

        public frmBranchUpdate(IWebApiService webApiService, IBranchHelper branchHelper)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _branchHelper = branchHelper;
        }

        private void frmBranchUpdate_Load(object sender, EventArgs e)
        {
            BranchList();
            txtPhoneNumber.MaxLength = 11;
            if (cmbBoxBranchSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxBranchSelect.SelectedValue = Id;
        }
        private void BranchList()
        {
            List<GetBranchComboBoxDTO> result = _branchHelper.GetAllComboBoxAsync();
            if (result is null)
                return;

            cmbBoxBranchSelect.DataSource = null;

            cmbBoxBranchSelect.DisplayMember = "BranchName";
            cmbBoxBranchSelect.ValueMember = "Id";

            cmbBoxBranchSelect.SelectedIndexChanged -= CmbBoxBranchSelect_SelectedIndexChanged;
            cmbBoxBranchSelect.DataSource = result;
            cmbBoxBranchSelect.SelectedIndex = -1;
            cmbBoxBranchSelect.SelectedIndexChanged += CmbBoxBranchSelect_SelectedIndexChanged;
        }

        private void CmbBoxBranchSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxBranchSelect.SelectedValue is not null)
            {
                GetBranchDTO result = _branchHelper.GetByBranchIdAsync((Guid)cmbBoxBranchSelect.SelectedValue);
                if (result is null)
                    return;

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

        private void bttnBranchUpdate_Click(object sender, EventArgs e)
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
                    HttpResponseMessage response = _webApiService.httpClient.PutAsJsonAsync("branch/update", updateBranchDTO).Result;

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
