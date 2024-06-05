using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.ProductReceipts;
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
            productComboBoxControl1.labelName.Text = "Reçetesi Düzenlenecek Ürün Adı :";
            productComboBoxControl1.labelCode.Text = "Reçetesi Düzenlenecek Ürün Kodu :";

            productComboBoxControl2.labelName.Text = "Reçeteye Eklenecek Ürün Adı :";
            productComboBoxControl2.labelCode.Text = "Reçeteye Eklenecek Ürün Kodu :";
        }

        private async void frmProductReceipt_Load(object sender, EventArgs e)
        {
            txtQuantity.MaxLength = 10;
            await productComboBoxControl1.ProductList(_webApiService);
            productComboBoxControl1.ProductNameComboBox.SelectedIndexChanged += cmbBoxReceiptProductName_SelectedIndexChanged;
            productComboBoxControl1.ProductCodeComboBox.SelectedIndexChanged += cmbBoxReceiptProductCode_SelectedIndexChanged;
            
            await productComboBoxControl2.ProductList(_webApiService);
            productComboBoxControl2.ProductNameComboBox.SelectedIndexChanged += cmbBoxProductNameSelect_SelectedIndexChanged;
            productComboBoxControl2.ProductCodeComboBox.SelectedIndexChanged += cmbBoxProductCodeSelect_SelectedIndexChanged;

            productReceiptListControl.DataGridViewProductReceiptList.DoubleClick += dgwProductReceiptList_DoubleClick;
        }
        private void DgwSelectedRowsAndCells()
        {
            if (productComboBoxControl1.ProductNameComboBox.SelectedValue is not null && productComboBoxControl1.ProductCodeComboBox.DataSource is not null)
            {
                productComboBoxControl2.ProductNameComboBox.SelectedValue = (Guid)productReceiptListControl.DataGridViewProductReceiptList.SelectedRows[0].Cells[0].Value;
            }
            else
            {
                MessageBox.Show("Reçeteyi Doğru Seçiniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cmbBoxReceiptProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productComboBoxControl1.ProductNameComboBox.SelectedValue is not null && productComboBoxControl1.ProductCodeComboBox.DataSource is not null)
            {
                productComboBoxControl1.ProductCodeComboBox.SelectedValue = productComboBoxControl1.ProductNameComboBox.SelectedValue;

                await productReceiptListControl.ProductReceiptList(_webApiService, (Guid)productComboBoxControl1.ProductNameComboBox.SelectedValue);
            }
        }

        private void cmbBoxReceiptProductCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productComboBoxControl1.ProductCodeComboBox.SelectedValue is not null && productComboBoxControl1.ProductNameComboBox.DataSource is not null)
            {
                productComboBoxControl1.ProductNameComboBox.SelectedValue = productComboBoxControl1.ProductCodeComboBox.SelectedValue;
            }
        }

        private void cmbBoxProductNameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productComboBoxControl2.ProductNameComboBox.SelectedValue is not null && productComboBoxControl2.ProductCodeComboBox.DataSource is not null)
            {
                productComboBoxControl2.ProductCodeComboBox.SelectedValue = productComboBoxControl2.ProductNameComboBox.SelectedValue;
            }

        }

        private void cmbBoxProductCodeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productComboBoxControl2.ProductCodeComboBox.SelectedValue is not null && productComboBoxControl2.ProductNameComboBox.DataSource is not null)
            {
                productComboBoxControl2.ProductNameComboBox.SelectedValue = productComboBoxControl2.ProductCodeComboBox.SelectedValue;
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
            if (productComboBoxControl2.ProductNameComboBox.SelectedValue is not null && productComboBoxControl2.ProductCodeComboBox.SelectedValue is not null && productComboBoxControl1.ProductNameComboBox.SelectedValue is not null && productComboBoxControl1.ProductCodeComboBox.SelectedValue is not null)
            {
                CreateProductReceiptDTO createProductReceiptDTO = new CreateProductReceiptDTO
                {
                    ProduceProductId = (Guid)productComboBoxControl1.ProductNameComboBox.SelectedValue,
                    ProductId = (Guid)productComboBoxControl2.ProductNameComboBox.SelectedValue,
                    Quantity = int.Parse(txtQuantity.Text)
                };

                HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("productReceipt/Add", createProductReceiptDTO);

                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                await productReceiptListControl.ProductReceiptList(_webApiService, (Guid)productComboBoxControl2.ProductNameComboBox.SelectedValue);
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void bttnUpdate_Click(object sender, EventArgs e)
        {
            if (productComboBoxControl2.ProductNameComboBox.SelectedValue is not null && productComboBoxControl2.ProductCodeComboBox.SelectedValue is not null && productComboBoxControl1.ProductNameComboBox.SelectedValue is not null && productComboBoxControl1.ProductCodeComboBox.SelectedValue is not null)
            {
                if(DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    UpdateProductReceiptDTO updateProductReceiptDTO = new UpdateProductReceiptDTO
                    {
                        ProduceProductId = (Guid)productComboBoxControl1.ProductNameComboBox.SelectedValue,
                        ProductId = (Guid)productComboBoxControl2.ProductNameComboBox.SelectedValue,
                        Quantity = int.Parse(txtQuantity.Text)
                    };

                    HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("productReceipt/Update", updateProductReceiptDTO);

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                    await productReceiptListControl.ProductReceiptList(_webApiService, (Guid)productComboBoxControl2.ProductNameComboBox.SelectedValue);
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void bttnDelete_Click(object sender, EventArgs e)
        {
            if (productComboBoxControl2.ProductNameComboBox.SelectedValue is not null && productComboBoxControl2.ProductCodeComboBox.SelectedValue is not null && productComboBoxControl1.ProductNameComboBox.SelectedValue is not null && productComboBoxControl1.ProductCodeComboBox.SelectedValue is not null)
            {
                if(DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"productReceipt/Delete/{productComboBoxControl1.ProductNameComboBox.SelectedValue}/{productComboBoxControl2.ProductNameComboBox.SelectedValue}");

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                    await productReceiptListControl.ProductReceiptList(_webApiService, (Guid)productComboBoxControl2.ProductNameComboBox.SelectedValue);
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
