using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Branches;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.Branches
{
    public partial class frmBranchUpdate : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmBranchUpdate(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmBranchUpdate_Load(object sender, EventArgs e)
        {
            txtPhoneNumber.MaxLength = 11;
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

                var result = await ResponseController.SuccessDataResponseController<GetBranchDTO>(response);

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

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.TextBoxInt32KeyPress(sender, e);
        }

        private async void bttnBranchUpdate_Click(object sender, EventArgs e)
        {
            if (branchComboBoxControl.BranchComboBox.SelectedValue is not null)
            {
                if (DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    UpdateBranchDTO updateBranchDTO = new UpdateBranchDTO
                    {
                        Id = (Guid)branchComboBoxControl.BranchComboBox.SelectedValue,
                        BranchName = txtBranchName.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        Email = txtEmail.Text,
                        Country = txtCountry.Text,
                        City = txtCity.Text,
                        Addres = txtAddress.Text
                    };
                    HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("branch/update", updateBranchDTO);

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }
                    await branchComboBoxControl.BranchList(_webApiService); ;
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
