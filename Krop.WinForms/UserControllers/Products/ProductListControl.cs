using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Products;
using Krop.WinForms.HelpersClass;
using System.ComponentModel;

namespace Krop.WinForms.UserControllers.Products
{
    public partial class ProductListControl : UserControl
    {
        public BindingList<GetProductListDTO> _originalData;
        public BindingList<GetProductListDTO> _filteredData;
        public ProductListControl()
        {
            InitializeComponent();
        }
        private void DgwProductListSetting()
        {
            dgwProductList.Columns[0].HeaderText = "Id";
            dgwProductList.Columns[1].HeaderText = "Ürün Adı";
            dgwProductList.Columns[2].HeaderText = "Ürün Kdou";
            dgwProductList.Columns[3].HeaderText = "Kategori Adı";
            dgwProductList.Columns[4].HeaderText = "Marka Adı";
            dgwProductList.Columns[5].HeaderText = "Fiyat";
            dgwProductList.Columns[6].HeaderText = "Resim";
            dgwProductList.Columns[7].HeaderText = "Kritik Stok";
            dgwProductList.Columns[8].HeaderText = "Açıklama";

            dgwProductList.Columns[0].Visible = false;
            dgwProductList.Columns[6].Visible = false;
        }

        public async Task ProductList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("product/GetAll");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetProductListDTO>>(response);

            if (result is not null)
            {
                _originalData = new BindingList<GetProductListDTO>(result.Data);
                _filteredData = new BindingList<GetProductListDTO>(_originalData.ToList());
                dgwProductList.DataSource = _filteredData;

                DgwProductListSetting();
            }
        }
        public DataGridView DataGridViewProductList
        {
            get { return dgwProductList; }
        }
    }
}
