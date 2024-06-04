using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Brands;
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
           await CategoryList();
            if (cmbBoxBrandSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxBrandSelect.SelectedValue = Id;
        }

        private async void bttnBrandDelete_Click(object sender, EventArgs e)
        {
            if(cmbBoxBrandSelect.SelectedValue is not null)
            {
                if(DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"brand/delete/{cmbBoxBrandSelect.SelectedValue}");

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                  await  CategoryList();//Listele
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CategoryList()
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

            cmbBoxBrandSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxBrandSelect.SelectedIndex = -1;
        }
    }
}
