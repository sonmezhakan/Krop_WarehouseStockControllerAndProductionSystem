using Krop.DTO.Dtos.Stocks;
using System.ComponentModel;

namespace Krop.WinForms.Forms.Stocks
{
    public partial class frmBelowCriticalAmountStockList : Form
    {
        public frmBelowCriticalAmountStockList()
        {
            InitializeComponent();
        }

        private void frmBelowCriticalAmountStockList_Load(object sender, EventArgs e)
        {

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
        public async Task StockList(BindingList<GetStockListDTO> data)
        {
            dgwStockList.DataSource = data;
            DgwStockListSettings();
        }
    }
}
