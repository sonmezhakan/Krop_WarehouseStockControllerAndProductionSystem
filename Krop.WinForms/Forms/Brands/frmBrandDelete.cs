using Krop.Business.Features.Brands.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.BrandHelpers;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Brands
{
    public partial class frmBrandDelete : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IBrandHelper _brandHelpers;
        public Guid Id;

        public frmBrandDelete(IWebApiService webApiService, IBrandHelper brandHelpers)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _brandHelpers = brandHelpers;
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
                    HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"brand/delete/{cmbBoxBrandSelect.SelectedValue}");

                    await ResponseController.ErrorResponseController(response);//Response hata kontrolü

                    await CategoryList();//Listele
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CategoryList()
        {
            List<GetBrandComboBoxDTO> result = await _brandHelpers.GetAllComboBoxAsync();

            cmbBoxBrandSelect.DataSource = null;

            cmbBoxBrandSelect.DisplayMember = "BrandName";
            cmbBoxBrandSelect.ValueMember = "Id";

            cmbBoxBrandSelect.DataSource = result;
            cmbBoxBrandSelect.SelectedIndex = -1;
        }
    }
}
