using Krop.Business.Features.Products.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using Krop.WinForms.HelpersClass.ProductHelpers;
using System.ComponentModel;

namespace Krop.WinForms.Products
{
    public partial class frmProductReceipt : Form
    {
        private readonly IProductHelper _productHelper;
        private readonly IWebApiService _webApiService;
        /*private BindingList<> _originalData;
        private BindingList<> _filteredData;*/

        public frmProductReceipt(IProductHelper productHelper, IWebApiService webApiService)
        {
            InitializeComponent();
            _productHelper = productHelper;
            _webApiService = webApiService;
        }

        private async void frmProductReceipt_Load(object sender, EventArgs e)
        {
            await ProductList();
            txtQuantity.MaxLength = 10;
        }
        private async Task ProductList()
        {
            List<GetProductComboBoxDTO> result = await _productHelper.GetAllComboBoxAsync();

            ProductNameList(result);
            ProductCodeList(result);

            ProductNameSelectList(result);
            ProductCodeSelectList(result);
        }

        private void DgwReceiptListSettings()
        {
            dgwProductReceiptList.Columns[0].HeaderText = "Ürün Adı";
            dgwProductReceiptList.Columns[1].HeaderText = "Ürün Kodu";
            dgwProductReceiptList.Columns[2].HeaderText = "Kullanılacak Miktar";
        }
        private void ProductNameList(List<GetProductComboBoxDTO> products)
        {
            cmbBoxReceiptProductName.DataSource = null;

            cmbBoxReceiptProductName.DisplayMember = "ProductName";
            cmbBoxReceiptProductName.ValueMember = "Id";

            cmbBoxReceiptProductName.SelectedIndexChanged -= cmbBoxReceiptProductName_SelectedIndexChanged;

            cmbBoxReceiptProductName.DataSource = products.Select(x => new GetProductComboBoxDTO { Id = x.Id, ProductName = x.ProductName }).ToList();

            cmbBoxReceiptProductName.SelectedIndex = -1;

            cmbBoxReceiptProductName.SelectedIndexChanged += cmbBoxReceiptProductName_SelectedIndexChanged;
        }
        private void ProductCodeList(List<GetProductComboBoxDTO> products)
        {
            cmbBoxReceiptProductCode.DataSource = null;

            cmbBoxReceiptProductCode.DisplayMember = "ProductCode";
            cmbBoxReceiptProductCode.ValueMember = "Id";

            cmbBoxReceiptProductCode.SelectedIndexChanged -= cmbBoxReceiptProductCode_SelectedIndexChanged;

            cmbBoxReceiptProductCode.DataSource = products.Select(x => new GetProductComboBoxDTO { Id = x.Id, ProductCode = x.ProductCode }).ToList();

            cmbBoxReceiptProductCode.SelectedIndex = -1;

            cmbBoxReceiptProductCode.SelectedIndexChanged += cmbBoxReceiptProductCode_SelectedIndexChanged;
        }

        private void cmbBoxReceiptProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxReceiptProductName.SelectedValue is not null && cmbBoxReceiptProductCode.DataSource is not null)
            {
                cmbBoxReceiptProductCode.SelectedValue = cmbBoxReceiptProductName.SelectedValue;

                //todo:seçilen ürünün reçetesi listelenecek
            }
        }

        private void cmbBoxReceiptProductCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxReceiptProductCode.SelectedValue is not null && cmbBoxReceiptProductName.DataSource is not null)
            {
                cmbBoxReceiptProductName.SelectedValue = cmbBoxReceiptProductCode.SelectedValue;
            }
        }
        private void ProductNameSelectList(List<GetProductComboBoxDTO> products)
        {
            cmbBoxProductNameSelect.DataSource = null;

            cmbBoxProductNameSelect.DisplayMember = "ProductName";
            cmbBoxProductNameSelect.ValueMember = "Id";

            cmbBoxProductNameSelect.SelectedIndexChanged -= cmbBoxProductNameSelect_SelectedIndexChanged;

            cmbBoxProductNameSelect.DataSource = products.Select(x => new GetProductComboBoxDTO { Id = x.Id, ProductName = x.ProductName }).ToList();

            cmbBoxProductNameSelect.SelectedIndex = -1;

            cmbBoxProductNameSelect.SelectedIndexChanged += cmbBoxProductNameSelect_SelectedIndexChanged;
        }
        private void ProductCodeSelectList(List<GetProductComboBoxDTO> products)
        {
            cmbBoxProductCodeSelect.DataSource = null;

            cmbBoxProductCodeSelect.DisplayMember = "ProductCode";
            cmbBoxProductCodeSelect.ValueMember = "Id";

            cmbBoxProductCodeSelect.SelectedIndexChanged -= cmbBoxProductCodeSelect_SelectedIndexChanged;

            cmbBoxProductCodeSelect.DataSource = products.Select(x => new GetProductComboBoxDTO { Id = x.Id, ProductCode = x.ProductCode }).ToList();

            cmbBoxProductCodeSelect.SelectedIndex = -1;

            cmbBoxProductCodeSelect.SelectedIndexChanged += cmbBoxProductCodeSelect_SelectedIndexChanged;
        }

        private void cmbBoxProductNameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxProductNameSelect.SelectedValue is not null && cmbBoxProductCodeSelect.DataSource is not null)
            {
                cmbBoxProductCodeSelect.SelectedValue = cmbBoxProductNameSelect.SelectedValue;
            }

        }

        private void cmbBoxProductCodeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxProductCodeSelect.SelectedValue is not null && cmbBoxProductNameSelect.DataSource is not null)
            {
                cmbBoxProductNameSelect.SelectedValue = cmbBoxProductCodeSelect.SelectedValue;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private void Search()
        {
            /*if(dgwProductReceiptList.Rows.Count > 0)
            {
                string searchText = txtSearch.Text.ToLower();
                if(!string.IsNullOrWhiteSpace(searchText))
                {
                    var filteredList = _originalData.Where(x =>
                    x.ProductName.ToLower().Contains(searchText) ||
                    x.ProductCode.ToLower().Contains(searchText) ||
                    x.Quantity.ToString().Constains(searchText));
                    _filteredData.Clear();
                    foreach (var item in _originalData)
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
            }*/
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void bttnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}
