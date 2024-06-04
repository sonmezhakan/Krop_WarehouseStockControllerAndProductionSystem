using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Branches;
using Krop.DTO.Dtos.Productions;
using Krop.DTO.Dtos.ProductReceipts;
using Krop.DTO.Dtos.Products;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.ComponentModel;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.Productions
{
    public partial class frmProduction : Form
    {
        private BindingList<GetProductReceiptListDTO> _productReceiptOriginalData;
        private BindingList<GetProductReceiptListDTO> _productReceiptFilteredData;
        private BindingList<GetProductionListDTO> _productionOriginalData;
        private BindingList<GetProductionListDTO> _productionFilteredData;
        public Guid appUserId;
        private Guid id;
        private readonly IWebApiService _webApiService;

        public frmProduction(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmProduction_Load(object sender, EventArgs e)
        {
            await BranchList();
            await ProductList();
            await ProductionList();
        }
        private async Task BranchList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("branch/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetBranchComboBoxDTO>>(response);

            cmbBoxBranch.DataSource = null;
            cmbBoxBranch.DisplayMember = "BranchName";
            cmbBoxBranch.ValueMember = "Id";


            cmbBoxBranch.DataSource = result is not null ? result.Data.ToList() : null;
            cmbBoxBranch.SelectedIndex = -1;
        }
        private async Task ProductList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("product/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetProductComboBoxDTO>>(response);

            if (result is not null)
            {
                ProductNameList(result.Data.ToList());
                ProductCodeList(result.Data.ToList());
            }
        }
        private void ProductNameList(List<GetProductComboBoxDTO> getProductComboBoxDTOs)
        {
            cmbBoxProductName.DataSource = null;
            cmbBoxProductName.DisplayMember = "ProductName";
            cmbBoxProductName.ValueMember = "Id";

            cmbBoxProductName.SelectedIndexChanged -= CmbBoxProductName_SelectedIndexChanged;
            cmbBoxProductName.DataSource = getProductComboBoxDTOs;
            cmbBoxProductName.SelectedIndex = -1;
            cmbBoxProductName.SelectedIndexChanged += CmbBoxProductName_SelectedIndexChanged;
        }

        private async void CmbBoxProductName_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxProductName.SelectedValue is not null && cmbBoxProductCode.DataSource is not null)
            {
                cmbBoxProductCode.SelectedValue = cmbBoxProductName.SelectedValue;
                await ProductReceiptList();
            }
        }

        private void ProductCodeList(List<GetProductComboBoxDTO> getProductComboBoxDTOs)
        {
            cmbBoxProductCode.DataSource = null;
            cmbBoxProductCode.DisplayMember = "ProductCode";
            cmbBoxProductCode.ValueMember = "Id";

            cmbBoxProductCode.SelectedIndexChanged -= CmbBoxProductCode_SelectedIndexChanged;
            cmbBoxProductCode.DataSource = getProductComboBoxDTOs;
            cmbBoxProductCode.SelectedIndex = -1;
            cmbBoxProductCode.SelectedIndexChanged += CmbBoxProductCode_SelectedIndexChanged;
        }

        private void CmbBoxProductCode_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxProductCode.SelectedValue is not null && cmbBoxProductName.DataSource is not null)
            {
                cmbBoxProductName.SelectedValue = cmbBoxProductCode.SelectedValue;
            }
        }

        private void DgwProductReceiptSettings()
        {
            dgwProductReceiptList.Columns[0].HeaderText = "Id";
            dgwProductReceiptList.Columns[1].HeaderText = "Ürün Adı";
            dgwProductReceiptList.Columns[2].HeaderText = "Ürün Kodu";
            dgwProductReceiptList.Columns[3].HeaderText = "Kullanılacak Miktar";

            dgwProductReceiptList.Columns[0].Visible = false;
        }
        private async Task ProductReceiptList()
        {

            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"productReceipt/GetAll/{cmbBoxProductName.SelectedValue}");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetProductReceiptListDTO>>(response);

            if (result is not null)
            {
                _productReceiptOriginalData = new BindingList<GetProductReceiptListDTO>(result.Data.ToList());
                _productReceiptFilteredData = new BindingList<GetProductReceiptListDTO>(_productReceiptOriginalData.ToList());

                dgwProductReceiptList.DataSource = _productReceiptFilteredData;

                DgwProductReceiptSettings();
            }
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
        private async Task ProductionList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"production/getAll/{appUserId}");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetProductionListDTO>>(response);

            if (result is not null)
            {
                _productionOriginalData = new BindingList<GetProductionListDTO>(result.Data.ToList());
                _productionFilteredData = new BindingList<GetProductionListDTO>(_productionOriginalData.ToList());

                dgwProductionList.DataSource = _productionFilteredData;
                DgwProductionSettings();
            }
        }
        private void ProductReceiptSearch()
        {
            string searchText = txtProductReceiptSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = _productReceiptOriginalData.Where(x =>
                (x.ProductName != null && x.ProductName.ToLower().Contains(searchText)) ||
                (x.ProductCode != null && x.ProductCode.ToLower().Contains(searchText)) ||
                (x.Quantity != null && x.Quantity.ToString().Contains(searchText))
                );

                _productReceiptFilteredData.Clear();
                foreach (var item in filteredList)
                {
                    _productReceiptFilteredData.Add(item);
                }
            }
            else
            {
                _productReceiptFilteredData.Clear();
                foreach (var item in _productReceiptOriginalData)
                {
                    _productReceiptFilteredData.Add(item);
                }
            }
        }
        private void ProductionSearch()
        {
            string searchText = txtProductionSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = _productionOriginalData.Where(x =>
                    x.ProductName.ToLower().Contains(searchText) ||
                    x.ProductCode.ToLower().Contains(searchText) ||
                    x.BranchName.ToLower().Contains(searchText) ||
                    x.ProductionQuantity.ToString().Contains(searchText) ||
                    x.ProductionDate.ToString().Contains(searchText) ||
                    (x.Description != null && x.Description.ToLower().Contains(searchText)) ||
                    x.UserName.Contains(searchText)
                    );

                _productionFilteredData.Clear();
                foreach (var item in _productionOriginalData)
                {
                    _productionFilteredData.Add(item);
                }
            }
            else
            {
                _productionFilteredData.Clear();
                foreach (var item in _productionOriginalData)
                {
                    _productionFilteredData.Add(item);
                }
            }
        }

        private async void bttnAdd_Click(object sender, EventArgs e)
        {
            if (cmbBoxBranch.SelectedValue is not null && cmbBoxProductName.SelectedValue is not null && cmbBoxProductCode.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("production/Add", new CreateProductionDTO
                {
                    AppUserId = appUserId,
                    BranchId = (Guid)cmbBoxBranch.SelectedValue,
                    ProductId = (Guid)cmbBoxProductName.SelectedValue,
                    ProductionDate = productionDateTimePicker.Value,
                    ProductionQuantity = int.Parse(txtProductionQuantity.Text),
                    Description = txtDescription.Text
                });

                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                await ProductionList();
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void bttnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbBoxBranch.SelectedValue is not null && cmbBoxProductCode.SelectedValue is not null && cmbBoxProductName.SelectedValue is not null)
            {
                if (id != Guid.Empty)
                {
                    if (DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                    {
                        HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("production/Update",new UpdateProductionDTO
                        {
                            Id = id,
                            AppUserId = appUserId,
                            BranchId = (Guid)cmbBoxBranch.SelectedValue,
                            ProductId = (Guid)cmbBoxProductName.SelectedValue,
                            Description = txtDescription.Text,
                            ProductionDate = productionDateTimePicker.Value,
                            ProductionQuantity = int.Parse(txtProductionQuantity.Text)
                        });
                        if (!response.IsSuccessStatusCode)
                        {
                            await ResponseController.ErrorResponseController(response);
                            return;
                        }

                        await ProductionList();
                        id = default;
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Güncellenecek İşlemi Listeden Seçiniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void bttnDelete_Click(object sender, EventArgs e)
        {
            if (id != Guid.Empty)
            {
                if (DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"production/Delete/{id}/{appUserId}");
                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                    await ProductionList();
                    id = default;
                }
            }
            else
            {
                MessageBox.Show("Lütfen Silinecek İşlemi Listeden Seçiniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProductReceiptSearch_TextChanged(object sender, EventArgs e)
        {
            ProductReceiptSearch();
        }

        private void txtProductionSearch_TextChanged(object sender, EventArgs e)
        {
            ProductionSearch();
        }

        private void txtProductionQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private async void dgwProductionList_DoubleClick(object sender, EventArgs e)
        {
            id = (Guid)dgwProductionList.SelectedRows[0].Cells[0].Value;
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"production/getById/{id}/{appUserId}");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<GetProductionDTO>(response);
            if(result is not null)
            {
                cmbBoxBranch.SelectedValue = result.Data.BranchId;
                cmbBoxProductName.SelectedValue = result.Data.ProductId;
                txtDescription.Text = result.Data.Description;
                productionDateTimePicker.Value = result.Data.ProductionDate;
                txtProductionQuantity.Text = result.Data.ProductionQuantity.ToString();
            }
        }
    }
}
