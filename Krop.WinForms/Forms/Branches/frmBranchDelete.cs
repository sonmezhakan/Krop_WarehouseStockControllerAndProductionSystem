using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Branches;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using Krop.WinForms.UserControllers.Branches;

namespace Krop.WinForms.Forms.Branches
{
    public partial class frmBranchDelete : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmBranchDelete(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmBranchDelete_Load(object sender, EventArgs e)
        {
            await branchComboBoxControl.BranchList(_webApiService);
            branchComboBoxControl.BranchSelect(Id);
        }
        private async void bttnBranchDelete_Click(object sender, EventArgs e)
        {
            if(branchComboBoxControl.BranchComboBox.SelectedValue is not null)
            {
                if(DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"branch/delete/{(Guid)branchComboBoxControl.BranchComboBox.SelectedValue}");

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                    await branchComboBoxControl.BranchList(_webApiService);
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
