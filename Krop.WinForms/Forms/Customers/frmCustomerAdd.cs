using Krop.Common.Helpers.WebApiRequests.Customers;
using Krop.DTO.Dtos.Customers;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Customers
{
    public partial class frmCustomerAdd : Form
    {
        private readonly ICustomerRequest _customerRequest;

        public frmCustomerAdd(ICustomerRequest customerRequest)
        {
            InitializeComponent();
            _customerRequest = customerRequest;
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private void frmCustomerAdd_Load(object sender, EventArgs e)
        {
            txtPhoneNumber.MaxLength = 11;
        }

        private async void bttnCustomerAdd_Click(object sender, EventArgs e)
        {
            CreateCustomerDTO createCustomerDTO = new CreateCustomerDTO
            {
                CompanyName = txtCompanyName.Text,
                ContactName = txtContactName.Text,
                ContactTitle = txtContactTitle.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Country = txtCountry.Text,
                City = txtCity.Text,
                Addres = txtAddress.Text,
                Invoice = radioBttnPerson.Checked ? Entities.Enums.InvoiceEnum.Bireysel : Entities.Enums.InvoiceEnum.Kurumsal
            };

            HttpResponseMessage response = await _customerRequest.AddAsync(createCustomerDTO);

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }
        }
    }
}
