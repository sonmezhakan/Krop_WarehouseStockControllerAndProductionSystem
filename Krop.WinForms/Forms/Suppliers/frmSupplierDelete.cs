using Krop.Business.Features.Suppliers.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Utilits.Result;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using Krop.WinForms.HelpersClass.SupplierHelpers;

namespace Krop.WinForms.Suppliers
{
    public partial class frmSupplierDelete : Form
    {
        private readonly ISupplierHelper _supplierHelper;
        private readonly IWebApiService _webApiService;
        public Guid Id;

        public frmSupplierDelete(ISupplierHelper supplierHelper, IWebApiService webApiService)
        {
            InitializeComponent();
            _supplierHelper = supplierHelper;
            _webApiService = webApiService;
        }

        private void frmSupplierDelete_Load(object sender, EventArgs e)
        {
            SupplierList();
            if (cmbBoxSupplierSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxSupplierSelect.SelectedValue = Id;
        }

        private void SupplierList()
        {
            List<GetSupplierComboBoxDTO> result = _supplierHelper.GetAllComboBoxAsync();
            if (result is null)
                return;

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
        private void bttnSupplierDelete_Click(object sender, EventArgs e)
        {
            if (cmbBoxSupplierSelect.SelectedValue != null)
            {
               if(DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = _webApiService.httpClient.DeleteAsync($"supplier/delete/{cmbBoxSupplierSelect.SelectedValue}").Result;

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
