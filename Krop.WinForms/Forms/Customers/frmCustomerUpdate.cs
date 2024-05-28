using Krop.Business.Features.Customers.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.CustomerHelpers;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Customers
{
    public partial class frmCustomerUpdate : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly ICustomerHelper _customerHelper;
        public Guid Id;
        public frmCustomerUpdate(IWebApiService webApiService, ICustomerHelper customerHelper)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _customerHelper = customerHelper;
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private void frmCustomerUpdate_Load(object sender, EventArgs e)
        {
            CustomerList();
            txtPhoneNumber.MaxLength = 11;
            if (cmbBoxCustomerSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxCustomerSelect.SelectedValue = Id;
        }

        private void CustomerList()
        {
            List<GetCustomerComboBoxDTO> result = _customerHelper.GetAllComboBoxAsync();
            if (result is null)
                return;

            cmbBoxCustomerSelect.DataSource = null;

            cmbBoxCustomerSelect.DisplayMember = "CompanyName";
            cmbBoxCustomerSelect.ValueMember = "Id";

            cmbBoxCustomerSelect.SelectedIndexChanged -= CmbBoxCustomerSelect_SelectedIndexChanged;
            cmbBoxCustomerSelect.DataSource = result;
            cmbBoxCustomerSelect.SelectedIndex = -1;
            cmbBoxCustomerSelect.SelectedIndexChanged += CmbBoxCustomerSelect_SelectedIndexChanged;
        }

        private void CmbBoxCustomerSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxCustomerSelect.SelectedValue is not null)
            {
                var result = _customerHelper.GetByCustomerIdAsync((Guid)cmbBoxCustomerSelect.SelectedValue);
                if (result is null)
                    return;

                if (result.Invoice == Entities.Enums.InvoiceEnum.Bireysel)
                    radioBttnPerson.Checked = true;
                else
                    radioBttnCompany.Checked = true;

                txtCompanyName.Text = result.CompanyName;
                txtContactName.Text = result.ContactName;
                txtContactTitle.Text = result.ContactTitle;
                txtPhoneNumber.Text = result.PhoneNumber;
                txtEmail.Text = result.Email;
                txtCountry.Text = result.Country;
                txtCity.Text = result.City;
                txtAddress.Text = result.Addres;
            }
        }

        private void bttnCustomerUpdate_Click(object sender, EventArgs e)
        {
            if (cmbBoxCustomerSelect.SelectedValue is not null)
            {
                if (DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    UpdateCustomerDTO updateCustomerDTO = new UpdateCustomerDTO
                    {
                        Id = (Guid)cmbBoxCustomerSelect.SelectedValue,
                        CompanyName = txtCompanyName.Text,
                        ContactName = txtContactName.Text,
                        ContactTitle = txtContactTitle.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        Email = txtEmail.Text,
                        Country = txtCountry.Text,
                        City = txtCity.Text,
                        Addres = txtAddress.Text,
                        Invoice = radioBttnPerson.Checked ? Entities.Enums.InvoiceEnum.Bireysel : Entities.Enums.InvoiceEnum.Kurumsal
                    };

                    HttpResponseMessage response = _webApiService.httpClient.PutAsJsonAsync("customer/update", updateCustomerDTO).Result;

                    if (!response.IsSuccessStatusCode)
                    {
                        ResponseController.ErrorResponseController(response);
                        return;
                    }

                    CustomerList();
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
