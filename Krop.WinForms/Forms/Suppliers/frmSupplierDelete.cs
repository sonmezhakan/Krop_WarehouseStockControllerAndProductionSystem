using Krop.Common.Helpers.WebApiRequests.Suppliers;
using Krop.DTO.Dtos.Suppliers;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Suppliers
{
    public partial class frmSupplierDelete : Form
    {
        public Guid Id;
        private readonly ISupplierRequest _supplierRequest;

        public frmSupplierDelete(ISupplierRequest supplierRequest)
        {
            InitializeComponent();
            _supplierRequest = supplierRequest;
        }

        private void frmSupplierDelete_Load(object sender, EventArgs e)
        {
            SupplierList();
            if (cmbBoxSupplierSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxSupplierSelect.SelectedValue = Id;
        }

        private async void SupplierList()
        {
            HttpResponseMessage response = await _supplierRequest.GetAllComboBoxAsync();
            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetSupplierComboBoxDTO>(response).Data;

            cmbBoxSupplierSelect.DataSource = null;

            cmbBoxSupplierSelect.DisplayMember = "CompanyName";
            cmbBoxSupplierSelect.ValueMember = "Id";

            cmbBoxSupplierSelect.SelectedIndexChanged -= CmbBoxSupplierSelect_SelectedIndexChanged;
            cmbBoxSupplierSelect.DataSource = result;
            cmbBoxSupplierSelect.SelectedIndex = -1;
            cmbBoxSupplierSelect.SelectedIndexChanged += CmbBoxSupplierSelect_SelectedIndexChanged;
        }

        private void CmbBoxSupplierSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {

        }
        private async void bttnSupplierDelete_Click(object sender, EventArgs e)
        {
            if (cmbBoxSupplierSelect.SelectedValue != null)
            {
               if(DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = await _supplierRequest.DeleteAsync((Guid)cmbBoxSupplierSelect.SelectedValue);

                    if (!response.IsSuccessStatusCode)
                    {
                        ResponseController.ErrorResponseController(response);
                        return;
                    }

                    SupplierList();
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçin Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
