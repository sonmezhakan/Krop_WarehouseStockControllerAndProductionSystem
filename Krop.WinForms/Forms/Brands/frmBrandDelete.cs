using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Brands
{
    public partial class frmBrandDelete : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmBrandDelete(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmBrandDelete_Load(object sender, EventArgs e)
        {
            await brandComboBoxControl.BrandList(_webApiService);
            brandComboBoxControl.BrandSelect(Id);
        }

        private async void bttnBrandDelete_Click(object sender, EventArgs e)
        {
            if(brandComboBoxControl.BrandComboBox.SelectedValue is not null)
            {
                if(DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"brand/delete/{(Guid)brandComboBoxControl.BrandComboBox.SelectedValue}");

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
    }
}
