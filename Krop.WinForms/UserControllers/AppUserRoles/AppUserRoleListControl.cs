using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.AppUserRoles;
using Krop.WinForms.HelpersClass;
using System.ComponentModel;

namespace Krop.WinForms.UserControllers.AppUserRoles
{
    public partial class AppUserRoleListControl : UserControl
    {
        public BindingList<GetAppUserRoleDTO> _originalData;
        public BindingList<GetAppUserRoleDTO> _filteredData;
        public AppUserRoleListControl()
        {
            InitializeComponent();
        }
        private void DgwAppUserRoleListSettings()
        {
            dgwAppUserRoleList.Columns[0].HeaderText = "Id";
            dgwAppUserRoleList.Columns[1].HeaderText = "Yetki Adı";

            dgwAppUserRoleList.Columns[0].Visible = false;
        }
        public async Task AppUserRoleList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("AppUserRole/GetAll");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetAppUserRoleDTO>>(response);

            if (result is not null)
            {
                _originalData = new BindingList<GetAppUserRoleDTO>(result.Data);
                _filteredData = new BindingList<GetAppUserRoleDTO>(_originalData.ToList());

                dgwAppUserRoleList.DataSource = _filteredData;

                DgwAppUserRoleListSettings();
            }
        }
   
        public DataGridView DataGridViewAppUserRoleList
        {
            get { return dgwAppUserRoleList; }
        }
    }
}
