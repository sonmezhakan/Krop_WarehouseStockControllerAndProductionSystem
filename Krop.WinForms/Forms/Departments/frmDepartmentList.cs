using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Departments;
using Krop.WinForms.HelpersClass;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Krop.WinForms.Forms.Departments
{
    public partial class frmDepartmentList : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;
        private BindingList<GetDepartmentDTO> _originalData;
        private BindingList<GetDepartmentDTO> _filteredData;

        public frmDepartmentList(IWebApiService webApiService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
        }

        private async void frmDepartmentList_Load(object sender, EventArgs e)
        {
            await DepartmentList();
        }
        private void DgwDepartmentListSettings()
        {
            dgwDepartmentList.Columns[0].HeaderText = "Id";
            dgwDepartmentList.Columns[1].HeaderText = "Departman Adı";
            dgwDepartmentList.Columns[2].HeaderText = "Açıklama";

            dgwDepartmentList.Columns[0].Visible = false;
        }
        private async Task DepartmentList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("department/getall");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result =await ResponseController.SuccessDataResponseController<List<GetDepartmentDTO>>(response);

            if(result is not null)
            {
                _originalData = new BindingList<GetDepartmentDTO>(result.Data);
                _filteredData = new BindingList<GetDepartmentDTO>(_originalData.ToList());

                dgwDepartmentList.DataSource = _filteredData;

                DgwDepartmentListSettings();
            }
        }
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = _originalData.Where(d =>

                    (d.DepartmentName != null && d.DepartmentName.ToLower().Contains(searchText)) ||
                    (d.Description != null && d.Description.ToLower().Contains(searchText))
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

        private void departmentCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartmentCart frmDepartmentCart = _serviceProvider.GetRequiredService<frmDepartmentCart>();
            frmDepartmentCart.Id = (Guid)dgwDepartmentList.SelectedRows[0].Cells[0].Value;
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
            frmDepartmentUpdate.Id = (Guid)dgwDepartmentList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmDepartmentUpdate);
        }

        private void departmentDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartmentDelete frmDepartmentDelete = _serviceProvider.GetRequiredService<frmDepartmentDelete>();
            frmDepartmentDelete.Id = (Guid)dgwDepartmentList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmDepartmentDelete);
        }

        private async void departmentListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
           await DepartmentList();
        }
    }
}
