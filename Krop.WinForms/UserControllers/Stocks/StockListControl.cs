using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Stocks;
using Krop.WinForms.HelpersClass;
using System.ComponentModel;

namespace Krop.WinForms.UserControllers.Stocks
{
    public partial class StockListControl : UserControl
    {
        public BindingList<GetStockListDTO> _originalData;
        public BindingList<GetStockListDTO> _filteredData;
        public StockListControl()
        {
            InitializeComponent();
        }
        private void DgwStockListSettings()
        {
            dgwStockList.Columns[0].HeaderText = "Id";
            dgwStockList.Columns[1].HeaderText = "Şube";
            dgwStockList.Columns[2].HeaderText = "Ürün Adı";
            dgwStockList.Columns[3].HeaderText = "Ürün Kodu";
            dgwStockList.Columns[4].HeaderText = "Stok Miktarı";
            dgwStockList.Columns[5].HeaderText = "Kritik Stok Miktarı";

            dgwStockList.Columns[0].Visible = false;
        }
        public async Task StockList(IWebApiService webApiService,Guid appUserId)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync($"stock/GetAllFilteredAppUser/{appUserId}/");
            if(!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }
            var result = await ResponseController.SuccessDataResponseController<List<GetStockListDTO>>(response);

            _originalData = new BindingList<GetStockListDTO>(result.Data);
            _filteredData = new BindingList<GetStockListDTO>(_originalData.ToList());

            dgwStockList.DataSource = _filteredData;
            DgwStockListSettings();
        }
        public async Task BranchFiltered(string branchName)
        {
            if(!string.IsNullOrWhiteSpace(branchName))
            {
                var filteredList = _originalData.Where(
                    (x=>x.BranchName != null && x.BranchName.ToLower().Contains(branchName.ToLower()))
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
    }
}
