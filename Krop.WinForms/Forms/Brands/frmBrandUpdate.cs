using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Brands;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Brands
{
    public partial class frmBrandUpdate : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmBrandUpdate(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmBrandUpdate_Load(object sender, EventArgs e)
        {
            await brandComboBoxControl.BrandList(_webApiService);
            brandComboBoxControl.BrandComboBox.SelectedIndexChanged += cmbBoxBrandSelect_SelectedIndexChanged;
            brandComboBoxControl.BrandSelect(Id);
        }

        private async void bttnBrandUpdate_Click(object sender, EventArgs e)
        {
            if (brandComboBoxControl.BrandComboBox.SelectedValue is not null)
            {
                if (DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    UpdateBrandDTO updateBrandDTO = new UpdateBrandDTO
                    {
                        Id = (Guid)brandComboBoxControl.BrandComboBox.SelectedValue,
                        BrandName = txtBrandName.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        Email = txtEmail.Text
                    };

                    HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("brand/update", updateBrandDTO);

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                    await brandComboBoxControl.BrandList(_webApiService);
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cmbBoxBrandSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (brandComboBoxControl.BrandComboBox.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"brand/GetById/{(Guid)brandComboBoxControl.BrandComboBox.SelectedValue}");
                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                var result =await ResponseController.SuccessDataResponseController<GetBrandDTO>(response);

                if (result is not null)
                {
                    txtPhoneNumber.Text = result.Data.PhoneNumber;
                    txtEmail.Text = result.Data.Email;
                }
            }
        }
    }
}
