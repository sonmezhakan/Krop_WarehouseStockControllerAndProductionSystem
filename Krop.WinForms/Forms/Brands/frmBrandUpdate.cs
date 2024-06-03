using Krop.Common.Helpers.WebApiRequests.Brands;
using Krop.DTO.Dtos.Brands;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Brands
{
    public partial class frmBrandUpdate : Form
    {
        public Guid Id;
        private readonly IBrandRequest _brandRequest;

        public frmBrandUpdate(IBrandRequest brandRequest)
        {
            InitializeComponent();
            _brandRequest = brandRequest;
        }

        private void frmBrandUpdate_Load(object sender, EventArgs e)
        {
            ComboBoxList();
            if (cmbBoxBrandSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxBrandSelect.SelectedValue = Id;
        }

        private async void bttnBrandUpdate_Click(object sender, EventArgs e)
        {
            if (cmbBoxBrandSelect.SelectedValue is not null)
            {
                if (DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    UpdateBrandDTO updateBrandDTO = new UpdateBrandDTO
                    {
                        Id = (Guid)cmbBoxBrandSelect.SelectedValue,
                        BrandName = txtBrandName.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        Email = txtEmail.Text
                    };

                    HttpResponseMessage response = await _brandRequest.UpdateAsync(updateBrandDTO);

                    if (!response.IsSuccessStatusCode)
                    {
                        ResponseController.ErrorResponseController(response);
                        return;
                    }

                    ComboBoxList();//Listele
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ComboBoxList()
        {
            HttpResponseMessage response = await _brandRequest.GetAllComboBoxAsync();
            if(!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetBrandComboBoxDTO>(response).Data;

            cmbBoxBrandSelect.DataSource = null;
            
            cmbBoxBrandSelect.DisplayMember = "BrandName";
            cmbBoxBrandSelect.ValueMember = "Id";

            cmbBoxBrandSelect.SelectedIndexChanged -= cmbBoxBrandSelect_SelectedIndexChanged;//SelectedIndexChanged Pasif

            cmbBoxBrandSelect.DataSource = result;//liste aktarılıyor
            cmbBoxBrandSelect.SelectedIndex = -1;
            cmbBoxBrandSelect.SelectedIndexChanged += cmbBoxBrandSelect_SelectedIndexChanged;//SelectedIndexChanged Aktif
        }
        private async void cmbBoxBrandSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxBrandSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = await _brandRequest.GetByIdAsync((Guid)cmbBoxBrandSelect.SelectedValue);
                if(!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                var result = ResponseController.SuccessDataResponseController<GetBrandDTO>(response).Data;

                txtBrandName.Text = result.BrandName;
                txtEmail.Text = result.Email;
                txtPhoneNumber.Text = result.PhoneNumber;
            }
        }
    }
}
