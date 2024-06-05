using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Departments;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.UserControllers.Customers;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Krop.WinForms.Forms.Departments
{
    public partial class frmDepartmentList : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;

        public frmDepartmentList(IWebApiService webApiService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
        }

        private async void frmDepartmentList_Load(object sender, EventArgs e)
        {
            await departmentListControl.DepartmentList(_webApiService);
        }
       
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = departmentListControl._originalData.Where(d =>

                    (d.DepartmentName != null && d.DepartmentName.ToLower().Contains(searchText)) ||
                    (d.Description != null && d.Description.ToLower().Contains(searchText))
               );

                departmentListControl._filteredData.Clear();
                foreach (var item in filteredList)
                {
                    departmentListControl._filteredData.Add(item);
                }
            }
            else
            {
                departmentListControl._filteredData.Clear();
                foreach (var item in departmentListControl._originalData)
                {
                    departmentListControl._filteredData.Add(item);
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

        private void departmentCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartmentCart frmDepartmentCart = _serviceProvider.GetRequiredService<frmDepartmentCart>();
            frmDepartmentCart.Id = (Guid)departmentListControl.DataGridViewDepartmentList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmDepartmentCart);
        }

        private void departmentAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartmentAdd frmDepartmentAdd = _serviceProvider.GetRequiredService<frmDepartmentAdd>();
            FormController.FormOpenController(frmDepartmentAdd);
        }

        private void departmentUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartmentUpdate frmDepartmentUpdate = _serviceProvider.GetRequiredService<frmDepartmentUpdate>();
            frmDepartmentUpdate.Id = (Guid)departmentListControl.DataGridViewDepartmentList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmDepartmentUpdate);
        }

        private void departmentDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartmentDelete frmDepartmentDelete = _serviceProvider.GetRequiredService<frmDepartmentDelete>();
            frmDepartmentDelete.Id = (Guid)departmentListControl.DataGridViewDepartmentList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmDepartmentDelete);
        }

        private async void departmentListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await departmentListControl.DepartmentList(_webApiService);
        }
    }
}
