using Krop.Common.Helpers.WebApiRequests.Brands;
using Krop.DTO.Dtos.Brands;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.Brands
{
    public partial class frmBrandCart : Form
    {
                public Guid Id;
        private readonly IBrandRequest _brandRequest;

        public frmBrandCart(IBrandRequest brandRequest)
        {
            InitializeComponent();
            _brandRequest = brandRequest;
        }

        private void frmBrandCart_Load(object sender, EventArgs e)
        {
            BrandList();
            if (cmbBoxBrandSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxBrandSelect.SelectedValue = Id;
        }

        private async void BrandList()
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

            cmbBoxBrandSelect.SelectedIndexChanged -= cmbBoxBrandSelect_SelectedIndexChanged;
            cmbBoxBrandSelect.DataSource = result;
            cmbBoxBrandSelect.SelectedIndex = -1;
            cmbBoxBrandSelect.SelectedIndexChanged += cmbBoxBrandSelect_SelectedIndexChanged;
        }

        private async void cmbBoxBrandSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbBoxBrandSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = await _brandRequest.GetByIdAsync((Guid)cmbBoxBrandSelect.SelectedValue);
                if (!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                var result = ResponseController.SuccessDataResponseController<GetBrandDTO>(response).Data;

                txtPhoneNumber.Text = result.PhoneNumber;
                txtEmail.Text = result.Email;
            }

        }
    }
}
