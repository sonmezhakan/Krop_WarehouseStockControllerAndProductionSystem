using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Branches;
using Krop.WinForms.HelpersClass;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Krop.WinForms.Forms.Branches
{
    public partial class frmBranchList : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;

        public frmBranchList(IWebApiService webApiService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
        }

        private async void frmBranchList_Load(object sender, EventArgs e)
        {
            await branchListControl.BranchList(_webApiService);
        }
       
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = branchListControl._originalData.Where(x =>
                (x.BranchName != null && x.BranchName.ToLower().Contains(searchText)) ||
                (x.PhoneNumber != null && x.PhoneNumber.ToString().Contains(searchText)) ||
                (x.Email != null && x.Email.ToLower().Contains(searchText)) ||
                (x.Country != null && x.Country.ToLower().Contains(searchText)) ||
                (x.City != null && x.City.ToLower().Contains(searchText)) ||
                (x.Addres != null && x.Addres.ToLower().Contains(searchText))
                );

                branchListControl._filteredData.Clear();
                foreach (var item in filteredList)
                {
                    branchListControl._filteredData.Add(item);
                }
            }
            else
            {
                branchListControl._filteredData.Clear();
                foreach (var item in branchListControl._originalData)
                {
                    branchListControl._filteredData.Add(item);
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

        private void branchCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBranchCart frmBranchCart = _serviceProvider.GetRequiredService<frmBranchCart>();
            frmBranchCart.Id = (Guid)branchListControl.DataGridViewBranchList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmBranchCart);
        }

        private void branchAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBranchAdd frmBranchAdd = _serviceProvider.GetRequiredService<frmBranchAdd>();
            FormController.FormOpenController(frmBranchAdd);
        }

        private void branchUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBranchUpdate frmBranchUpdate = _serviceProvider.GetRequiredService<frmBranchUpdate>();
            frmBranchUpdate.Id = (Guid)branchListControl.DataGridViewBranchList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmBranchUpdate);
        }

        private void branchDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBranchDelete frmBranchDelete = _serviceProvider.GetRequiredService<frmBranchDelete>();
            frmBranchDelete.Id = (Guid)branchListControl.DataGridViewBranchList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmBranchDelete);
        }

        private async void branchListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await branchListControl.BranchList(_webApiService);
        }
    }
}
