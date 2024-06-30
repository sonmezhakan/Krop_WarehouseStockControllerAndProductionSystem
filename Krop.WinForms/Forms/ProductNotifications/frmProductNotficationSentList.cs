using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.ProductNotifications;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Krop.WinForms.Forms.ProductNotifications
{
    public partial class frmProductNotficationSentList : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;
        private BindingList<GetProductNotificationListDTO> _originalData;
        private BindingList<GetProductNotificationListDTO> _filteredData;

        public frmProductNotficationSentList(IWebApiService webApiService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
        }

        private async void frmProductNotficationSentList_Load(object sender, EventArgs e)
        {
            await ProductNotificationSentList();
        }
        private void DgwProduuctNotificationSentListSettings()
        {
            dgwProductNotificationSentList.Columns[0].HeaderText = "Id";
            dgwProductNotificationSentList.Columns[1].HeaderText = "Gönderen Çalışan";
            dgwProductNotificationSentList.Columns[2].HeaderText = "Gönderilen Çalışan";
            dgwProductNotificationSentList.Columns[3].HeaderText = "Şube Adı";
            dgwProductNotificationSentList.Columns[4].HeaderText = "Ürün Adı";
            dgwProductNotificationSentList.Columns[5].HeaderText = "Ürün Kodu";
            dgwProductNotificationSentList.Columns[6].HeaderText = "Stok Miktarı";
            dgwProductNotificationSentList.Columns[7].HeaderText = "Kritik Miktar";
            dgwProductNotificationSentList.Columns[8].HeaderText = "Açıklama";
            dgwProductNotificationSentList.Columns[9].HeaderText = "Gönderilen Tarih";

            dgwProductNotificationSentList.Columns[0].Visible = false;
        }
        private async Task ProductNotificationSentList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"productNotification/GetSentAll/{Panel._appUserId}");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetProductNotificationListDTO>>(response);

            _originalData = new BindingList<GetProductNotificationListDTO>(result.Data);
            _filteredData = new BindingList<GetProductNotificationListDTO>(_originalData.ToList());

            dgwProductNotificationSentList.DataSource = _filteredData;
            DgwProduuctNotificationSentListSettings();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductNotificationAdd frmProductNotificationAdd = _serviceProvider.GetRequiredService<frmProductNotificationAdd>();
            FormController.FormOpenController(frmProductNotificationAdd);
        }

        private void bildirimGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductNotificationUpdate frmProductNotificationUpdate = _serviceProvider.GetRequiredService<frmProductNotificationUpdate>();
            frmProductNotificationUpdate.productNotificationId = (Guid)dgwProductNotificationSentList.SelectedRows[0].Cells[0].Value;
            frmProductNotificationUpdate.appUserId = Panel._appUserId;
            FormController.FormOpenController(frmProductNotificationUpdate);
        }

        private async void bildirimSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Guid)dgwProductNotificationSentList.SelectedRows[0].Cells[0].Value != Guid.Empty)
            {
                if (DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"productNotification/Delete/{(Guid)dgwProductNotificationSentList.SelectedRows[0].Cells[0].Value}/{Panel._appUserId}");
                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                    await ProductNotificationSentList();
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private async void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            await ProductNotificationSentList();
        }
    }
}
