using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Employees;
using Krop.WinForms.HelpersClass;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Krop.WinForms.Forms.Employees
{
    public partial class frmEmployeeList : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;

        public frmEmployeeList(IWebApiService webApiService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
        }

        private async void frmEmployeeList_Load(object sender, EventArgs e)
        {
            await employeeListControl.EmployeeList(_webApiService);
        }
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = employeeListControl._orginialData.Where(x =>
                    (x.Username != null && x.Username.ToLower().Contains(searchText)) ||
                    (x.FirstName != null && x.FirstName.ToLower().Contains(searchText)) ||
                    (x.LastName != null && x.LastName.ToLower().Contains(searchText)) ||
                    (x.DepartmentName != null && x.DepartmentName.ToLower().Contains(searchText)) ||
                    (x.BranchName != null && x.BranchName.ToLower().Contains(searchText)) ||
                    (x.Salary != null && x.Salary.ToString().Contains(searchText)) ||
                    (x.NationalNumber != null && x.NationalNumber.ToLower().Contains(searchText)) ||
                    (x.PhoneNumber != null && x.PhoneNumber.ToLower().Contains(searchText)) ||
                    (x.Email != null && x.Email.ToLower().Contains(searchText)) ||
                    (x.Country != null && x.Country.ToLower().Contains(searchText)) ||
                    (x.City != null && x.City.ToLower().Contains(searchText)) ||
                    (x.Adress != null && x.Adress.ToLower().Contains(searchText)) ||
                    (x.StartDateOfWork != null && x.StartDateOfWork.ToString().Contains(searchText)) ||
                    (x.EndDateOfWork != null && x.EndDateOfWork.ToString().Contains(searchText))
                    );

                employeeListControl._filteredData.Clear();
                foreach (var item in filteredList)
                {
                    employeeListControl._filteredData.Add(item);
                }
            }
            else
            {
                employeeListControl._filteredData.Clear();
                foreach (var item in employeeListControl._orginialData)
                {
                    employeeListControl._filteredData.Add(item);
                }
            }
        }

        private void EmployeeCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeCart frmEmployeeCart = _serviceProvider.GetRequiredService<frmEmployeeCart>();
            frmEmployeeCart.Id = (Guid)employeeListControl.DataGridViewEmployee.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmEmployeeCart);
        }

        private void EmployeeAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeAdd frmEmployeeAdd = _serviceProvider.GetRequiredService<frmEmployeeAdd>();
            FormController.FormOpenController(frmEmployeeAdd);
        }

        private void EmployeeUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeUpdate frmEmployeeUpdate = _serviceProvider.GetRequiredService<frmEmployeeUpdate>();
            frmEmployeeUpdate.Id = (Guid)employeeListControl.DataGridViewEmployee.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmEmployeeUpdate);
        }

        private async void EmployeeListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await employeeListControl.EmployeeList(_webApiService);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void bttnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}
