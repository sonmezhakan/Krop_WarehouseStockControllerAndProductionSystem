using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Branches;
using Krop.WinForms.HelpersClass;
using System.ComponentModel;

namespace Krop.WinForms.UserControllers.Branches
{
    public partial class BranchListControl : UserControl
    {
        public BindingList<GetBranchDTO> _originalData;
        public BindingList<GetBranchDTO> _filteredData;
        public BranchListControl()
        {
            InitializeComponent();
        }
        private void DgwBranchListSettings()
        {
            dgwBranchList.Columns[0].HeaderText = "Id";
            dgwBranchList.Columns[1].HeaderText = "Şube Adı";
            dgwBranchList.Columns[2].HeaderText = "Telefon Numarası";
            dgwBranchList.Columns[3].HeaderText = "Email";
            dgwBranchList.Columns[4].HeaderText = "Ülke";
            dgwBranchList.Columns[5].HeaderText = "Şehir";
            dgwBranchList.Columns[6].HeaderText = "Adres";

            dgwBranchList.Columns[0].Visible = false;
        }
        public async Task BranchList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("branch/getall");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetBranchDTO>>(response);

            if (result is not null)
            {
                _originalData = new BindingList<GetBranchDTO>(result.Data);
                _filteredData = new BindingList<GetBranchDTO>(_originalData.ToList());

                dgwBranchList.DataSource = _filteredData;

                DgwBranchListSettings();
            }
        }
        public DataGridView DataGridViewBranchList
        {
            get { return dgwBranchList; }
        }
    }
}
