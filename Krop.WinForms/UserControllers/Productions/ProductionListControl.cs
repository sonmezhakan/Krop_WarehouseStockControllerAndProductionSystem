using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Productions;
using Krop.WinForms.HelpersClass;
using System.ComponentModel;

namespace Krop.WinForms.UserControllers.Productions
{
    public partial class ProductionListControl : UserControl
    {
        public BindingList<GetProductionListDTO> _originalData;
        public BindingList<GetProductionListDTO> _filteredData;
        public ProductionListControl()
        {
            InitializeComponent();
        }

        private void DgwProductionSettings()
        {
            dgwProductionList.Columns[0].HeaderText = "Id";
            dgwProductionList.Columns[1].HeaderText = "Üretilen Ürün Adı";
            dgwProductionList.Columns[2].HeaderText = "Üretilen Ürün Kodu";
            dgwProductionList.Columns[3].HeaderText = "Üretilen Şube";
            dgwProductionList.Columns[4].HeaderText = "Üretim Miktarı";
            dgwProductionList.Columns[5].HeaderText = "Üretim Tarihi";
            dgwProductionList.Columns[6].HeaderText = "Açıklama";
            dgwProductionList.Columns[7].HeaderText = "İşlem Yapan";

            dgwProductionList.Columns[0].Visible = false;
        }
        public async Task ProductionList(IWebApiService webApiService,Guid appUserId)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync($"production/getAll/{appUserId}");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetProductionListDTO>>(response);

            if (result is not null)
            {
                _originalData = new BindingList<GetProductionListDTO>(result.Data.ToList());
                _filteredData = new BindingList<GetProductionListDTO>(_originalData.ToList());

                dgwProductionList.DataSource = _filteredData;
                DgwProductionSettings();
            }
        }
        public DataGridView DataGridViewProductionList
        {
            get { return dgwProductionList; }
        }
    }
}
