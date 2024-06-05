using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.WinForms.Forms.AppUsers
{
    public partial class frmAppUserList : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IWebApiService _webApiService;


        public frmAppUserList(IServiceProvider serviceProvider,IWebApiService webApiService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _webApiService = webApiService;
        }

        private async void frmAppUserList_Load(object sender, EventArgs e)
        {
            await appUserListControl.AppUserList(_webApiService);
        }
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = appUserListControl._originalData.Where(x =>
                    x.UserName.ToLower().Contains(searchText) ||
                    x.FirstName.ToLower().Contains(searchText) ||
                    x.LastName.ToLower().Contains(searchText) ||
                    x.Email.ToLower().Contains(searchText) ||
                    x.PhoneNumber.ToString().Contains(searchText) ||
                    (x.NationalNumber != null && x.NationalNumber.ToString().Contains(searchText)) ||
                    (x.Country != null && x.Country.ToLower().Contains(searchText)) ||
                    (x.City != null && x.City.ToLower().Contains(searchText)) ||
                    (x.Addres != null && x.Addres.ToLower().Contains(searchText)));

                appUserListControl._filteredData.Clear();
                foreach (var item in filteredList)
                {
                    appUserListControl._filteredData.Add(item);
                }
            }
            else
            {
                appUserListControl._filteredData.Clear();
                foreach (var item in appUserListControl._originalData)
                {
                    appUserListControl._filteredData.Add(item);
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

        private void appUserCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppUserCart frmAppUserCart = _serviceProvider.GetRequiredService<frmAppUserCart>();
            frmAppUserCart.Id = (Guid)appUserListControl.DataGridViewAppUserList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmAppUserCart);
        }

        private void appUserAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppUserAdd frmAppUserAdd = _serviceProvider.GetRequiredService<frmAppUserAdd>();
            FormController.FormOpenController(frmAppUserAdd);
        }

        private void appUserUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppUserUpdate frmAppUserUpdate = _serviceProvider.GetRequiredService<frmAppUserUpdate>();
            frmAppUserUpdate.Id = (Guid)appUserListControl.DataGridViewAppUserList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmAppUserUpdate);
        }

        private async void appUserListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await appUserListControl.AppUserList(_webApiService);
        }
    }
}
