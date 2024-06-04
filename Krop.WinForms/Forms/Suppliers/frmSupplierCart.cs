using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Suppliers;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.Suppliers
{
    public partial class frmSupplierCart : Form
    {
       
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmSupplierCart(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmSupplierCart_Load(object sender, EventArgs e)
        {
           await SupplierList();
            txtPhoneNumber.MaxLength = 11;
            if (cmbBoxSupplierSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxSupplierSelect.SelectedValue = Id;
        }
        private async Task SupplierList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("supplier/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result =await ResponseController.SuccessDataResponseController<List<GetSupplierComboBoxDTO>>(response);

            cmbBoxSupplierSelect.DataSource = null;

            cmbBoxSupplierSelect.DisplayMember = "CompanyName";
            cmbBoxSupplierSelect.ValueMember = "Id";

            cmbBoxSupplierSelect.SelectedIndexChanged -= CmbBoxSupplierSelect_SelectedIndexChanged;
            cmbBoxSupplierSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxSupplierSelect.SelectedIndex = -1;
            cmbBoxSupplierSelect.SelectedIndexChanged += CmbBoxSupplierSelect_SelectedIndexChanged;
        }

        private async void CmbBoxSupplierSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxSupplierSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"supplier/GetById/{cmbBoxSupplierSelect.SelectedValue}");
                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                var result =await ResponseController.SuccessDataResponseController<GetSupplierDTO>(response);

                if(result is not null)
                {
                    txtContactName.Text = result.Data.ContactName;
                    txtContactTitle.Text = result.Data.ContactTitle;
                    txtPhoneNumber.Text = result.Data.PhoneNumber;
                    txtEmail.Text = result.Data.Email;
                    txtCountry.Text = result.Data.Country;
                    txtCity.Text = result.Data.City;
                    txtAddress.Text = result.Data.Addres;
                    txtWebSiteUrl.Text = result.Data.WebSite;
                }
            }
        }
    }
}
