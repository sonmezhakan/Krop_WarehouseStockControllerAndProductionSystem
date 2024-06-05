using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.WinForms.Suppliers
{
    public partial class frmSupplierList : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;

        public frmSupplierList(IWebApiService webApiService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
        }

        private async void frmSupplierList_Load(object sender, EventArgs e)
        {
            await supplierListControl.SupplierList(_webApiService);
        }

        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = supplierListControl._originalData.Where(x =>
                x.CompanyName.ToLower().Contains(searchText.ToLower()) ||
                (x.ContactName != null && x.ContactName.ToLower().Contains(searchText)) ||
                (x.ContactTitle != null && x.ContactTitle.ToLower().Contains(searchText)) ||
                (x.PhoneNumber != null && x.PhoneNumber.ToString().Contains(searchText)) ||
                (x.Email != null && x.Email.ToLower().Contains(searchText)) ||
                (x.Country != null && x.Country.ToLower().Contains(searchText)) ||
                (x.City != null && x.City.ToLower().Contains(searchText)) ||
                (x.Addres != null && x.Addres.ToLower().Contains(searchText)) ||
                (x.WebSite != null && x.WebSite.ToLower().Contains(searchText))
                );

                supplierListControl._filteredData.Clear();
                foreach (var item in filteredList)
                {
                    supplierListControl._filteredData.Add(item);
                }
            }
            else
            {
                supplierListControl._filteredData.Clear();
                foreach (var item in supplierListControl._originalData)
                {
                    supplierListControl._filteredData.Add(item);
                }
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void bttnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void supplierCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierCart frmSupplierCart = _serviceProvider.GetRequiredService<frmSupplierCart>();
            frmSupplierCart.Id = (Guid)supplierListControl.DataGridViewSupplierList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmSupplierCart);
        }

        private void supplierAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierAdd frmSupplierAdd = _serviceProvider.GetRequiredService<frmSupplierAdd>();
            FormController.FormOpenController(frmSupplierAdd);
        }

        private void supplierUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierUpdate frmSupplierUpdate = _serviceProvider.GetRequiredService<frmSupplierUpdate>();
            frmSupplierUpdate.Id = (Guid)supplierListControl.DataGridViewSupplierList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmSupplierUpdate);
        }

        private void supplierDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierDelete frmSupplierDelete = _serviceProvider.GetRequiredService<frmSupplierDelete>();
            frmSupplierDelete.Id = (Guid)supplierListControl.DataGridViewSupplierList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmSupplierDelete);
        }

        private async void supplierListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await supplierListControl.SupplierList(_webApiService);
        }
    }
}
