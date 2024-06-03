using Krop.Common.Helpers.WebApiRequests.AppUsers;
using Krop.DTO.Dtos.AppUserRoles;
using Krop.WinForms.HelpersClass;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Krop.WinForms.AppUserRoles
{
    public partial class frmAppUserRoleList : Form
    {
        private readonly IAppUserRequest _appUserRequest;
        private readonly IServiceProvider _serviceProvider;
        private BindingList<GetAppUserRoleDTO> _originalData;
        private BindingList<GetAppUserRoleDTO> _filteredData;

        public frmAppUserRoleList(IAppUserRequest appUserRequest, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _appUserRequest = appUserRequest;
            _serviceProvider = serviceProvider;
        }

        private void frmAppUserRoleList_Load(object sender, EventArgs e)
        {
            AppUserRoleList();
        }
        private void DgwAppUserRoleListSettings()
        {
            dgwAppUserRoleList.Columns[0].HeaderText = "Id";
            dgwAppUserRoleList.Columns[1].HeaderText = "Yetki Adı";

            dgwAppUserRoleList.Columns[0].Visible = false;
        }
        private async void AppUserRoleList()
        {
            HttpResponseMessage response = await _appUserRequest.GetAllAsync();
            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetAppUserRoleDTO>(response).Data;

            _originalData = new BindingList<GetAppUserRoleDTO>(result);
            _filteredData = new BindingList<GetAppUserRoleDTO>(_originalData.ToList());

            dgwAppUserRoleList.DataSource = _filteredData;

            DgwAppUserRoleListSettings();
        }
        private void Search()
        {
            string searchText = txtSearch.Text;
            if (!string.IsNullOrEmpty(searchText))
            {
                var filteredList = _originalData.Where(x =>
                (x.Name != null && x.Name.ToLower().Contains(searchText))
                    );

                _filteredData.Clear();
                foreach (var item in filteredList)
                {
                    _filteredData.Add(item);
                }
            }
            else
            {
                _filteredData.Clear();
                foreach (var item in _originalData)
                {
                    _filteredData.Add(item);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void bttnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void appUserRoleAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppUserRoleAdd frmAppUserRoleAdd = _serviceProvider.GetRequiredService<frmAppUserRoleAdd>();
            FormController.FormOpenController(frmAppUserRoleAdd);
        }

        private void appUserRoleUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppUserRoleUpdate frmAppUserRoleUpdate = _serviceProvider.GetRequiredService<frmAppUserRoleUpdate>();
            frmAppUserRoleUpdate.Id = (Guid)dgwAppUserRoleList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmAppUserRoleUpdate);
        }

        private void appUserRoleDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppUserRoleDelete frmAppUserRoleDelete = _serviceProvider.GetRequiredService<frmAppUserRoleDelete>();
            frmAppUserRoleDelete.Id = (Guid)dgwAppUserRoleList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmAppUserRoleDelete);
        }

        private void appUserRoleListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppUserRoleList();
        }
    }
}
