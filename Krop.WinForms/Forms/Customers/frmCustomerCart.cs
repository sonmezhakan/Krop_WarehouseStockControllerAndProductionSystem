﻿using Krop.Business.Features.Customers.Dtos;
using Krop.WinForms.HelpersClass.CustomerHelpers;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Customers
{
    public partial class frmCustomerCart : Form
    {
        private readonly ICustomerHelper _customerHelper;
        public Guid Id;

        public frmCustomerCart(ICustomerHelper customerHelper)
        {
            InitializeComponent();
            _customerHelper = customerHelper;
        }

        private void frmCustomerCart_Load(object sender, EventArgs e)
        {
            CustomerList();
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