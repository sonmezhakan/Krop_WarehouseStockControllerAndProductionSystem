using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.StockTransfers;
using Krop.WinForms.HelpersClass;
using System.ComponentModel;

namespace Krop.WinForms.UserControllers.StockTransfers
{
    public partial class StockTransferListControl : UserControl
    {
        public BindingList<GetStockTransferListDTO> _originalData;
        public BindingList<GetStockTransferListDTO> _filteredData;
        public StockTransferListControl()
        {
            InitializeComponent();
        }
        private void DgwStockTransferListSettings()
        {
            dgwStockTransferList.Columns[0].HeaderText = "Id";
            dgwStockTransferList.Columns[1].HeaderText = "Gönderen Şube";
            dgwStockTransferList.Columns[2].HeaderText = "Gönderilen Şube";
            dgwStockTransferList.Columns[3].HeaderText = "Ürün Adı";
            dgwStockTransferList.Columns[4].HeaderText = "Ürün Kodu";
            dgwStockTransferList.Columns[5].HeaderText = "Fatura No";
            dgwStockTransferList.Columns[6].HeaderText = "Gönderilen Adet";
            dgwStockTransferList.Columns[7].HeaderText = "Açıklama";
            dgwStockTransferList.Columns[8].HeaderText = "Transfer Tarihi";
            dgwStockTransferList.Columns[9].HeaderText = "İşlem Yapan";

            dgwStockTransferList.Columns[0].Visible = false;
        }
        public async Task StockTransferList(IWebApiService webApiService,Guid appUserId)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync($"stockTransfer/AppUserBranchGetAll/{appUserId}");

            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetStockTransferListDTO>>(response);

            if (result is not null)
            {
                _originalData = new BindingList<GetStockTransferListDTO>(result.Data);
                _filteredData = new BindingList<GetStockTransferListDTO>(_originalData.ToList());

                dgwStockTransferList.DataSource = _filteredData;

                DgwStockTransferListSettings();
            }
        }
        public DataGridView DataGridViewStockTransferList
        {
            get { return dgwStockTransferList; }
        }
    }
}
