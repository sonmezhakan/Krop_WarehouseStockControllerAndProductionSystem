using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Stocks;
using Krop.WinForms.HelpersClass;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Linq;

namespace Krop.WinForms.Forms.Stocks
{
    public partial class frmStockList : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;
        public Guid appUserId;

        public frmStockList(IWebApiService webApiService,IServiceProvider serviceProvider)
        {
            InitializeComponent();
            branchComboBoxControl.Dock = DockStyle.Fill;
            branchComboBoxControl.labelName.Visible = false;
            branchComboBoxControl.BranchComboBox.Dock = DockStyle.Fill;
            branchComboBoxControl.BranchComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
        }

        private async void frmStockList_Load(object sender, EventArgs e)
        {
            await branchComboBoxControl.BranchList(_webApiService);
            branchComboBoxControl.BranchComboBox.SelectedIndexChanged += BranchComboBox_SelectedIndexChanged;

            await stockListControl.StockList(_webApiService, appUserId);
        }

        private async void BranchComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if ((Guid)branchComboBoxControl.BranchComboBox.SelectedValue != Guid.Empty)
            {
                await stockListControl.BranchFiltered(branchComboBoxControl.BranchComboBox.Text);
            }
        }
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = stockListControl._originalData.Where(
                    x => x.BranchName.ToLower().Contains(branchComboBoxControl.BranchComboBox.Text.ToLower()));

                filteredList = filteredList.Where(x =>
                    x.ProductName.ToLower().Contains(searchText) ||
                    x.ProductCode.ToLower().Contains(searchText) ||
                    x.UnitsInStock.ToString().Contains(searchText) ||
                    x.CriticalStock.ToString().Contains(searchText));

                stockListControl._filteredData.Clear();
                foreach (var item in filteredList)
                {
                    stockListControl._filteredData.Add(item);
                }
            }
            else
            {
                stockListControl._filteredData.Clear();
                var filteredList = stockListControl._originalData.Where(
                    x => x.BranchName.ToLower().Contains(branchComboBoxControl.BranchComboBox.Text.ToLower())
                    );
                foreach (var item in filteredList)
                {
                    stockListControl._filteredData.Add(item);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void büyüktenKüçüğeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindingList<GetStockListDTO> getStockListDTOs = new BindingList<GetStockListDTO>(stockListControl._filteredData.OrderByDescending(x => x.UnitsInStock).ToList());

            stockListControl._filteredData.Clear();
            foreach (var item in getStockListDTOs)
            {
                stockListControl._filteredData.Add(item);
            }
        }

        private void küçüktenBüyüğüyeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindingList<GetStockListDTO> getStockListDTOs = new BindingList<GetStockListDTO>(stockListControl._filteredData.OrderBy(x => x.UnitsInStock).ToList());

            stockListControl._filteredData.Clear();
            foreach (var item in getStockListDTOs)
            {
                stockListControl._filteredData.Add(item);
            }
        }

        private async void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BindingList<GetStockListDTO> data = new();
            foreach (var item in stockListControl._filteredData)
            {
                if (item.UnitsInStock < item.CriticalStock)
                    data.Add(item);
            }

            frmBelowCriticalAmountStockList frmBelowCriticalAmountStockList = _serviceProvider.GetRequiredService<frmBelowCriticalAmountStockList>();
            FormController.FormOpenController(frmBelowCriticalAmountStockList);
            await frmBelowCriticalAmountStockList.StockList(data);

        }
    }
}
