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

        private void frmBrandDelete_Load(object sender, EventArgs e)
        {
            CategoryList();
            if (cmbBoxBrandSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxBrandSelect.SelectedValue = Id;
        }

        private void bttnBrandDelete_Click(object sender, EventArgs e)
        {
            if(cmbBoxBrandSelect.SelectedValue is not null)
            {
                if(DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = _webApiService.httpClient.DeleteAsync($"brand/delete/{cmbBoxBrandSelect.SelectedValue}").Result;

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

        private void CategoryList()
        {
            List<GetBrandComboBoxDTO> result = _brandHelpers.GetAllComboBoxAsync();
            if (result is null)
                return;

            cmbBoxBrandSelect.DataSource = null;

            cmbBoxBrandSelect.DisplayMember = "BrandName";
            cmbBoxBrandSelect.ValueMember = "Id";

            cmbBoxBrandSelect.DataSource = result;
            cmbBoxBrandSelect.SelectedIndex = -1;
        }
    }
}
