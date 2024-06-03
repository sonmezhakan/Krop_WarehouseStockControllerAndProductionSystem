using Krop.Common.Helpers.WebApiRequests.Branches;
using Krop.Common.Helpers.WebApiRequests.Productions;
using Krop.Common.Helpers.WebApiRequests.ProductReceipts;
using Krop.Common.Helpers.WebApiRequests.Products;
using Krop.DTO.Dtos.Branches;
using Krop.DTO.Dtos.Productions;
using Krop.DTO.Dtos.ProductReceipts;
using Krop.DTO.Dtos.Products;
using Krop.WinForms.HelpersClass;
using System.ComponentModel;

namespace Krop.WinForms.Forms.Productions
{
    public partial class frmProduction : Form
    {
        private BindingList<GetProductReceiptListDTO> _productReceiptOriginalData;
        private BindingList<GetProductReceiptListDTO> _productReceiptFilteredData;
        private BindingList<GetProductionListDTO> _productionOriginalData;
        private BindingList<GetProductionListDTO> _productionFilteredData;
        public Guid appUserId;
        private readonly IBranchRequest _branchRequest;
        private readonly IProductionRequest _productionRequest;
        private readonly IProductReceiptRequest _productReceiptRequest;
        private readonly IProductRequest _productRequest;

        public frmProduction(IBranchRequest branchRequest,IProductionRequest productionRequest,IProductReceiptRequest productReceiptRequest,IProductRequest productRequest)
        {
            InitializeComponent();
            _branchRequest = branchRequest;
            _productionRequest = productionRequest;
            _productReceiptRequest = productReceiptRequest;
            _productRequest = productRequest;
        }

        private void frmProduction_Load(object sender, EventArgs e)
        {
            BranchList();
            ProductList();
            ProductionList();
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

            cmbBoxBranch.DataSource = null;
            cmbBoxBranch.DisplayMember = "BranchName";
            cmbBoxBranch.ValueMember = "Id";

            cmbBoxBranch.DataSource = result;
            cmbBoxBranch.SelectedIndex = -1;
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
            if (cmbBoxProductName.SelectedValue is not null && cmbBoxProductCode.DataSource is not null)
            {
                cmbBoxProductCode.SelectedValue = cmbBoxProductName.SelectedValue;
                ProductReceiptList();
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
            dgwProductionList.Columns[0].HeaderText = "Id";
            dgwProductionList.Columns[1].HeaderText = "Ürün Id";
            dgwProductionList.Columns[2].HeaderText = "Ürün Adı";
            dgwProductionList.Columns[3].HeaderText = "Ürün Kodu";
            dgwProductionList.Columns[4].HeaderText = "Kullanılacak Miktar";

            dgwProductionList.Columns[0].Visible = false;
            dgwProductionList.Columns[1].Visible = false;
        }
        private async void ProductReceiptList()
        {
 
            HttpResponseMessage response = await _productReceiptRequest.GetAllAsync((Guid)cmbBoxProductName.SelectedValue);
            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetProductReceiptListDTO>(response).Data;

            _productReceiptOriginalData = new BindingList<GetProductReceiptListDTO>(result.ToList());
            _productReceiptFilteredData = new BindingList<GetProductReceiptListDTO>(_productReceiptOriginalData.ToList());

            dgwProductReceiptList.DataSource = _productReceiptFilteredData;

            DgwProductReceiptSettings();
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
        private async void ProductionList()
        {
            HttpResponseMessage response = await _productionRequest.GetAllAsync(appUserId);
            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetProductionListDTO>(response).Data;

            _productionOriginalData = new BindingList<GetProductionListDTO>(result.ToList());
            _productionFilteredData = new BindingList<GetProductionListDTO>(_productionOriginalData.ToList());

            dgwProductionList.DataSource = _productionFilteredData;

            DgwProductionSettings();
        }
        private void ProductReceiptSearch()
        {

        }
        private void ProductionSearch()
        {

        }

        private async void bttnAdd_Click(object sender, EventArgs e)
        {
            if(cmbBoxBranch.SelectedValue is not null && cmbBoxProductName.SelectedValue is not null && cmbBoxProductCode.SelectedValue is not null)
            {
                await _productionRequest.AddAsync(new CreateProductionDTO
                {
                    AppUserId = appUserId,
                    BranchId = (Guid)cmbBoxBranch.SelectedValue,
                    ProductId = (Guid)cmbBoxProductName.SelectedValue,
                    ProductionDate = productionDateTimePicker.Value,
                    ProductionQuantity =int.Parse(txtProductionQuantity.Text),
                    Description = txtDescription.Text
                });

                ProductionList();
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
