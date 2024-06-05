using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Branches;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Forms.Branches
{
    public partial class frmBranchCart : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmBranchCart(IWebApiService webApiService)
        {
            InitializeComponent();
            txtPhoneNumber.MaxLength = 11;
            _webApiService = webApiService;
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private async void frmBranchCart_Load(object sender, EventArgs e)
        {
            await branchComboBoxControl.BranchList(_webApiService);
            branchComboBoxControl.BranchComboBox.SelectedIndexChanged += CmbBoxBranchSelect_SelectedIndexChanged;
            branchComboBoxControl.BranchSelect(Id);
        }

        private async void CmbBoxBranchSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (branchComboBoxControl.BranchComboBox.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"branch/GetById/{(Guid)branchComboBoxControl.BranchComboBox.SelectedValue}");
                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                var result =await ResponseController.SuccessDataResponseController<GetBranchDTO>(response);

                if (result is not null)
                {
                    txtPhoneNumber.Text = result.Data.PhoneNumber;
                    txtEmail.Text = result.Data.Email;
                    txtCountry.Text = result.Data.Country;
                    txtCity.Text = result.Data.City;
                    txtAddress.Text = result.Data.Addres;
                }
            }
        }
    }
}
