using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Employees;
using Krop.WinForms.HelpersClass;
using System.ComponentModel;

namespace Krop.WinForms.UserControllers.Employees
{
    public partial class EmployeeListControl : UserControl
    {
        public BindingList<GetEmployeeListDTO> _orginialData;
        public BindingList<GetEmployeeListDTO> _filteredData;
        public EmployeeListControl()
        {
            InitializeComponent();
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
        public async Task EmployeeList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("employee/GetAll");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetEmployeeListDTO>>(response);

            if (response is not null)
            {
                _orginialData = new BindingList<GetEmployeeListDTO>(result.Data);
                _filteredData = new BindingList<GetEmployeeListDTO>(_orginialData.ToList());

                dgwEmployeeList.DataSource = _filteredData;
                DgwEmployeeListSettings();
            }
        }
        public DataGridView DataGridViewEmployee
        {
            get { return dgwEmployeeList; }
        }
    }
}
