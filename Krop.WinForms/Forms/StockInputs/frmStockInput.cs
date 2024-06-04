using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Branches;
using Krop.DTO.Dtos.Products;
using Krop.DTO.Dtos.StockInputs;
using Krop.DTO.Dtos.Suppliers;
using Krop.WinForms.Forms.Branches;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using Krop.WinForms.Products;
using Krop.WinForms.Suppliers;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Data;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.StockInputs
{
    public partial class frmStockInput : Form
    {
        private BindingList<GetStockInputListDTO> _originalData;
        private BindingList<GetStockInputListDTO> _filteredData;
        internal Guid AppUserId;
        private Guid Id;
        private readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;

        public frmStockInput(IWebApiService webApiService,IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
        }

        private async void frmStockInput_Load(object sender, EventArgs e)
        {
           await ProductList();
           await BranchList();
           await SupplierList();
           await StockInputList();
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

           await ProductNameList(result.Data);
           await ProductCodeList(result.Data);
        }
        private async Task ProductNameList(List<GetProductComboBoxDTO> products)
        {
            cmbBoxProductName.DataSource = null;

            cmbBoxProductName.DisplayMember = "ProductName";
            cmbBoxProductName.ValueMember = "Id";

            cmbBoxProductName.SelectedIndexChanged -= cmbBoxProductName_SelectedIndexChanged;

            cmbBoxProductName.DataSource = products is not null ? products : null;

            cmbBoxProductName.SelectedIndex = -1;

            cmbBoxProductName.SelectedIndexChanged += cmbBoxProductName_SelectedIndexChanged;
        }

        private void cmbBoxProductName_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxProductName.SelectedValue is not null && cmbBoxProductCode.DataSource is not null)
            {
                cmbBoxProductCode.SelectedValue = cmbBoxProductName.SelectedValue;
            }
        }

        private async Task ProductCodeList(List<GetProductComboBoxDTO> products)
        {
            cmbBoxProductCode.DataSource = null;

            cmbBoxProductCode.DisplayMember = "ProductCode";
            cmbBoxProductCode.ValueMember = "Id";

            cmbBoxProductCode.SelectedIndexChanged -= cmbBoxProductCode_SelectedIndexChanged;

            cmbBoxProductCode.DataSource = products is not null ? products : null;

            cmbBoxProductCode.SelectedIndex = -1;

            cmbBoxProductCode.SelectedIndexChanged += cmbBoxProductCode_SelectedIndexChanged;
        }

        private void cmbBoxProductCode_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxProductCode.SelectedValue is not null && cmbBoxProductName.DataSource is not null)
            {
                cmbBoxProductName.SelectedValue = cmbBoxProductCode.SelectedValue;
            }
        }

        private async Task BranchList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("branch/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result =await ResponseController.SuccessDataResponseController<List<GetBranchComboBoxDTO>>(response);

            cmbBoxBranch.DataSource = null;

            cmbBoxBranch.DisplayMember = "BranchName";
            cmbBoxBranch.ValueMember = "Id";

            cmbBoxBranch.DataSource = result is not null ? result.Data : null;
            cmbBoxBranch.SelectedIndex = -1;
        }
        private async Task SupplierList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("supplier/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result =await ResponseController.SuccessDataResponseController<List<GetSupplierComboBoxDTO>>(response);

            cmbBoxSupplier.DataSource = null;

            cmbBoxSupplier.DisplayMember = "CompanyName";
            cmbBoxSupplier.ValueMember = "Id";

            cmbBoxSupplier.DataSource = result is not null ? result.Data : null;
            cmbBoxSupplier.SelectedIndex = -1;
        }
        private void DgwStockInputListSettings()
        {
            dgwStockInputList.Columns[0].HeaderText = "Id";
            dgwStockInputList.Columns[1].HeaderText = "Şube Adı";
            dgwStockInputList.Columns[2].HeaderText = "Ürün Adı";
            dgwStockInputList.Columns[3].HeaderText = "Ürün Kodu";
            dgwStockInputList.Columns[4].HeaderText = "Tedarikçi Adı";
            dgwStockInputList.Columns[5].HeaderText = "Fatura No";
            dgwStockInputList.Columns[6].HeaderText = "Alış Birim Fiyatı";
            dgwStockInputList.Columns[7].HeaderText = "Adet";
            dgwStockInputList.Columns[8].HeaderText = "Açıklama";
            dgwStockInputList.Columns[9].HeaderText = "Giriş Tarihi";
            dgwStockInputList.Columns[10].HeaderText = "İşlem Yapan Çalışan";
            dgwStockInputList.Columns[11].HeaderText = "Üretim Id";
            dgwStockInputList.Columns[12].HeaderText = "Üretim";

            dgwStockInputList.Columns[0].Visible = false;
            dgwStockInputList.Columns[11].Visible = false;
        }
        private async Task StockInputList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"stockInput/getall/{AppUserId}");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result =await ResponseController.SuccessDataResponseController<List<GetStockInputListDTO>>(response);
            if (result is not null)
            {
                _originalData = new BindingList<GetStockInputListDTO>(result.Data);
                _filteredData = new BindingList<GetStockInputListDTO>(_originalData.ToList());

                dgwStockInputList.DataSource = _filteredData;

                DgwStockInputListSettings();
            } 
        }
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = _originalData.Where(x =>
                x.BranchName.ToLower().Contains(searchText) ||
                x.ProductName.ToLower().Contains(searchText) ||
                x.ProductCode.ToLower().Contains(searchText) ||
                x.CompanyName.ToLower().Contains(searchText) ||
                (x.InvoiceNumber != null && x.InvoiceNumber.ToLower().Contains(searchText)) ||
                x.UnitPrice.ToString().Contains(searchText) ||
                x.Quantity.ToString().Contains(searchText) ||
                x.InputDate.ToString().Contains(searchText) ||
                (x.Description != null && x.Description.ToLower().Contains(searchText)) ||
                x.UserName.ToLower().Contains(searchText)
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
        private async Task GetStockInput()
        {
            if (Id != Guid.Empty)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"StockInput/GetById/{Id}");

                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                var result =await ResponseController.SuccessDataResponseController<GetStockInputDTO>(response);

                if(result is not null)
                {
                    cmbBoxBranch.SelectedValue = result.Data.BranchId;
                    cmbBoxProductName.SelectedValue = result.Data.ProductId;
                    cmbBoxSupplier.SelectedValue = result.Data.SupplierId;
                    txtUnitPrice.Text = result.Data.UnitPrice.ToString();
                    txtQuantity.Text = result.Data.Quantity.ToString();
                    txtDescription.Text = result.Data.Description;
                    inputDateTimePicker.Value = result.Data.InputDate;
                    txtInvoiceNumber.Text = result.Data.InvoiceNumber;
                }
            }
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxDecimalKeyPress(sender, e);
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
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
            if (cmbBoxProductName.SelectedValue is not null && cmbBoxProductCode.SelectedValue is not null && cmbBoxBranch.SelectedValue is not null && cmbBoxSupplier.SelectedValue is not null)
            {
                CreateStockInputDTO createStockInputDTO = new CreateStockInputDTO
                {
                    BranchId = (Guid)cmbBoxBranch.SelectedValue,
                    ProductId = (Guid)cmbBoxProductName.SelectedValue,
                    SupplierId = (Guid)cmbBoxSupplier.SelectedValue,
                    AppUserId = AppUserId,
                    InvoiceNumber = txtInvoiceNumber.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    InputDate = inputDateTimePicker.Value,
                    Description = txtDescription.Text
                };

                HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("StockInput/add", createStockInputDTO);

                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }
               await StockInputList();
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void bttnUpdate_Click(object sender, EventArgs e)
        {
            if (Id != Guid.Empty)//Listeden seçilip seçilmedi kontrol ediliyor.
            {
                if (cmbBoxProductName.SelectedValue is not null && cmbBoxProductCode.SelectedValue is not null && cmbBoxBranch.SelectedValue is not null && cmbBoxSupplier.SelectedValue is not null)
                {
                    if (DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                    {
                        UpdateStockInputDTO updateStockInputDTO = new UpdateStockInputDTO
                        {
                            Id = Id,
                            BranchId = (Guid)cmbBoxBranch.SelectedValue,
                            ProductId = (Guid)cmbBoxProductName.SelectedValue,
                            SupplierId = (Guid)cmbBoxSupplier.SelectedValue,
                            AppUserId = AppUserId,
                            InvoiceNumber = txtInvoiceNumber.Text,
                            UnitPrice = decimal.Parse(txtUnitPrice.Text),
                            Quantity = int.Parse(txtQuantity.Text),
                            InputDate = inputDateTimePicker.Value,
                            Description = txtDescription.Text
                        };

                        HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("StockInput/Update", updateStockInputDTO);

                        if (!response.IsSuccessStatusCode)
                        {
                            await ResponseController.ErrorResponseController(response);
                            return;
                        }
                       await StockInputList();
                        Id = default;
                    }
                }
                else
                {
                    MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Güncellenecek İşlemi Listeden Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dgwStockInputList_DoubleClick(object sender, EventArgs e)
        {
            Id = (Guid)dgwStockInputList.SelectedRows[0].Cells[0].Value;

           await GetStockInput();
        }

        private async void bttnDelete_Click(object sender, EventArgs e)
        {
            if (Id != Guid.Empty)
            {
                HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"StockInput/Delete/{Id}/{AppUserId}");
                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

               await StockInputList();
                Id = default;
            }
            else
            {
                MessageBox.Show("Silinecek İşlemi Listeden Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bttnNewBranch_Click(object sender, EventArgs e)
        {
            frmBranchAdd frmBranchAdd = _serviceProvider.GetRequiredService<frmBranchAdd>();
            FormController.FormOpenController(frmBranchAdd);
        }

        private void bttnNewProduct_Click(object sender, EventArgs e)
        {
            frmProductAdd frmProductAdd = _serviceProvider.GetRequiredService<frmProductAdd>();
            FormController.FormOpenController(frmProductAdd);
        }

        private void bttnNewSupplier_Click(object sender, EventArgs e)
        {
            frmSupplierAdd frmSupplierAdd = _serviceProvider.GetRequiredService<frmSupplierAdd>();
            FormController.FormOpenController(frmSupplierAdd);
        }
    }
}
