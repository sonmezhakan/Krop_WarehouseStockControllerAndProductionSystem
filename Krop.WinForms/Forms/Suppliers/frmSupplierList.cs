using Krop.Business.Features.Suppliers.Dtos;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.SupplierHelpers;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Krop.WinForms.Suppliers
{
    public partial class frmSupplierList : Form
    {
        private readonly ISupplierHelper _supplierHelper;
        private readonly IServiceProvider _serviceProvider;
        private BindingList<GetSupplierDTO> _originalData;
        private BindingList<GetSupplierDTO> _filteredData;

        public frmSupplierList(ISupplierHelper supplierHelper, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _supplierHelper = supplierHelper;
            _serviceProvider = serviceProvider;
        }

        private async void frmSupplierList_Load(object sender, EventArgs e)
        {
            await SupplierList();
        }
        private void DgwSupplierListSettings()
        {
            dgwSupplierList.Columns[0].HeaderText = "Id";
            dgwSupplierList.Columns[1].HeaderText = "Tedarikçi Adı";
            dgwSupplierList.Columns[2].HeaderText = "İletişim Kurulacak Kişi";
            dgwSupplierList.Columns[3].HeaderText = "İletişim Kurulacak Kişinin Departmanı";
            dgwSupplierList.Columns[4].HeaderText = "Telefon Numarası";
            dgwSupplierList.Columns[5].HeaderText = "Email";
            dgwSupplierList.Columns[6].HeaderText = "Ülke";
            dgwSupplierList.Columns[7].HeaderText = "Şehir";
            dgwSupplierList.Columns[8].HeaderText = "Adres";

            dgwSupplierList.Columns[0].Visible = false;
        }
        private async Task SupplierList()
        {
            List<GetSupplierDTO> result = await _supplierHelper.GetAllAsync();
            _originalData = new BindingList<GetSupplierDTO>(result);
            _filteredData = new BindingList<GetSupplierDTO>(_originalData.ToList());

            dgwSupplierList.DataSource = _filteredData;
            DgwSupplierListSettings();
        }
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = _originalData.Where(x =>
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

        private void bttnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void supplierCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierCart frmSupplierCart = _serviceProvider.GetRequiredService<frmSupplierCart>();
            frmSupplierCart.Id = (Guid)dgwSupplierList.SelectedRows[0].Cells[0].Value;
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
            frmSupplierUpdate.Id = (Guid)dgwSupplierList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmSupplierUpdate);
        }

        private void supplierDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierDelete frmSupplierDelete = _serviceProvider.GetRequiredService<frmSupplierDelete>();
            frmSupplierDelete.Id = (Guid)dgwSupplierList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmSupplierDelete);
        }

        private async void supplierListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await SupplierList();
        }
    }
}
