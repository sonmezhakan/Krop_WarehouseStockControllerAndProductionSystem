using Krop.Common.Helpers.WebApiRequests.Suppliers;
using Krop.DTO.Dtos.Suppliers;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Suppliers
{
    public partial class frmSupplierAdd : Form
    {
        private readonly ISupplierRequest _supplierRequest;

        public frmSupplierAdd(ISupplierRequest supplierRequest)
        {
            InitializeComponent();
            _supplierRequest = supplierRequest;
        }

        private async void bttnSupplierAdd_Click(object sender, EventArgs e)
        {
            CreateSupplierDTO createSupplierDTO = new CreateSupplierDTO
            {
                CompanyName = txtCompanyName.Text,
                ContactName = txtContactName.Text,
                ContactTitle = txtContactTitle.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Country = txtCountry.Text,
                City = txtCity.Text,
                Addres = txtAddress.Text,
                WebSite = txtWebSiteUrl.Text
            };

            HttpResponseMessage response = await _supplierRequest.AddAsync(createSupplierDTO);

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private void frmSupplierAdd_Load(object sender, EventArgs e)
        {
            txtPhoneNumber.MaxLength = 11;
        }
    }
}
