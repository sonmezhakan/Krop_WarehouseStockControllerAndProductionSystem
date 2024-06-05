using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Branches;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.UserControllers.Branches
{
    public partial class BranchComboBoxControl : UserControl
    {
        public BranchComboBoxControl()
        {
            InitializeComponent();
        }
        public async Task BranchList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("branch/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetBranchComboBoxDTO>>(response);

            cmbBoxBranchSelect.DataSource = null;

            cmbBoxBranchSelect.DisplayMember = "BranchName";
            cmbBoxBranchSelect.ValueMember = "Id";

            cmbBoxBranchSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxBranchSelect.SelectedIndex = -1;
        }
        public void BranchSelect(Guid id)
        {
            if (cmbBoxBranchSelect.DataSource != null && id != Guid.Empty)
                cmbBoxBranchSelect.SelectedValue = id;
        }
        public ComboBox BranchComboBox
        {
            get { return cmbBoxBranchSelect; }
        }
    }
}
