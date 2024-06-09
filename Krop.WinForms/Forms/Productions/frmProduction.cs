using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Productions;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.Productions
{
    public partial class frmProduction : Form
    {
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
            await branchComboBoxControl.BranchList(_webApiService);

            await productComboBoxControl.ProductList(_webApiService);
            productComboBoxControl.ProductNameComboBox.SelectedIndexChanged += CmbBoxProductName_SelectedIndexChanged;
            productComboBoxControl.ProductCodeComboBox.SelectedIndexChanged += CmbBoxProductCode_SelectedIndexChanged;

            await productionListControl.ProductionList(_webApiService,appUserId);
            productionListControl.DataGridViewProductionList.DoubleClick += dgwProductionList_DoubleClick;
        }

        private async void CmbBoxProductName_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (productComboBoxControl.ProductNameComboBox.SelectedValue is not null && productComboBoxControl.ProductCodeComboBox.DataSource is not null)
            {
                productComboBoxControl.ProductCodeComboBox.SelectedValue = productComboBoxControl.ProductNameComboBox.SelectedValue;

                await productReceiptListControl.ProductReceiptList(_webApiService, (Guid)productComboBoxControl.ProductNameComboBox.SelectedValue);
            }
        }

        private void CmbBoxProductCode_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (productComboBoxControl.ProductCodeComboBox.SelectedValue is not null && productComboBoxControl.ProductNameComboBox.DataSource is not null)
            {
                productComboBoxControl.ProductNameComboBox.SelectedValue = productComboBoxControl.ProductCodeComboBox.SelectedValue;
            }
        }
        private void ProductReceiptSearch()
        {
            string searchText = txtProductReceiptSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = productReceiptListControl._originalData.Where(x =>
                (x.ProductName != null && x.ProductName.ToLower().Contains(searchText)) ||
                (x.ProductCode != null && x.ProductCode.ToLower().Contains(searchText)) ||
                (x.Quantity != null && x.Quantity.ToString().Contains(searchText))
                );

                productReceiptListControl._filteredData.Clear();
                foreach (var item in filteredList)
                {
                    productReceiptListControl._filteredData.Add(item);
                }
            }
            else
            {
                productReceiptListControl._filteredData.Clear();
                foreach (var item in productReceiptListControl._originalData)
                {
                    productReceiptListControl._filteredData.Add(item);
                }
            }
        }
        private void ProductionSearch()
        {
            string searchText = txtProductionSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = productionListControl._originalData.Where(x =>
                    x.ProductName.ToLower().Contains(searchText) ||
                    x.ProductCode.ToLower().Contains(searchText) ||
                    x.BranchName.ToLower().Contains(searchText) ||
                    x.ProductionQuantity.ToString().Contains(searchText) ||
                    x.ProductionDate.ToString().Contains(searchText) ||
                    (x.Description != null && x.Description.ToLower().Contains(searchText)) ||
                    x.UserName.Contains(searchText)
                    );

                productionListControl._filteredData.Clear();
                foreach (var item in filteredList)
                {
                    productionListControl._filteredData.Add(item);
                }
            }
            else
            {
                productionListControl._filteredData.Clear();
                foreach (var item in productionListControl._originalData)
                {
                    productionListControl._filteredData.Add(item);
                }
            }
        }

        private async void bttnAdd_Click(object sender, EventArgs e)
        {
            if (branchComboBoxControl.BranchComboBox.SelectedValue is not null && productComboBoxControl.ProductNameComboBox.SelectedValue is not null && productComboBoxControl.ProductCodeComboBox.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("production/Add", new CreateProductionDTO
                {
                    AppUserId = appUserId,
                    BranchId = (Guid)branchComboBoxControl.BranchComboBox.SelectedValue,
                    ProductId = (Guid)productComboBoxControl.ProductNameComboBox.SelectedValue,
                    ProductionDate = productionDateTimePicker.Value,
                    ProductionQuantity = int.Parse(txtProductionQuantity.Text),
                    Description = txtDescription.Text
                });

                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                await productionListControl.ProductionList(_webApiService, appUserId);
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void bttnUpdate_Click(object sender, EventArgs e)
        {
            if (branchComboBoxControl.BranchComboBox.SelectedValue is not null && productComboBoxControl.ProductCodeComboBox.SelectedValue is not null && productComboBoxControl.ProductNameComboBox.SelectedValue is not null)
            {
                if (id != Guid.Empty)
                {
                    if (DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                    {
                        HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("production/Update",new UpdateProductionDTO
                        {
                            Id = id,
                            AppUserId = appUserId,
                            BranchId = (Guid)branchComboBoxControl.BranchComboBox.SelectedValue,
                            ProductId = (Guid)productComboBoxControl.ProductNameComboBox.SelectedValue,
                            Description = txtDescription.Text,
                            ProductionDate = productionDateTimePicker.Value,
                            ProductionQuantity = int.Parse(txtProductionQuantity.Text)
                        });
                        if (!response.IsSuccessStatusCode)
                        {
                            await ResponseController.ErrorResponseController(response);
                            return;
                        }

                        await productionListControl.ProductionList(_webApiService, appUserId);
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

                    await productionListControl.ProductionList(_webApiService, appUserId);
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
            id = (Guid)productionListControl.DataGridViewProductionList.SelectedRows[0].Cells[0].Value;
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"production/getById/{id}/{appUserId}");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<GetProductionDTO>(response);
            if(result is not null)
            {
                branchComboBoxControl.BranchComboBox.SelectedValue = result.Data.BranchId;
                productComboBoxControl.ProductNameComboBox.SelectedValue = result.Data.ProductId;
                txtDescription.Text = result.Data.Description;
                productionDateTimePicker.Value = result.Data.ProductionDate;
                txtProductionQuantity.Text = result.Data.ProductionQuantity.ToString();
            }
        }
    }
}
