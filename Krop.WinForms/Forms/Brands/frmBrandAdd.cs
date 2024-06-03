using Krop.Common.Helpers.WebApiRequests.Brands;
using Krop.DTO.Dtos.Brands;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.Brands
{
    public partial class frmBrandAdd : Form
    {
        private readonly IBrandRequest _brandRequest;

        public frmBrandAdd(IBrandRequest brandRequest)
        {
            InitializeComponent();
            _brandRequest = brandRequest;
        }

        private void frmBrandAdd_Load(object sender, EventArgs e)
        {

        }

        private async void bttnBrandAdd_Click(object sender, EventArgs e)
        {
            CreateBrandDTO createBrandDTO = new CreateBrandDTO
            {
                BrandName = txtBrandName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Email = txtEmail.Text
            };

            HttpResponseMessage response = await _brandRequest.AddAsync(createBrandDTO);

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

        }
    }
}
