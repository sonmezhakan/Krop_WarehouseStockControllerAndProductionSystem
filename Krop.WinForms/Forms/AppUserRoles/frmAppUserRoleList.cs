using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.WinForms.AppUserRoles
{
    public partial class frmAppUserRoleList : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;

        public frmAppUserRoleList(IWebApiService webApiService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
        }
        private void Search()
        {
            string searchText = txtSearch.Text;
            if (!string.IsNullOrEmpty(searchText))
            {
                var filteredList = appUserRoleListControl._originalData.Where(x =>
                (x.Name != null && x.Name.ToLower().Contains(searchText))
                    );

                appUserRoleListControl._filteredData.Clear();
                foreach (var item in filteredList)
                {
                    appUserRoleListControl._filteredData.Add(item);
                }
            }
            else
            {
                appUserRoleListControl._filteredData.Clear();
                foreach (var item in appUserRoleListControl._originalData)
                {
                    appUserRoleListControl._filteredData.Add(item);
                }
            }
        }
        private async void frmAppUserRoleList_Load(object sender, EventArgs e)
        {
            await appUserRoleListControl.AppUserRoleList(_webApiService);
        }

        private void appUserRoleAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppUserRoleAdd frmAppUserRoleAdd = _serviceProvider.GetRequiredService<frmAppUserRoleAdd>();
            FormController.FormOpenController(frmAppUserRoleAdd);
        }

        private void appUserRoleUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppUserRoleUpdate frmAppUserRoleUpdate = _serviceProvider.GetRequiredService<frmAppUserRoleUpdate>();
            frmAppUserRoleUpdate.Id = (Guid)appUserRoleListControl.DataGridViewAppUserRoleList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmAppUserRoleUpdate);
        }

        private void appUserRoleDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppUserRoleDelete frmAppUserRoleDelete = _serviceProvider.GetRequiredService<frmAppUserRoleDelete>();
            frmAppUserRoleDelete.Id = (Guid)appUserRoleListControl.DataGridViewAppUserRoleList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmAppUserRoleDelete);
        }

        private async void appUserRoleListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await appUserRoleListControl.AppUserRoleList(_webApiService);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
