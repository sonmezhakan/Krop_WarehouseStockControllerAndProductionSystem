using Krop.Common.Helpers.WebApiRequests.Branches;
using Krop.Common.Helpers.WebApiRequests.Products;
using Krop.Common.Helpers.WebApiRequests.StockTransfers;
using Krop.DTO.Dtos.Branches;
using Krop.DTO.Dtos.Products;
using Krop.DTO.Dtos.StockTransfers;
using Krop.DTO.Dtos.Suppliers;
using Krop.WinForms.Forms.Branches;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using Krop.WinForms.Products;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.StockTransfers
{
    public partial class frmStockTransfer : Form
    {
        private readonly IBranchRequest _branchRequest;
        private readonly IProductRequest _productRequest;
        private readonly IStockTransferRequest _stockTransferRequest;
        private readonly IServiceProvider _serviceProvider;

        public Guid Id;
        public Guid AppUserId;
        private BindingList<GetStockTransferListDTO> _originalData;
        private BindingList<GetStockTransferListDTO> _filteredData;

        public frmStockTransfer(IBranchRequest branchRequest, IProductRequest productRequest, IStockTransferRequest stockTransferRequest, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _branchRequest = branchRequest;
            _productRequest = productRequest;
            _stockTransferRequest = stockTransferRequest;
            _serviceProvider = serviceProvider;
        }

        private void frmStockTransfer_Load(object sender, EventArgs e)
        {
            BranchList();
            ProductList();
            StockTransferList();
        }
        private async void BranchList()
        {
            HttpResponseMessage response = await _branchRequest.GetAllComboBoxAsync();
            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetBranchComboBoxDTO>(response).Data;

            List<GetBranchComboBoxDTO> senderBranchList = result.Select(x => new GetBranchComboBoxDTO
            {
                BranchName = x.BranchName,
                Id = x.Id
            }).ToList();
            List<GetBranchComboBoxDTO> sentBranchList = result.Select(x => new GetBranchComboBoxDTO
            {
                BranchName = x.BranchName,
                Id = x.Id
            }).ToList();

            SenderBranchList(senderBranchList);
            SentBranchList(sentBranchList);
        }
        private void SenderBranchList(List<GetBranchComboBoxDTO> getBranchComboBoxDTOs)
        {
            cmbBoxSenderBranch.DataSource = null;

            cmbBoxSenderBranch.DisplayMember = "BranchName";
            cmbBoxSenderBranch.ValueMember = "Id";
            cmbBoxSenderBranch.DataSource = getBranchComboBoxDTOs;
            cmbBoxProductName.SelectedIndex = -1;
        }
        private void SentBranchList(List<GetBranchComboBoxDTO> getBranchComboBoxDTOs)
        {
            cmbBoxSentBranch.DataSource = null;

            cmbBoxSentBranch.DisplayMember = "BranchName";
            cmbBoxSentBranch.ValueMember = "Id";
            cmbBoxSentBranch.DataSource = getBranchComboBoxDTOs;
            cmbBoxProductName.SelectedIndex = -1;
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

        private void CmbBoxProductName_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxProductName.SelectedValue != null && cmbBoxProductCode.DataSource != null)
            {
                cmbBoxProductCode.SelectedValue = cmbBoxProductName.SelectedValue;
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
            if (cmbBoxProductCode.SelectedValue != null && cmbBoxProductName.DataSource != null)
            {
                cmbBoxProductName.SelectedValue = cmbBoxProductCode.SelectedValue;
            }
        }
        private void DgwStockTransferListSettings()
        {
            dgwStockTransferList.Columns[0].HeaderText = "Id";
            dgwStockTransferList.Columns[1].HeaderText = "Gönderen Şube";
            dgwStockTransferList.Columns[2].HeaderText = "Gönderilen Şube";
            dgwStockTransferList.Columns[3].HeaderText = "Ürün Adı";
            dgwStockTransferList.Columns[4].HeaderText = "Ürün Kodu";
            dgwStockTransferList.Columns[5].HeaderText = "Fatura No";
            dgwStockTransferList.Columns[6].HeaderText = "Gönderilen Adet";
            dgwStockTransferList.Columns[7].HeaderText = "Açıklama";
            dgwStockTransferList.Columns[8].HeaderText = "Transfer Tarihi";
            dgwStockTransferList.Columns[9].HeaderText = "İşlem Yapan";

            dgwStockTransferList.Columns[0].Visible = false;
        }
        private async void StockTransferList()
        {
            HttpResponseMessage response = await _stockTransferRequest.AppUserBranchGetAll(AppUserId);

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetStockTransferListDTO>(response);

            _originalData = new BindingList<GetStockTransferListDTO>(result.Data);
            _filteredData = new BindingList<GetStockTransferListDTO>(_originalData.ToList());

            dgwStockTransferList.DataSource = _filteredData;

            DgwStockTransferListSettings();
        }
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                var filteredList = _originalData.Where(x =>
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
        private async void bttnAdd_Click(object sender, EventArgs e)
        {
            if (cmbBoxSenderBranch.SelectedValue is not null && cmbBoxSentBranch.SelectedValue is not null && cmbBoxProductName.SelectedValue is not null && cmbBoxProductCode.SelectedValue is not null)
            {
                CreateStockTransferDTO createStockTransferDTO = new CreateStockTransferDTO
                {
                    SenderBranchId = (Guid)cmbBoxSenderBranch.SelectedValue,
                    SentBranchId = (Guid)cmbBoxSentBranch.SelectedValue,
                    ProductId = (Guid)cmbBoxProductName.SelectedValue,
                    InvoiceNumber = txtInvoiceNumber.Text,
                    Quantity = int.Parse(txtQuantity.Text),
                    Description = txtDescription.Text,
                    TransferDate = transferDateTimePicker.Value,
                    TransactorAppUserId = AppUserId
                };

                HttpResponseMessage response = await _stockTransferRequest.AddAsync(createStockTransferDTO);

                if (!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                StockTransferList();
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void bttnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbBoxSenderBranch.SelectedValue is not null && cmbBoxSentBranch.SelectedValue is not null && cmbBoxProductName.SelectedValue is not null && cmbBoxProductCode.SelectedValue is not null)
            {
                if (Id != Guid.Empty)
                {
                    if (DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                    {

                        UpdateStockTransferDTO updateStockTransferDTO = new UpdateStockTransferDTO
                        {
                            Id = Id,
                            SenderBranchId = (Guid)cmbBoxSenderBranch.SelectedValue,
                            SentBranchId = (Guid)cmbBoxSentBranch.SelectedValue,
                            ProductId = (Guid)cmbBoxProductName.SelectedValue,
                            InvoiceNumber = txtInvoiceNumber.Text,
                            Quantity = int.Parse(txtQuantity.Text),
                            Description = txtDescription.Text,
                            TransferDate = transferDateTimePicker.Value,
                            TransactorAppUserId = AppUserId
                        };

                        HttpResponseMessage response =await _stockTransferRequest.UpdateAsync(updateStockTransferDTO);

                        if (!response.IsSuccessStatusCode)
                        {
                            ResponseController.ErrorResponseController(response);
                            return;
                        }

                        StockTransferList();
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
                    HttpResponseMessage response = await _stockTransferRequest.DeleteAsync(Id, AppUserId);

                    if (!response.IsSuccessStatusCode)
                    {
                        ResponseController.ErrorResponseController(response);
                        return;
                    }

                    StockTransferList();
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
            Id = (Guid)dgwStockTransferList.SelectedRows[0].Cells[0].Value;

            HttpResponseMessage response = await _stockTransferRequest.GetByIdAsync(Id, AppUserId);

            if(!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataResponseController<GetStockTransferDTO>(response);

            cmbBoxSenderBranch.SelectedValue = result.Data.SenderBranchId;
            cmbBoxSentBranch.SelectedValue = result.Data.SentBranchId;
            cmbBoxProductName.SelectedValue = result.Data.ProductId;
            txtInvoiceNumber.Text = result.Data.InvoiceNumber;
            txtQuantity.Text = result.Data.Quantity.ToString();
            txtDescription.Text = result.Data.Description;
            transferDateTimePicker.Value = result.Data.TransferDate;
        }
    }
}
