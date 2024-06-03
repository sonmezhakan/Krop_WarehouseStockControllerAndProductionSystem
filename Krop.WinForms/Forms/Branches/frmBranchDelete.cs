using Krop.Common.Helpers.WebApiRequests.Branches;
using Krop.DTO.Dtos.Branches;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Forms.Branches
{
    public partial class frmBranchDelete : Form
    {
        public Guid Id;
        private readonly IBranchRequest _branchRequest;

        public frmBranchDelete(IBranchRequest branchRequest)
        {
            InitializeComponent();
            _branchRequest = branchRequest;
        }

        private void frmBranchDelete_Load(object sender, EventArgs e)
        {
            BranchList();
            if (cmbBoxBranchSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxBranchSelect.SelectedValue = Id;
        }
        private async void BranchList()
        {
            HttpResponseMessage response = await _branchRequest.GetAllAsync();
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

        private void CmbBoxBranchSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {

        }

        private async void bttnBranchDelete_Click(object sender, EventArgs e)
        {
            if(cmbBoxBranchSelect.SelectedValue is not null)
            {
                if(DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = await _branchRequest.DeleteAsync((Guid)cmbBoxBranchSelect.SelectedValue);

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
                MessageBox.Show("Doğru Seçim Yapınız!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
