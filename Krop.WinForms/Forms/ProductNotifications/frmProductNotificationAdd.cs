using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.ProductNotifications;
using Krop.WinForms.HelpersClass;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.ProductNotifications
{
    public partial class frmProductNotificationAdd : Form
    {
        private readonly IWebApiService _webApiService;
        public frmProductNotificationAdd(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
            employeeComboBoxControl.label1.Text = "Bildirim Yapılacak Çalışan :";
        }

        private async void frmProductNotificationAdd_Load(object sender, EventArgs e)
        {
            await employeeComboBoxControl.EmployeeList(_webApiService);
            await branchComboBoxControl.BranchList(_webApiService);
            await productComboBoxControl.ProductList(_webApiService);
            productComboBoxControl.ProductNameComboBox.SelectedIndexChanged += ProductNameComboBox_SelectedIndexChanged;
            productComboBoxControl.ProductCodeComboBox.SelectedIndexChanged += ProductCodeComboBox_SelectedIndexChanged;
        }
        private void ProductCodeComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (productComboBoxControl.ProductCodeComboBox.SelectedValue is not null && productComboBoxControl.ProductNameComboBox.DataSource is not null)
            {
                productComboBoxControl.ProductNameComboBox.SelectedValue = productComboBoxControl.ProductCodeComboBox.SelectedValue;
            }
        }

        private void ProductNameComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (productComboBoxControl.ProductNameComboBox.SelectedValue is not null && productComboBoxControl.ProductCodeComboBox.DataSource is not null)
            {
                productComboBoxControl.ProductCodeComboBox.SelectedValue = productComboBoxControl.ProductNameComboBox.SelectedValue;
            }
        }
        private async void bttnAdd_Click(object sender, EventArgs e)
        {
            if((Guid)employeeComboBoxControl.EmployeeComboBox.SelectedValue != Guid.Empty &&
                (Guid)productComboBoxControl.ProductNameComboBox.SelectedValue != Guid.Empty &&
                (Guid) productComboBoxControl.ProductCodeComboBox.SelectedValue != Guid.Empty &&
                (Guid) branchComboBoxControl.BranchComboBox.SelectedValue != Guid.Empty)
            {
                HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("productNotification/Add", new CreateProductNotificationDTO
                {
                    BranchId = (Guid)branchComboBoxControl.BranchComboBox.SelectedValue,
                    ProductId = (Guid)productComboBoxControl.ProductNameComboBox.SelectedValue,
                    SenderAppUserId = Panel._appUserId,
                    SentAppUserId = (Guid)employeeComboBoxControl.EmployeeComboBox.SelectedValue,
                    Description = txtDescription.Text
                });

                if(!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçin Yapınız!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
