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
            await supplierComboBoxControl.SupplierList(_webApiService);
            supplierComboBoxControl.SupplierComboBox.SelectedIndexChanged += CmbBoxSupplierSelect_SelectedIndexChanged;
            supplierComboBoxControl.SupplierSelect(Id);
        }
        private async void CmbBoxSupplierSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (supplierComboBoxControl.SupplierComboBox.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"supplier/GetById/{(Guid)supplierComboBoxControl.SupplierComboBox.SelectedValue}");
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
