using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.AppUsers;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.UserControllers.AppUsers
{
    public partial class AppUserComboBoxControl : UserControl
    {
        public AppUserComboBoxControl()
        {
            InitializeComponent();
        }
        public async Task AppUserList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("account/getAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetAppUserComboBoxDTO>>(response);

            cmbBoxAppUserSelect.DataSource = null;

            cmbBoxAppUserSelect.DisplayMember = "UserName";
            cmbBoxAppUserSelect.ValueMember = "Id";

            cmbBoxAppUserSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxAppUserSelect.SelectedIndex = -1;
        }
        public void AppUserSelected(Guid id)
        {
            if (cmbBoxAppUserSelect.DataSource != null && id != Guid.Empty)
                cmbBoxAppUserSelect.SelectedValue = id;
        }

        public ComboBox AppUserComboBox
        {
            get { return cmbBoxAppUserSelect; }
        }
    }
}
