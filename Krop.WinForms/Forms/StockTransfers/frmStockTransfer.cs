using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.StockTransfers;
using Krop.WinForms.Forms.Branches;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using Krop.WinForms.Products;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.StockTransfers
{
    public partial class frmStockTransfer : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;
        public Guid Id;
        public Guid AppUserId;

        public frmStockTransfer(IWebApiService webApiService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _serviceProvider = serviceProvider;
            branchComboBoxControl1.labelName.Text = "Transfer Yapan Şube :";
            branchComboBoxControl2.labelName.Text = "Transfer Yapılan Şube :";
        }

        private async void frmStockTransfer_Load(object sender, EventArgs e)
        {
            await branchComboBoxControl1.BranchList(_webApiService);
            await branchComboBoxControl2.BranchList(_webApiService);

            await productComboBoxControl.ProductList(_webApiService);
            productComboBoxControl.ProductNameComboBox.SelectedIndexChanged += CmbBoxProductName_SelectedIndexChanged;
            productComboBoxControl.ProductCodeComboBox.SelectedIndexChanged += CmbBoxProductCode_SelectedIndexChanged;

            await stockTransferListControl.StockTransferList(_webApiService, AppUserId);
            stockTransferListControl.DataGridViewStockTransferList.DoubleClick += dgwStockTransferList_DoubleClick;
        }

        private void CmbBoxProductName_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (productComboBoxControl.ProductNameComboBox.SelectedValue != null && productComboBoxControl.ProductCodeComboBox.DataSource != null)
            {
                productComboBoxControl.ProductCodeComboBox.SelectedValue = productComboBoxControl.ProductNameComboBox.SelectedValue;
            }
        }

        private void CmbBoxProductCode_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (productComboBoxControl.ProductCodeComboBox.SelectedValue != null && productComboBoxControl.ProductNameComboBox.DataSource != null)
            {
                productComboBoxControl.ProductNameComboBox.SelectedValue = productComboBoxControl.ProductCodeComboBox.SelectedValue;
            }
        }
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                var filteredList = stockTransferListControl._originalData.Where(x =>
                (x.SenderBranchName != null && x.SenderBranchName.ToLower().Contains(searchText)) ||
                (x.SentBranchName != null && x.SentBranchName.ToLower().Contains(searchText)) ||
                (x.ProductName != null && x.ProductName.ToLower().Contains(searchText)) ||
                (x.ProductCode != null && x.ProductCode.ToLower().Contains(searchText)) ||
                (x.InvoiceNumber != null && x.InvoiceNumber.ToLower().Contains(searchText)) ||
                (x.Quantity != null && x.Quantity.ToString().Contains(searchText)) ||
                (x.Description != null && x.Description.ToLower().Contains(searchText)) ||
                (x.TransferDate != null && x.TransferDate.ToString().Contains(searchText)) ||
                (x.SenderAppUserName != null && x.SenderAppUserName.ToString().Contains(searchText))
                );

                stockTransferListControl._filteredData.Clear();
                foreach (var item in filteredList)
                {
                    stockTransferListControl._filteredData.Add(item);
                }
            }
            else
            {
                stockTransferListControl._filteredData.Clear();
                foreach (var item in stockTransferListControl._originalData)
                {
                    stockTransferListControl._filteredData.Add(item);
                }
            }
        }
        private async void bttnAdd_Click(object sender, EventArgs e)
        {
            if (branchComboBoxControl1.BranchComboBox.SelectedValue is not null && branchComboBoxControl2.BranchComboBox.SelectedValue is not null && productComboBoxControl.ProductNameComboBox.SelectedValue is not null && productComboBoxControl.ProductCodeComboBox.SelectedValue is not null)
            {
                CreateStockTransferDTO createStockTransferDTO = new CreateStockTransferDTO
                {
                    SenderBranchId = (Guid)branchComboBoxControl1.BranchComboBox.SelectedValue,
                    SentBranchId = (Guid)branchComboBoxControl2.BranchComboBox.SelectedValue,
                    ProductId = (Guid)productComboBoxControl.ProductNameComboBox.SelectedValue,
                    InvoiceNumber = txtInvoiceNumber.Text,
                    Quantity = int.Parse(txtQuantity.Text),
                    Description = txtDescription.Text,
                    TransferDate = transferDateTimePicker.Value,
                    TransactorAppUserId = AppUserId
                };

                HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("stockTransfer/Add", createStockTransferDTO);

                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                await stockTransferListControl.StockTransferList(_webApiService, AppUserId);
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void bttnUpdate_Click(object sender, EventArgs e)
        {
            if (branchComboBoxControl1.BranchComboBox.SelectedValue is not null && branchComboBoxControl2.BranchComboBox.SelectedValue is not null && productComboBoxControl.ProductNameComboBox.SelectedValue is not null && productComboBoxControl.ProductCodeComboBox.SelectedValue is not null)
            {
                if (Id != Guid.Empty)
                {
                    if (DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                    {

                        UpdateStockTransferDTO updateStockTransferDTO = new UpdateStockTransferDTO
                        {
                            Id = Id,
                            SenderBranchId = (Guid)branchComboBoxControl1.BranchComboBox.SelectedValue,
                            SentBranchId = (Guid)branchComboBoxControl2.BranchComboBox.SelectedValue,
                            ProductId = (Guid)productComboBoxControl.ProductNameComboBox.SelectedValue,
                            InvoiceNumber = txtInvoiceNumber.Text,
                            Quantity = int.Parse(txtQuantity.Text),
                            Description = txtDescription.Text,
                            TransferDate = transferDateTimePicker.Value,
                            TransactorAppUserId = AppUserId
                        };

                        HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("stockTransfer/Update", updateStockTransferDTO);

                        if (!response.IsSuccessStatusCode)
                        {
                            await ResponseController.ErrorResponseController(response);
                            return;
                        }

                        await stockTransferListControl.StockTransferList(_webApiService, AppUserId);
                        Id = default;
                    }
                }
                else
                {
                    MessageBox.Show("Güncellenecek İşlemi Listeden Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void bttnDelete_Click(object sender, EventArgs e)
        {
            if (Id != Guid.Empty)
            {
                if (DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"stockTransfer/Delete/{Id}/{AppUserId}");

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                    await stockTransferListControl.StockTransferList(_webApiService, AppUserId);
                    Id = default;
                }
            }
            else
            {
                MessageBox.Show("Silenecek İşlemi Listeden Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
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

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private void bttnNewBranch_Click(object sender, EventArgs e)
        {
            frmBranchAdd frmBranchAdd = _serviceProvider.GetRequiredService<frmBranchAdd>();
            FormController.FormOpenController(frmBranchAdd);
        }

        private void bttnNewSupplier_Click(object sender, EventArgs e)
        {
            frmProductAdd frmProductAdd = _serviceProvider.GetRequiredService<frmProductAdd>();
            FormController.FormOpenController(frmProductAdd);
        }

        private async void dgwStockTransferList_DoubleClick(object sender, EventArgs e)
        {
            Id = (Guid)stockTransferListControl.DataGridViewStockTransferList.SelectedRows[0].Cells[0].Value;

            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"stockTransfer/GetById/{Id}/{AppUserId}");

            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<GetStockTransferDTO>(response);

            if (result is not null)
            {
                branchComboBoxControl1.BranchComboBox.SelectedValue = result.Data.SenderBranchId;
                branchComboBoxControl2.BranchComboBox.SelectedValue = result.Data.SentBranchId;
                productComboBoxControl.ProductNameComboBox.SelectedValue = result.Data.ProductId;
                txtInvoiceNumber.Text = result.Data.InvoiceNumber;
                txtQuantity.Text = result.Data.Quantity.ToString();
                txtDescription.Text = result.Data.Description;
                transferDateTimePicker.Value = result.Data.TransferDate;
            }
        }
    }
}
