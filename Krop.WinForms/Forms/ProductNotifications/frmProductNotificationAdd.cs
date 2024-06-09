using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.ProductNotifications;
using Krop.WinForms.HelpersClass;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.ProductNotifications
{
    public partial class frmProductNotificationAdd : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IWebApiService _webApiService;
        private Panel panel;
        public frmProductNotificationAdd(IServiceProvider serviceProvider, IWebApiService webApiService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _webApiService = webApiService;
            panel = _serviceProvider.GetRequiredService<Panel>();
            employeeComboBoxControl.label1.Text = "Bildirim Yapılacak Çalışan :";
        }

        private async void frmProductNotificationAdd_Load(object sender, EventArgs e)
        {
            await employeeComboBoxControl.EmployeeList(_webApiService);
            await branchComboBoxControl.BranchList(_webApiService);
            await productComboBoxControl.ProductList(_webApiService);
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
                    SenderEmployeeId = panel.AppUserId,
                    SentEmployeeId = (Guid)employeeComboBoxControl.EmployeeComboBox.SelectedValue,
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
