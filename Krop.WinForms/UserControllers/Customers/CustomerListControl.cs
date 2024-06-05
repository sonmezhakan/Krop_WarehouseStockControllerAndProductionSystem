using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Customers;
using Krop.WinForms.HelpersClass;
using System.ComponentModel;

namespace Krop.WinForms.UserControllers.Customers
{
    public partial class CustomerListControl : UserControl
    {
        public BindingList<GetCustomerDTO> _originalData;
        public BindingList<GetCustomerDTO> _filteredData;
        public CustomerListControl()
        {
            InitializeComponent();
        }

        private void DgwCustomerListSettings()
        {
            dgwCustomerList.Columns[0].HeaderText = "Id";
            dgwCustomerList.Columns[1].HeaderText = "Bireysel/Kurumsal";
            dgwCustomerList.Columns[2].HeaderText = "Müşteri Adı";
            dgwCustomerList.Columns[3].HeaderText = "İletişim Kurulacak Kişi";
            dgwCustomerList.Columns[4].HeaderText = "İletişim Kurulacak Kişinin Departmanı";
            dgwCustomerList.Columns[5].HeaderText = "Telefon Numarası";
            dgwCustomerList.Columns[6].HeaderText = "Email";
            dgwCustomerList.Columns[7].HeaderText = "Ülke";
            dgwCustomerList.Columns[8].HeaderText = "Şehir";
            dgwCustomerList.Columns[9].HeaderText = "Adres";

            dgwCustomerList.Columns[0].Visible = false;
        }
        public async Task CustomerList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("customer/getall");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetCustomerDTO>>(response);

            if (result is not null)
            {
                _originalData = new BindingList<GetCustomerDTO>(result.Data);
                _filteredData = new BindingList<GetCustomerDTO>(_originalData.ToList());

                dgwCustomerList.DataSource = _filteredData;

                DgwCustomerListSettings();
            }
        }
        public DataGridView DataGridViewCustomerList
        {
            get { return dgwCustomerList; }
        }
    }
}
