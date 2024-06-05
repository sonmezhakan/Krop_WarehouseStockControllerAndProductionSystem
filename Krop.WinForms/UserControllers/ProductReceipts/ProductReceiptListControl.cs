using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.ProductReceipts;
using Krop.WinForms.HelpersClass;
using System.ComponentModel;

namespace Krop.WinForms.UserControllers.ProductReceipts
{
    public partial class ProductReceiptListControl : UserControl
    {
        public BindingList<GetProductReceiptListDTO> _originalData;
        public BindingList<GetProductReceiptListDTO> _filteredData;
        public ProductReceiptListControl()
        {
            InitializeComponent();
        }

        private void DgwReceiptListSettings()
        {
            dgwProductReceiptList.Columns[0].HeaderText = "Id";
            dgwProductReceiptList.Columns[1].HeaderText = "Ürün Adı";
            dgwProductReceiptList.Columns[2].HeaderText = "Ürün Kodu";
            dgwProductReceiptList.Columns[3].HeaderText = "Kullanılacak Miktar";

            dgwProductReceiptList.Columns[0].Visible = false;
        }
        public async Task ProductReceiptList(IWebApiService webApiService,Guid produceProductId)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync($"productReceipt/GetAll/{produceProductId}");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetProductReceiptListDTO>>(response);

            if (result is not null)
            {
                _originalData = new BindingList<GetProductReceiptListDTO>(result.Data);
                _filteredData = new BindingList<GetProductReceiptListDTO>(_originalData.ToList());

                dgwProductReceiptList.DataSource = _filteredData;

                DgwReceiptListSettings();
            }
        }
        public DataGridView DataGridViewProductReceiptList
        {
            get { return dgwProductReceiptList; }
        }
    }
}
