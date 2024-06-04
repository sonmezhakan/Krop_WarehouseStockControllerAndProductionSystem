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
            await BrandList();
            if (cmbBoxBrandSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxBrandSelect.SelectedValue = Id;
        }

        private async Task BrandList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("brand/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetBrandComboBoxDTO>>(response);

            cmbBoxBrandSelect.DataSource = null;

            cmbBoxBrandSelect.DisplayMember = "BrandName";
            cmbBoxBrandSelect.ValueMember = "Id";

            cmbBoxBrandSelect.SelectedIndexChanged -= cmbBoxBrandSelect_SelectedIndexChanged;
            cmbBoxBrandSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxBrandSelect.SelectedIndex = -1;
            cmbBoxBrandSelect.SelectedIndexChanged += cmbBoxBrandSelect_SelectedIndexChanged;
        }

        private async void cmbBoxBrandSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbBoxBrandSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"brand/GetById/{cmbBoxBrandSelect.SelectedValue}");
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
