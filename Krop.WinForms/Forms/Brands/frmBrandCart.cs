using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Brands;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.Brands
{
    public partial class frmBrandCart : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmBrandCart(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmBrandCart_Load(object sender, EventArgs e)
        {
            await brandComboBoxControl.BrandList(_webApiService);
            brandComboBoxControl.BrandComboBox.SelectedIndexChanged += cmbBoxBrandSelect_SelectedIndexChanged;
            brandComboBoxControl.BrandSelect(Id);
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

                var result = await ResponseController.SuccessDataResponseController<GetBrandDTO>(response);

                if (result is not null)
                {
                    txtPhoneNumber.Text = result.Data.PhoneNumber;
                    txtEmail.Text = result.Data.Email;
                }
            }

        }
    }
}
