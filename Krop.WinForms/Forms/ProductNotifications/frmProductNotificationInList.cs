using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.ProductNotifications;
using Krop.WinForms.HelpersClass;
using System.ComponentModel;

namespace Krop.WinForms.Forms.ProductNotifications
{
    public partial class frmProductNotificationInList : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;
        private BindingList<GetProductNotificationListDTO> _originalData;
        private BindingList<GetProductNotificationListDTO> _filteredData;
        public frmProductNotificationInList(IWebApiService webApiService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
        }

        private async void frmProductNotificationIn_Load(object sender, EventArgs e)
        {
            await ProductNotificationSentList();
        }
        private void DgwProduuctNotificationSentListSettings()
        {
            dgwProductNotificationInList.Columns[0].HeaderText = "Id";
            dgwProductNotificationInList.Columns[1].HeaderText = "Bildirim Gönderen Çalışan";
            dgwProductNotificationInList.Columns[2].HeaderText = "Bildirim Gönderilen Çalışan";
            dgwProductNotificationInList.Columns[3].HeaderText = "Şube Adı";
            dgwProductNotificationInList.Columns[4].HeaderText = "Ürün Adı";
            dgwProductNotificationInList.Columns[5].HeaderText = "Ürün Kodu";
            dgwProductNotificationInList.Columns[6].HeaderText = "Stok Miktarı";
            dgwProductNotificationInList.Columns[7].HeaderText = "Kritik Miktar";
            dgwProductNotificationInList.Columns[8].HeaderText = "Açıklama";
            dgwProductNotificationInList.Columns[9].HeaderText = "Gönderilen Tarih";

            dgwProductNotificationInList.Columns[0].Visible = false;
        }
        private async Task ProductNotificationSentList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"productNotification/GetInAll/{Panel._appUserId}");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetProductNotificationListDTO>>(response);

            _originalData = new BindingList<GetProductNotificationListDTO>(result.Data);
            _filteredData = new BindingList<GetProductNotificationListDTO>(_originalData.ToList());

            dgwProductNotificationInList.DataSource = _filteredData;
            DgwProduuctNotificationSentListSettings();
        }

        private async void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            await ProductNotificationSentList();
        }
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                var filteredList = _originalData.Where(x =>
                    x.SenderUserName.ToLower().Contains(searchText) ||
                    x.SentUserName.ToLower().Contains(searchText) ||
                    x.BranchName.ToLower().Contains(searchText) ||
                    x.ProductName.ToLower().Contains(searchText) ||
                    x.ProductCode.ToLower().Contains(searchText) ||
                    x.UnitsInStock.ToString().Contains(searchText) ||
                    x.CriticalStock.ToString().Contains(searchText) ||
                    x.SenderNotificationDate.ToString().Contains(searchText) ||
                    x.Description.ToLower().Contains(searchText)
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
    }
}
