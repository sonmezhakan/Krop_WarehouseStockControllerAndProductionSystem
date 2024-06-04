using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.ProductReceipts;
using Krop.DTO.Dtos.Products;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.ComponentModel;
using System.Net.Http.Json;

namespace Krop.WinForms.Products
{
    public partial class frmProductReceipt : Form
    {

        private BindingList<GetProductReceiptListDTO> _originalData;
        private BindingList<GetProductReceiptListDTO> _filteredData;
        private readonly IWebApiService _webApiService;

        public frmProductReceipt(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmProductReceipt_Load(object sender, EventArgs e)
        {
           await ProductList();
            txtQuantity.MaxLength = 10;
        }
        private async Task ProductList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("product/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result =await ResponseController.SuccessDataResponseController<List<GetProductComboBoxDTO>>(response);

            if(result is not null)
            {
                ProductNameList(result.Data);
                ProductCodeList(result.Data);

                ProductNameSelectList(result.Data);
                ProductCodeSelectList(result.Data);
            }
        }

        private void DgwReceiptListSettings()
        {
            dgwProductReceiptList.Columns[0].HeaderText = "Id";
            dgwProductReceiptList.Columns[1].HeaderText = "Ürün Adı";
            dgwProductReceiptList.Columns[2].HeaderText = "Ürün Kodu";
            dgwProductReceiptList.Columns[3].HeaderText = "Kullanılacak Miktar";

            dgwProductReceiptList.Columns[0].Visible = false;
        }
        private async Task ProductReceiptList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"productReceipt/GetAll/{cmbBoxProductNameSelect.SelectedValue}");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result =await ResponseController.SuccessDataResponseController<List<GetProductReceiptListDTO>>(response);

            if(result is not null)
            {
                _originalData = new BindingList<GetProductReceiptListDTO>(result.Data);
                _filteredData = new BindingList<GetProductReceiptListDTO>(_originalData.ToList());

                dgwProductReceiptList.DataSource = _filteredData;

                DgwReceiptListSettings();
            }
        }
        private void DgwSelectedRowsAndCells()
        {
            if (cmbBoxReceiptProductName.SelectedValue is not null && cmbBoxReceiptProductCode is not null)
            {
                cmbBoxProductNameSelect.SelectedValue = (Guid)dgwProductReceiptList.SelectedRows[0].Cells[0].Value;
            }
            else
            {
                MessageBox.Show("Reçeteyi Doğru Seçiniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ProductNameList(List<GetProductComboBoxDTO> products)
        {
            cmbBoxReceiptProductName.DataSource = null;

            cmbBoxReceiptProductName.DisplayMember = "ProductName";
            cmbBoxReceiptProductName.ValueMember = "Id";

            cmbBoxReceiptProductName.SelectedIndexChanged -= cmbBoxReceiptProductName_SelectedIndexChanged;

            cmbBoxReceiptProductName.DataSource = products is not null ? products : null;

            cmbBoxReceiptProductName.SelectedIndex = -1;

            cmbBoxReceiptProductName.SelectedIndexChanged += cmbBoxReceiptProductName_SelectedIndexChanged;
        }
        private void ProductCodeList(List<GetProductComboBoxDTO> products)
        {
            cmbBoxReceiptProductCode.DataSource = null;

            cmbBoxReceiptProductCode.DisplayMember = "ProductCode";
            cmbBoxReceiptProductCode.ValueMember = "Id";

            cmbBoxReceiptProductCode.SelectedIndexChanged -= cmbBoxReceiptProductCode_SelectedIndexChanged;

            cmbBoxReceiptProductCode.DataSource = products is not null ? products : null;

            cmbBoxReceiptProductCode.SelectedIndex = -1;

            cmbBoxReceiptProductCode.SelectedIndexChanged += cmbBoxReceiptProductCode_SelectedIndexChanged;
        }

        private async void cmbBoxReceiptProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxReceiptProductName.SelectedValue is not null && cmbBoxReceiptProductCode.DataSource is not null)
            {
                cmbBoxReceiptProductCode.SelectedValue = cmbBoxReceiptProductName.SelectedValue;

               await ProductReceiptList();
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
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = _originalData.Where(x =>
                (x.ProductName != null && x.ProductName.ToLower().Contains(searchText)) ||
                (x.ProductCode != null && x.ProductCode.ToLower().Contains(searchText)) ||
                (x.Quantity != null && x.Quantity.ToString().Contains(searchText))
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

        private async void bttnAdd_Click(object sender, EventArgs e)
        {
            if (cmbBoxProductNameSelect.SelectedValue is not null && cmbBoxProductCodeSelect.SelectedValue is not null && cmbBoxReceiptProductName.SelectedValue is not null && cmbBoxReceiptProductCode.SelectedValue is not null)
            {
                CreateProductReceiptDTO createProductReceiptDTO = new CreateProductReceiptDTO
                {
                    ProduceProductId = (Guid)cmbBoxReceiptProductName.SelectedValue,
                    ProductId = (Guid)cmbBoxProductNameSelect.SelectedValue,
                    Quantity = int.Parse(txtQuantity.Text)
                };

                HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("productReceipt/Add", createProductReceiptDTO);

                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

               await ProductReceiptList();
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void bttnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbBoxProductNameSelect.SelectedValue is not null && cmbBoxProductCodeSelect.SelectedValue is not null && cmbBoxReceiptProductName.SelectedValue is not null && cmbBoxReceiptProductCode.SelectedValue is not null)
            {
                if(DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    UpdateProductReceiptDTO updateProductReceiptDTO = new UpdateProductReceiptDTO
                    {
                        ProduceProductId = (Guid)cmbBoxReceiptProductName.SelectedValue,
                        ProductId = (Guid)cmbBoxProductNameSelect.SelectedValue,
                        Quantity = int.Parse(txtQuantity.Text)
                    };

                    HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("productReceipt/Update", updateProductReceiptDTO);

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                   await ProductReceiptList();
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void bttnDelete_Click(object sender, EventArgs e)
        {
            if (cmbBoxProductNameSelect.SelectedValue is not null && cmbBoxProductCodeSelect.SelectedValue is not null && cmbBoxReceiptProductName.SelectedValue is not null && cmbBoxReceiptProductCode.SelectedValue is not null)
            {
                if(DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"productReceipt/Delete/{cmbBoxReceiptProductName.SelectedValue}/{cmbBoxProductNameSelect.SelectedValue}");

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                   await ProductReceiptList();
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DgwSelectedRowsAndCells();
        }

        private void dgwProductReceiptList_DoubleClick(object sender, EventArgs e)
        {
            DgwSelectedRowsAndCells();
        }
    }
}
