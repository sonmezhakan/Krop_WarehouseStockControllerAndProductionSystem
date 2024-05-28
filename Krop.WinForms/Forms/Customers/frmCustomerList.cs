using Krop.Business.Features.Customers.Dtos;
using Krop.Entities.Enums;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.CustomerHelpers;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Krop.WinForms.Customers
{
    public partial class frmCustomerList : Form
    {
        private readonly ICustomerHelper _customerHelper;
        private readonly IServiceProvider _serviceProvider;
        private BindingList<GetCustomerDTO> _originalData;
        private BindingList<GetCustomerDTO> _filteredData;

        public frmCustomerList(ICustomerHelper customerHelper, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _customerHelper = customerHelper;
            _serviceProvider = serviceProvider;
        }

        private void frmCustomerList_Load(object sender, EventArgs e)
        {
            CustomerList();
        }
        private void DgwCustomerListSettings()
        {
            dgwCustomerList.Columns[0].HeaderText = "Id";
            dgwCustomerList.Columns[1].HeaderText = "Bireysel/Kurumsal";
            dgwCustomerList.Columns[2].HeaderText = "Müşteri Adı";
            dgwCustomerList.Columns[3].HeaderText = "İletişim Kurulacak Kişi";
            dgwCustomerList.Columns[4].HeaderText = "İletişim Kurulacak Kişinin Departmanı";
            dgwCustomerList.Columns[5].HeaderText = "Telefon Numarası";
            dgwCustomerList.Columns[6].HeaderText = "Email";
            dgwCustomerList.Columns[7].HeaderText = "Ülke";
            dgwCustomerList.Columns[8].HeaderText = "Şehir";
            dgwCustomerList.Columns[9].HeaderText = "Adres";

            dgwCustomerList.Columns[0].Visible = false;
        }
        private void CustomerList()
        {
            List<GetCustomerDTO> result = _customerHelper.GetAllAsync();
            if (result is null)
                return;

            _originalData = new BindingList<GetCustomerDTO>(result);
            _filteredData = new BindingList<GetCustomerDTO>(_originalData.ToList());

            dgwCustomerList.DataSource = _filteredData;

            DgwCustomerListSettings();
        }

        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = _originalData.Where(x =>
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
            frmCustomerCart.Id = (Guid)dgwCustomerList.SelectedRows[0].Cells[0].Value;
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
            frmCustomerUpdate.Id = (Guid)dgwCustomerList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmCustomerUpdate);
        }

        private void customerDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerDelete frmCustomerDelete = _serviceProvider.GetRequiredService<frmCustomerDelete>();
            frmCustomerDelete.Id = (Guid)dgwCustomerList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmCustomerDelete);
        }

        private void customerRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerList();
        }
    }
}
