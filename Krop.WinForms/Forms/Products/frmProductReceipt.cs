using Krop.Common.Helpers.WebApiRequests.ProductReceipts;
using Krop.Common.Helpers.WebApiRequests.Products;
using Krop.DTO.Dtos.ProductReceipts;
using Krop.DTO.Dtos.Products;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.ComponentModel;

namespace Krop.WinForms.Products
{
    public partial class frmProductReceipt : Form
    {

        private BindingList<GetProductReceiptListDTO> _originalData;
        private BindingList<GetProductReceiptListDTO> _filteredData;
        private readonly IProductRequest _productRequest;
        private readonly IProductReceiptRequest _productReceiptRequest;

        public frmProductReceipt(IProductRequest productRequest,IProductReceiptRequest productReceiptRequest)
        {
            InitializeComponent();
            _productRequest = productRequest;
            _productReceiptRequest = productReceiptRequest;
        }

        private void frmProductReceipt_Load(object sender, EventArgs e)
        {
            ProductList();
            txtQuantity.MaxLength = 10;
        }
        private async void ProductList()
        {
            HttpResponseMessage response = await _productRequest.GetAllComboBoxAsync();
            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetProductComboBoxDTO>(response).Data;

            ProductNameList(result);
            ProductCodeList(result);

            ProductNameSelectList(result);
            ProductCodeSelectList(result);
        }

        private void DgwReceiptListSettings()
        {
            dgwProductReceiptList.Columns[0].HeaderText = "Id";
            dgwProductReceiptList.Columns[1].HeaderText = "Ürün Adı";
            dgwProductReceiptList.Columns[2].HeaderText = "Ürün Kodu";
            dgwProductReceiptList.Columns[3].HeaderText = "Kullanılacak Miktar";

            dgwProductReceiptList.Columns[0].Visible = false;
        }
        private async void ProductReceiptList()
        {
            HttpResponseMessage response = await _productReceiptRequest.GetAllAsync((Guid)cmbBoxProductNameSelect.SelectedValue);
            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetProductReceiptListDTO>(response).Data;

            _originalData = new BindingList<GetProductReceiptListDTO>(result.ToList());
            _filteredData = new BindingList<GetProductReceiptListDTO>(_originalData.ToList());

            dgwProductReceiptList.DataSource = _filteredData;

            DgwReceiptListSettings();
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

                ProductReceiptList();
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

                HttpResponseMessage response = await _productReceiptRequest.AddAsync(createProductReceiptDTO);

                if (!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                ProductReceiptList();
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

                    HttpResponseMessage response = await _productReceiptRequest.UpdateAsync(updateProductReceiptDTO);

                    if (!response.IsSuccessStatusCode)
                    {
                        ResponseController.ErrorResponseController(response);
                        return;
                    }

                    ProductReceiptList();
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
                    HttpResponseMessage response = await _productReceiptRequest.DeleteAsync((Guid)cmbBoxReceiptProductName.SelectedValue,(Guid)cmbBoxProductNameSelect.SelectedValue);

                    if (!response.IsSuccessStatusCode)
                    {
                        ResponseController.ErrorResponseController(response);
                        return;
                    }

                    ProductReceiptList();
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
