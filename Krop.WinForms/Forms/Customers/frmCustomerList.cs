using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.WinForms.Customers
{
    public partial class frmCustomerList : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;

        public frmCustomerList(IWebApiService webApiService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
        }

        private async void frmCustomerList_Load(object sender, EventArgs e)
        {
            await customerListControl.CustomerList(_webApiService);
        }
       
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = customerListControl._originalData.Where(x =>
                (x.Invoice != null && x.Invoice.ToString().ToLower().Contains(searchText)) ||
                (x.CompanyName != null && x.CompanyName.ToLower().Contains(searchText)) ||
                (x.ContactName != null && x.ContactName.ToLower().Contains(searchText)) ||
                (x.ContactTitle != null && x.ContactTitle.ToLower().Contains(searchText)) ||
                (x.PhoneNumber != null && x.PhoneNumber.Contains(searchText)) ||
                (x.Email != null && x.Email.ToLower().Contains(searchText)) ||
                (x.Country != null && x.Country.ToLower().Contains(searchText)) ||
                (x.City != null && x.City.ToLower().Contains(searchText)) ||
                (x.Addres != null && x.Addres.ToLower().Contains(searchText))
                );

                customerListControl._filteredData.Clear();
                foreach (var item in filteredList)
                {
                    customerListControl._filteredData.Add(item);
                }
            }
            else
            {
                customerListControl._filteredData.Clear();
                foreach (var item in customerListControl._originalData)
                {
                    customerListControl._filteredData.Add(item);
                }
            }
        }
        private void bttnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void customerCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerCart frmCustomerCart = _serviceProvider.GetRequiredService<frmCustomerCart>();
            frmCustomerCart.Id = (Guid)customerListControl.DataGridViewCustomerList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmCustomerCart);
        }

        private void customerAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerAdd frmCustomerAdd = _serviceProvider.GetRequiredService<frmCustomerAdd>();
            FormController.FormOpenController(frmCustomerAdd);
        }

        private void customerUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerUpdate frmCustomerUpdate = _serviceProvider.GetRequiredService<frmCustomerUpdate>();
            frmCustomerUpdate.Id = (Guid)customerListControl.DataGridViewCustomerList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmCustomerUpdate);
        }

        private void customerDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerDelete frmCustomerDelete = _serviceProvider.GetRequiredService<frmCustomerDelete>();
            frmCustomerDelete.Id = (Guid)customerListControl.DataGridViewCustomerList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmCustomerDelete);
        }

        private async void customerRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await customerListControl.CustomerList(_webApiService);
        }
    }
}
