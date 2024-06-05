using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.AppUsers;
using Krop.WinForms.HelpersClass;
using System.ComponentModel;

namespace Krop.WinForms.UserControllers.AppUsers
{
    public partial class AppUserListControl : UserControl
    {
        public BindingList<GetAppUserDTO> _originalData;
        public BindingList<GetAppUserDTO> _filteredData;
        public AppUserListControl()
        {
            InitializeComponent();
        }

        private void AppUserListControl_Load(object sender, EventArgs e)
        {

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
        public async Task AppUserList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("account/getall");
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
        public DataGridView DataGridViewAppUserList
        {
            get { return dgwAppUserList; }
        }
    }
}
