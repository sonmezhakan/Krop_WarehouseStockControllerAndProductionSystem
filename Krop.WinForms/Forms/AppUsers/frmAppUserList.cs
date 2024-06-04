using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.AppUsers;
using Krop.WinForms.HelpersClass;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Krop.WinForms.Forms.AppUsers
{
    public partial class frmAppUserList : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IWebApiService _webApiService;
        private BindingList<GetAppUserDTO> _originalData;
        private BindingList<GetAppUserDTO> _filteredData;

        public frmAppUserList(IServiceProvider serviceProvider,IWebApiService webApiService)
        {
            InitializeComponent();
 
            _serviceProvider = serviceProvider;
            _webApiService = webApiService;
        }

        private async void frmAppUserList_Load(object sender, EventArgs e)
        {
            await AppUserList();
        }
        private void DgwAppUserListSettings()
        {
            dgwAppUserList.Columns[0].HeaderText = "Id";
            dgwAppUserList.Columns[1].HeaderText = "Kullanıcı Adı";
            dgwAppUserList.Columns[2].HeaderText = "Ad";
            dgwAppUserList.Columns[3].HeaderText = "Soyad";
            dgwAppUserList.Columns[4].HeaderText = "T.C. No";
            dgwAppUserList.Columns[5].HeaderText = "Email";
            dgwAppUserList.Columns[6].HeaderText = "Telefon Numarası";
            dgwAppUserList.Columns[7].HeaderText = "Ülke";
            dgwAppUserList.Columns[8].HeaderText = "Şehir";
            dgwAppUserList.Columns[9].HeaderText = "Adres";

            dgwAppUserList.Columns[0].Visible = false;
        }
        private async Task AppUserList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("account/getall");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetAppUserDTO>>(response);

            if (result is not null)
            {
                _originalData = new BindingList<GetAppUserDTO>(result.Data);
                _filteredData = new BindingList<GetAppUserDTO>(_originalData.ToList());

                dgwAppUserList.DataSource = _filteredData;

                DgwAppUserListSettings();
            }
        }
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = _originalData.Where(x =>
                    x.UserName.ToLower().Contains(searchText) ||
                    x.FirstName.ToLower().Contains(searchText) ||
                    x.LastName.ToLower().Contains(searchText) ||
                    x.Email.ToLower().Contains(searchText) ||
                    x.PhoneNumber.ToString().Contains(searchText) ||
                    (x.NationalNumber != null && x.NationalNumber.ToString().Contains(searchText)) ||
                    (x.Country != null && x.Country.ToLower().Contains(searchText)) ||
                    (x.City != null && x.City.ToLower().Contains(searchText)) ||
                    (x.Addres != null && x.Addres.ToLower().Contains(searchText)));

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

        private void appUserCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppUserCart frmAppUserCart = _serviceProvider.GetRequiredService<frmAppUserCart>();
            frmAppUserCart.Id = (Guid)dgwAppUserList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmAppUserCart);
        }

        private void appUserAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppUserAdd frmAppUserAdd = _serviceProvider.GetRequiredService<frmAppUserAdd>();
            FormController.FormOpenController(frmAppUserAdd);
        }

        private void appUserUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppUserUpdate frmAppUserUpdate = _serviceProvider.GetRequiredService<frmAppUserUpdate>();
            frmAppUserUpdate.Id = (Guid)dgwAppUserList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmAppUserUpdate);
        }

        private async void appUserListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
           await AppUserList();
        }
    }
}
