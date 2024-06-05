using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.StockInputs;
using Krop.WinForms.HelpersClass;
using System.ComponentModel;

namespace Krop.WinForms.UserControllers
{
    public partial class StockInputListControl : UserControl
    {
        public BindingList<GetStockInputListDTO> _originalData;
        public BindingList<GetStockInputListDTO> _filteredData;
        public StockInputListControl()
        {
            InitializeComponent();
        }
        private void DgwStockInputListSettings()
        {
            dgwStockInputList.Columns[0].HeaderText = "Id";
            dgwStockInputList.Columns[1].HeaderText = "Şube Adı";
            dgwStockInputList.Columns[2].HeaderText = "Ürün Adı";
            dgwStockInputList.Columns[3].HeaderText = "Ürün Kodu";
            dgwStockInputList.Columns[4].HeaderText = "Tedarikçi Adı";
            dgwStockInputList.Columns[5].HeaderText = "Fatura No";
            dgwStockInputList.Columns[6].HeaderText = "Alış Birim Fiyatı";
            dgwStockInputList.Columns[7].HeaderText = "Adet";
            dgwStockInputList.Columns[8].HeaderText = "Açıklama";
            dgwStockInputList.Columns[9].HeaderText = "Giriş Tarihi";
            dgwStockInputList.Columns[10].HeaderText = "İşlem Yapan Çalışan";
            dgwStockInputList.Columns[11].HeaderText = "Üretim Id";
            dgwStockInputList.Columns[12].HeaderText = "Üretim";

            dgwStockInputList.Columns[0].Visible = false;
            dgwStockInputList.Columns[11].Visible = false;
        }
        public async Task StockInputList(IWebApiService webApiService,Guid appUserId)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync($"stockInput/getall/{appUserId}");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetStockInputListDTO>>(response);
            if (result is not null)
            {
                _originalData = new BindingList<GetStockInputListDTO>(result.Data);
                _filteredData = new BindingList<GetStockInputListDTO>(_originalData.ToList());

                dgwStockInputList.DataSource = _filteredData;

                DgwStockInputListSettings();
            }
        }
        public DataGridView DataGridViewStockInputList
        {
            get { return dgwStockInputList; }
        }
    }
}
