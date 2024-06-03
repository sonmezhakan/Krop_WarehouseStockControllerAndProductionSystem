using Krop.Common.Helpers.WebApiRequests.Customers;
using Krop.DTO.Dtos.Customers;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Customers
{
    public partial class frmCustomerCart : Form
    {
        
        public Guid Id;
        private readonly ICustomerRequest _customerRequest;

        public frmCustomerCart(ICustomerRequest customerRequest)
        {
            InitializeComponent();
            _customerRequest = customerRequest;
        }

        private void frmCustomerCart_Load(object sender, EventArgs e)
        {
            CustomerList();
            if (cmbBoxCustomerSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxCustomerSelect.SelectedValue = Id;
        }
        private async void CustomerList()
        {
            HttpResponseMessage response = await _customerRequest.GetAllComboBoxAsync();
            if(!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetCustomerComboBoxDTO>(response).Data;

            cmbBoxCustomerSelect.DataSource = null;

            cmbBoxCustomerSelect.DisplayMember = "CompanyName";
            cmbBoxCustomerSelect.ValueMember = "Id";

            cmbBoxCustomerSelect.SelectedIndexChanged -= CmbBoxCustomerSelect_SelectedIndexChanged;
            cmbBoxCustomerSelect.DataSource = result;
            cmbBoxCustomerSelect.SelectedIndex = -1;
            cmbBoxCustomerSelect.SelectedIndexChanged += CmbBoxCustomerSelect_SelectedIndexChanged;
        }

        private async void CmbBoxCustomerSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxCustomerSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = await _customerRequest.GetByIdAsync((Guid)cmbBoxCustomerSelect.SelectedValue);
                if(!response.IsSuccessStatusCode)
                {
                    ResponseController.ErrorResponseController(response);
                    return;
                }

                var result = ResponseController.SuccessDataResponseController<GetCustomerDTO>(response).Data;

                if (result.Invoice == Entities.Enums.InvoiceEnum.Bireysel)
                    radioBttnPerson.Checked = true;
                else
                    radioBttnCompany.Checked = true;

                txtContactName.Text = result.ContactName;
                txtContactTitle.Text = result.ContactTitle;
                txtPhoneNumber.Text = result.PhoneNumber;
                txtEmail.Text = result.Email;
                txtCountry.Text = result.Country;
                txtCity.Text = result.City;
                txtAddress.Text = result.Addres;
            }
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }
    }
}
