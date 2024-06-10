using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.ProductNotifications;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.ProductNotifications
{
    public partial class frmProductNotificationUpdate : Form
    {
        private readonly IWebApiService _webApiService;
        public Guid appUserId;
        public Guid productNotificationId;

        public frmProductNotificationUpdate(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
            employeeComboBoxControl.label1.Text = "Bildirim Yapılacak Çalışan :";
        }

        private async void frmProductNotificationUpdate_Load(object sender, EventArgs e)
        {
            await employeeComboBoxControl.EmployeeList(_webApiService);
            await branchComboBoxControl.BranchList(_webApiService);
            await productComboBoxControl.ProductList(_webApiService);
            productComboBoxControl.ProductNameComboBox.SelectedIndexChanged += ProductNameComboBox_SelectedIndexChanged;
            productComboBoxControl.ProductCodeComboBox.SelectedIndexChanged += ProductCodeComboBox_SelectedIndexChanged;
            await GetProductNotification();
        }

        private void ProductCodeComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if(productComboBoxControl.ProductCodeComboBox.SelectedValue is not null && productComboBoxControl.ProductNameComboBox.DataSource is not null)
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

        private async Task GetProductNotification()
        {
            if(productNotificationId != Guid.Empty)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"productNotification/GetById/{productNotificationId}");
                if(!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }    

                var result = await ResponseController.SuccessDataResponseController<GetProductNotificationDTO>(response);

                employeeComboBoxControl.EmployeeComboBox.SelectedValue = result.Data.SentAppUserId;
                branchComboBoxControl.BranchComboBox.SelectedValue = result.Data.BranchId;
                productComboBoxControl.ProductNameComboBox.SelectedValue = result.Data.ProductId;
                txtDescription.Text = result.Data.Description;
            }
            else
            {
                return;
            }
        }

        private async void bttnUpdate_Click(object sender, EventArgs e)
        {
            if (productNotificationId != Guid.Empty)
            {
                if ((Guid)employeeComboBoxControl.EmployeeComboBox.SelectedValue != Guid.Empty &&
                (Guid)productComboBoxControl.ProductNameComboBox.SelectedValue != Guid.Empty &&
                (Guid)productComboBoxControl.ProductCodeComboBox.SelectedValue != Guid.Empty &&
                (Guid)branchComboBoxControl.BranchComboBox.SelectedValue != Guid.Empty)
                {
                   if(DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                    {
                        HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("productNotification/Update", new UpdateProductNotificationDTO
                        {
                            Id = productNotificationId,
                            BranchId = (Guid)branchComboBoxControl.BranchComboBox.SelectedValue,
                            ProductId = (Guid)productComboBoxControl.ProductNameComboBox.SelectedValue,
                            SenderAppUserId = appUserId,
                            SentAppUserId = (Guid)employeeComboBoxControl.EmployeeComboBox.SelectedValue,
                            Description = txtDescription.Text
                        });
                        if (!response.IsSuccessStatusCode)
                        {
                            await ResponseController.ErrorResponseController(response);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Doğru Seçim Yapınız!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Güncellenecek Bildirimi Listeden Seçerek Güncelleme İşlemi Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
