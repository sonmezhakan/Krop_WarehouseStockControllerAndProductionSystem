using Krop.Common.Helpers.WebApiRequests.Brands;
using Krop.DTO.Dtos.Brands;
using Krop.DTO.Dtos.Suppliers;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Brands
{
    public partial class frmBrandDelete : Form
    {
        public Guid Id;
        private readonly IBrandRequest _brandRequest;

        public frmBrandDelete(IBrandRequest brandRequest)
        {
            InitializeComponent();
            _brandRequest = brandRequest;
        }

        private void frmBrandDelete_Load(object sender, EventArgs e)
        {
            CategoryList();
            if (cmbBoxBrandSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxBrandSelect.SelectedValue = Id;
        }

        private async void bttnBrandDelete_Click(object sender, EventArgs e)
        {
            if(cmbBoxBrandSelect.SelectedValue is not null)
            {
                if(DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = await _brandRequest.DeleteAsync((Guid)cmbBoxBrandSelect.SelectedValue);

                    if (!response.IsSuccessStatusCode)
                    {
                        ResponseController.ErrorResponseController(response);
                        return;
                    }

                    CategoryList();//Listele
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CategoryList()
        {
            HttpResponseMessage response = await _brandRequest.GetAllComboBoxAsync();
            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetBrandComboBoxDTO>(response).Data;

            cmbBoxBrandSelect.DataSource = null;

            cmbBoxBrandSelect.DisplayMember = "BrandName";
            cmbBoxBrandSelect.ValueMember = "Id";

            cmbBoxBrandSelect.DataSource = result;
            cmbBoxBrandSelect.SelectedIndex = -1;
        }
    }
}
