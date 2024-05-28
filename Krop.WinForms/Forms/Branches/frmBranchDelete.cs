using Krop.Business.Features.Branches.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.BranchHelpers;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Forms.Branches
{
    public partial class frmBranchDelete : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IBranchHelper _branchHelper;
        public Guid Id;

        public frmBranchDelete(IWebApiService webApiService, IBranchHelper branchHelper)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _branchHelper = branchHelper;
        }

        private void frmBranchDelete_Load(object sender, EventArgs e)
        {
            BranchList();
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

        }

        private void bttnBranchDelete_Click(object sender, EventArgs e)
        {
            if(cmbBoxBranchSelect.SelectedValue is not null)
            {
                if(DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = _webApiService.httpClient.DeleteAsync($"branch/delete/{cmbBoxBranchSelect.SelectedValue}").Result;

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
