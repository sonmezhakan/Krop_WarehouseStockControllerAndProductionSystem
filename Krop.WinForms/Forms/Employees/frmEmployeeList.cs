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
        private BindingList<GetEmployeeListDTO> _orginialData;
        private BindingList<GetEmployeeListDTO> _filteredData;

        public frmEmployeeList(IWebApiService webApiService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
        }

        private async void frmEmployeeList_Load(object sender, EventArgs e)
        {
           await EmployeeList();
        }
        private void DgwEmployeeListSettings()
        {
            dgwEmployeeList.Columns[0].HeaderText = "Id";
            dgwEmployeeList.Columns[1].HeaderText = "Kullanıcı Adı";
            dgwEmployeeList.Columns[2].HeaderText = "Ad";
            dgwEmployeeList.Columns[3].HeaderText = "Soyad";
            dgwEmployeeList.Columns[4].HeaderText = "Departman";
            dgwEmployeeList.Columns[5].HeaderText = "Şube";
            dgwEmployeeList.Columns[6].HeaderText = "Maaş ₺";
            dgwEmployeeList.Columns[7].HeaderText = "T.C. No";
            dgwEmployeeList.Columns[8].HeaderText = "Telefon Numarası";
            dgwEmployeeList.Columns[9].HeaderText = "Email";
            dgwEmployeeList.Columns[10].HeaderText = "Ülke";
            dgwEmployeeList.Columns[11].HeaderText = "Şehir";
            dgwEmployeeList.Columns[12].HeaderText = "Adres";
            dgwEmployeeList.Columns[13].HeaderText = "İşe Başlama Tarihi";
            dgwEmployeeList.Columns[14].HeaderText = "İşten Çıkış Tarihi";
            dgwEmployeeList.Columns[15].HeaderText = "Çalışma Durumu";

            dgwEmployeeList.Columns[0].Visible = false;
        }
        private async Task EmployeeList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("employee/GetAll");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result =await ResponseController.SuccessDataResponseController<List<GetEmployeeListDTO>>(response);

            if(response is not null)
            {
                _orginialData = new BindingList<GetEmployeeListDTO>(result.Data);
                _filteredData = new BindingList<GetEmployeeListDTO>(_orginialData.ToList());

                dgwEmployeeList.DataSource = _filteredData;
                DgwEmployeeListSettings();
            }
        }
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = _orginialData.Where(x =>
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

                _filteredData.Clear();
                foreach (var item in filteredList)
                {
                    _filteredData.Add(item);
                }
            }
            else
            {
                _filteredData.Clear();
                foreach (var item in _orginialData)
                {
                    _filteredData.Add(item);
                }
            }
        }

        private void EmployeeCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeCart frmEmployeeCart = _serviceProvider.GetRequiredService<frmEmployeeCart>();
            frmEmployeeCart.Id = (Guid)dgwEmployeeList.SelectedRows[0].Cells[0].Value;
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
            frmEmployeeUpdate.Id = (Guid)dgwEmployeeList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmEmployeeUpdate);
        }

        private async void EmployeeListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
           await EmployeeList();
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
