using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Brands;
using Krop.WinForms.HelpersClass;
using System.ComponentModel;

namespace Krop.WinForms.UserControllers.Brands
{
    public partial class BrandListControl : UserControl
    {
        public BindingList<GetBrandDTO> _originalData;
        public BindingList<GetBrandDTO> _filteredData;
        public BrandListControl()
        {
            InitializeComponent();
        }

        private void DgwBrandListSettings()
        {
            dgwBrandList.Columns[0].HeaderText = "Id";
            dgwBrandList.Columns[1].HeaderText = "Marka Adı";
            dgwBrandList.Columns[2].HeaderText = "Telefon Numarası";
            dgwBrandList.Columns[3].HeaderText = "Email";

            dgwBrandList.Columns[0].Visible = false;
        }
        public async Task BrandList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("brand/getall");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetBrandDTO>>(response);

            if (result is not null)
            {
                _originalData = new BindingList<GetBrandDTO>(result.Data);
                _filteredData = new BindingList<GetBrandDTO>(_originalData.ToList());

                dgwBrandList.DataSource = _filteredData;

                DgwBrandListSettings();
            }
        }
        public DataGridView DataGridViewBrandList
        {
            get { return dgwBrandList; }
        }
    }
}
