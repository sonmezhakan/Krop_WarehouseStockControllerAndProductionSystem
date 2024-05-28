using Krop.Business.Features.Suppliers.Dtos;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Utilits.Result;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using Krop.WinForms.HelpersClass.SupplierHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Suppliers
{
    public partial class frmSupplierUpdate : Form
    {
        private readonly ISupplierHelper _supplierHelper;
        private readonly IWebApiService _webApiService;
        public Guid Id;

        public frmSupplierUpdate(ISupplierHelper supplierHelper, IWebApiService webApiService)
        {
            InitializeComponent();
            _supplierHelper = supplierHelper;
            _webApiService = webApiService;
        }

        private void frmSupplierUpdate_Load(object sender, EventArgs e)
        {
            SupplierList();
            txtPhoneNumber.MaxLength = 11;
            if (cmbBoxSupplierSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxSupplierSelect.SelectedValue = Id;
        }
        private void SupplierList()
        {
            List<GetSupplierComboBoxDTO> result = _supplierHelper.GetAllComboBoxAsync();
            if (result is null)
                return;

            cmbBoxSupplierSelect.DataSource = null;

            cmbBoxSupplierSelect.DisplayMember = "CompanyName";
            cmbBoxSupplierSelect.ValueMember = "Id";

            cmbBoxSupplierSelect.SelectedIndexChanged -= CmbBoxSupplierSelect_SelectedIndexChanged;
            cmbBoxSupplierSelect.DataSource = result;
            cmbBoxSupplierSelect.SelectedIndex = -1;
            cmbBoxSupplierSelect.SelectedIndexChanged += CmbBoxSupplierSelect_SelectedIndexChanged;
        }

        private void CmbBoxSupplierSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxSupplierSelect.SelectedValue is not null)
            {
                var result = _supplierHelper.GetBySupplierIdAsync((Guid)cmbBoxSupplierSelect.SelectedValue);
                if (result is null)
                    return;

                txtCompanyName.Text = result.CompanyName;
                txtContactName.Text = result.ContactName;
                txtContactTitle.Text = result.ContactTitle;
                txtPhoneNumber.Text = result.PhoneNumber;
                txtEmail.Text = result.Email;
                txtCountry.Text = result.Country;
                txtCity.Text = result.City;
                txtAddress.Text = result.Addres;
                txtWebSiteUrl.Text = result.WebSite;
            }
        }
        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }
        private async void bttnSupplierUpdate_Click(object sender, EventArgs e)
        {
            if (cmbBoxSupplierSelect.SelectedValue is not null)
            {
                if (DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    UpdateSupplierDTO updateSupplierDTO = new UpdateSupplierDTO
                    {
                        Id = (Guid)cmbBoxSupplierSelect.SelectedValue,
                        CompanyName = txtCompanyName.Text,
                        ContactName = txtContactName.Text,
                        ContactTitle = txtContactTitle.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        Email = txtEmail.Text,
                        Country = txtCountry.Text,
                        City = txtCity.Text,
                        Addres = txtAddress.Text,
                        WebSite = txtWebSiteUrl.Text
                    };

                    HttpResponseMessage response = _webApiService.httpClient.PutAsJsonAsync("supplier/update", updateSupplierDTO).Result;

                    if (!response.IsSuccessStatusCode)
                    {
                        ResponseController.ErrorResponseController(response);
                        return;
                    }

                    SupplierList();
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçin Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
