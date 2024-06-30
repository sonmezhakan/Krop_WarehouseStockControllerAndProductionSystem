using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.StockInputs;
using Krop.WinForms.Forms.Branches;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using Krop.WinForms.Products;
using Krop.WinForms.Suppliers;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.StockInputs
{
    public partial class frmStockInput : Form
    {
        private Guid Id;
        private readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;

        public frmStockInput(IWebApiService webApiService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
            branchComboBoxControl.labelName.Text = "Giriş Yapılacak Şube :";
        }

        private async void frmStockInput_Load(object sender, EventArgs e)
        {
            await productComboBoxControl.ProductList(_webApiService);
            productComboBoxControl.ProductNameComboBox.SelectedIndexChanged += cmbBoxProductName_SelectedIndexChanged;
            productComboBoxControl.ProductCodeComboBox.SelectedIndexChanged += cmbBoxProductCode_SelectedIndexChanged;

            await supplierComboBoxControl.SupplierList(_webApiService);

            await branchComboBoxControl.BranchList(_webApiService);

            await stockInputListControl.StockInputList(_webApiService, Panel._appUserId);
            stockInputListControl.DataGridViewStockInputList.DoubleClick += dgwStockInputList_DoubleClick;
        }
        private void cmbBoxProductName_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (productComboBoxControl.ProductNameComboBox.SelectedValue is not null && productComboBoxControl.ProductCodeComboBox.DataSource is not null)
            {
                productComboBoxControl.ProductCodeComboBox.SelectedValue = productComboBoxControl.ProductNameComboBox.SelectedValue;
            }
        }
        private void cmbBoxProductCode_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (productComboBoxControl.ProductCodeComboBox.SelectedValue is not null && productComboBoxControl.ProductNameComboBox.DataSource is not null)
            {
                productComboBoxControl.ProductNameComboBox.SelectedValue = productComboBoxControl.ProductCodeComboBox.SelectedValue;
            }
        }
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = stockInputListControl._originalData.Where(x =>
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

                stockInputListControl._filteredData.Clear();
                foreach (var item in filteredList)
                {
                    stockInputListControl._filteredData.Add(item);
                }
            }
            else
            {
                stockInputListControl._filteredData.Clear();
                foreach (var item in stockInputListControl._originalData)
                {
                    stockInputListControl._filteredData.Add(item);
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

                var result = await ResponseController.SuccessDataResponseController<GetStockInputDTO>(response);

                if (result is not null)
                {
                    branchComboBoxControl.BranchComboBox.SelectedValue = result.Data.BranchId;
                    productComboBoxControl.ProductNameComboBox.SelectedValue = result.Data.ProductId;
                    supplierComboBoxControl.SupplierComboBox.SelectedValue = result.Data.SupplierId;
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
            if (productComboBoxControl.ProductNameComboBox.SelectedValue is not null && productComboBoxControl.ProductCodeComboBox.SelectedValue is not null && branchComboBoxControl.BranchComboBox.SelectedValue is not null && supplierComboBoxControl.SupplierComboBox.SelectedValue is not null)
            {
                CreateStockInputDTO createStockInputDTO = new CreateStockInputDTO
                {
                    BranchId = (Guid)branchComboBoxControl.BranchComboBox.SelectedValue,
                    ProductId = (Guid)productComboBoxControl.ProductNameComboBox.SelectedValue,
                    SupplierId = (Guid)supplierComboBoxControl.SupplierComboBox.SelectedValue,
                    AppUserId = Panel._appUserId,
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
                await stockInputListControl.StockInputList(_webApiService, Panel._appUserId);
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
                if (productComboBoxControl.ProductNameComboBox.SelectedValue is not null && productComboBoxControl.ProductCodeComboBox.SelectedValue is not null && branchComboBoxControl.BranchComboBox.SelectedValue is not null && supplierComboBoxControl.SupplierComboBox.SelectedValue is not null)
                {
                    if (DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                    {
                        UpdateStockInputDTO updateStockInputDTO = new UpdateStockInputDTO
                        {
                            Id = Id,
                            BranchId = (Guid)branchComboBoxControl.BranchComboBox.SelectedValue,
                            ProductId = (Guid)productComboBoxControl.ProductNameComboBox.SelectedValue,
                            SupplierId = (Guid)supplierComboBoxControl.SupplierComboBox.SelectedValue,
                            AppUserId = Panel._appUserId,
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
                        await stockInputListControl.StockInputList(_webApiService, Panel._appUserId);
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
            Id = (Guid)stockInputListControl.DataGridViewStockInputList.SelectedRows[0].Cells[0].Value;

            await GetStockInput();
        }

        private async void bttnDelete_Click(object sender, EventArgs e)
        {
            if (Id != Guid.Empty)
            {
                HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"StockInput/Delete/{Id}/{Panel._appUserId}");
                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                await stockInputListControl.StockInputList(_webApiService, Panel._appUserId);
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
