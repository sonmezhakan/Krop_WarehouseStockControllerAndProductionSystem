using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Suppliers;
using Krop.WinForms.HelpersClass;
using System.ComponentModel;

namespace Krop.WinForms.UserControllers.Suppliers
{
    public partial class SupplierListControl : UserControl
    {
        public BindingList<GetSupplierDTO> _originalData;
        public BindingList<GetSupplierDTO> _filteredData;
        public SupplierListControl()
        {
            InitializeComponent();
        }

        private void DgwSupplierListSettings()
        {
            dgwSupplierList.Columns[0].HeaderText = "Id";
            dgwSupplierList.Columns[1].HeaderText = "Tedarikçi Adı";
            dgwSupplierList.Columns[2].HeaderText = "İletişim Kurulacak Kişi";
            dgwSupplierList.Columns[3].HeaderText = "İletişim Kurulacak Kişinin Departmanı";
            dgwSupplierList.Columns[4].HeaderText = "Telefon Numarası";
            dgwSupplierList.Columns[5].HeaderText = "Email";
            dgwSupplierList.Columns[6].HeaderText = "Ülke";
            dgwSupplierList.Columns[7].HeaderText = "Şehir";
            dgwSupplierList.Columns[8].HeaderText = "Adres";

            dgwSupplierList.Columns[0].Visible = false;
        }
        public async Task SupplierList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("supplier/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetSupplierDTO>>(response);

            if (result is not null)
            {
                _originalData = new BindingList<GetSupplierDTO>(result.Data);
                _filteredData = new BindingList<GetSupplierDTO>(_originalData.ToList());

                dgwSupplierList.DataSource = _filteredData;
                DgwSupplierListSettings();
            }
        }
        public DataGridView DataGridViewSupplierList
        {
            get { return dgwSupplierList; }
        }
    }
}
