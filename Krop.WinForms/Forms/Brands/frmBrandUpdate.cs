using Krop.Business.Features.Brands.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.BrandHelpers;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Brands
{
    public partial class frmBrandUpdate : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IBrandHelper _brandHelpers;
        public Guid Id;

        public frmBrandUpdate(IWebApiService webApiService,IBrandHelper brandHelpers)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _brandHelpers = brandHelpers;
        }

        private void frmBrandUpdate_Load(object sender, EventArgs e)
        {
            ComboBoxList();
            if (cmbBoxBrandSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxBrandSelect.SelectedValue = Id;
        }

        private void bttnBrandUpdate_Click(object sender, EventArgs e)
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

                    HttpResponseMessage response = _webApiService.httpClient.PutAsJsonAsync("brand/update", updateBrandDTO).Result;

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

        private void ComboBoxList()
        {
            List<GetBrandComboBoxDTO> result = _brandHelpers.GetAllComboBoxAsync();//Listeyi alıyor
            if (result is null)
                return;

            cmbBoxBrandSelect.DataSource = null;
            
            cmbBoxBrandSelect.DisplayMember = "BrandName";
            cmbBoxBrandSelect.ValueMember = "Id";

            cmbBoxBrandSelect.SelectedIndexChanged -= cmbBoxBrandSelect_SelectedIndexChanged;//SelectedIndexChanged Pasif

            cmbBoxBrandSelect.DataSource = result;//liste aktarılıyor
            cmbBoxBrandSelect.SelectedIndex = -1;
            cmbBoxBrandSelect.SelectedIndexChanged += cmbBoxBrandSelect_SelectedIndexChanged;//SelectedIndexChanged Aktif
        }
        private void cmbBoxBrandSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxBrandSelect.SelectedValue is not null)
            {
                GetBrandDTO result = _brandHelpers.GetByBrandIdAsync((Guid)cmbBoxBrandSelect.SelectedValue);
                if (result is null)
                    return;

                txtBrandName.Text = result.BrandName;
                txtEmail.Text = result.Email;
                txtPhoneNumber.Text = result.PhoneNumber;
            }
        }
    }
}
