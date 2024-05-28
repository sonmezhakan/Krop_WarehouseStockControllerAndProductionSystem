using Krop.Business.Features.Brands.Dtos;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.BrandHelpers;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Krop.WinForms.Brands
{
    public partial class frmBrandList : Form
    {
        private readonly IBrandHelper _brandHelper;
        private readonly IServiceProvider _serviceProvider;
        private BindingList<GetBrandDTO> _originalData;
        private BindingList<GetBrandDTO> _filteredData;

        public frmBrandList(IBrandHelper brandHelper, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _brandHelper = brandHelper;
            _serviceProvider = serviceProvider;
        }

        private void frmBrandList_Load(object sender, EventArgs e)
        {
             BrandList();
        }
        private void DgwBrandListSettings()
        {
            dgwBrandList.Columns[0].HeaderText = "Id";
            dgwBrandList.Columns[1].HeaderText = "Marka Adı";
            dgwBrandList.Columns[2].HeaderText = "Telefon Numarası";
            dgwBrandList.Columns[3].HeaderText = "Email";

            dgwBrandList.Columns[0].Visible = false;
        }
        private void BrandList()
        {
            List<GetBrandDTO> result = _brandHelper.GetAllAsync();
            _originalData = new BindingList<GetBrandDTO>(result);
            _filteredData = new BindingList<GetBrandDTO>(_originalData.ToList());

            dgwBrandList.DataSource = _filteredData;

            DgwBrandListSettings();
        }
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();//girilen değerleri küçülterek ata.
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = _originalData.Where(x =>
                (x.BrandName != null && x.BrandName.ToLower().Contains(searchText)) ||
                (x.PhoneNumber != null && x.PhoneNumber.ToString().ToLower().Contains(searchText)) ||
                (x.Email != null && x.Email.ToLower().Contains(searchText)));

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

        private void brandCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBrandCart frmBrandCart = _serviceProvider.GetRequiredService<frmBrandCart>();
            frmBrandCart.Id = (Guid)dgwBrandList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmBrandCart);
        }

        private void brandAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBrandAdd frmBrandAdd = _serviceProvider.GetRequiredService<frmBrandAdd>();
            FormController.FormOpenController(frmBrandAdd);
        }

        private void brandUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBrandUpdate frmBrandUpdate = _serviceProvider.GetRequiredService<frmBrandUpdate>();
            frmBrandUpdate.Id = (Guid)dgwBrandList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmBrandUpdate);
        }

        private void brandDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBrandDelete frmBrandDelete = _serviceProvider.GetRequiredService<frmBrandDelete>();
            frmBrandDelete.Id = (Guid)dgwBrandList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmBrandDelete);
        }

        private void brandListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrandList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
