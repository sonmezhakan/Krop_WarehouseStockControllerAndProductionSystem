using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.ProductNotifications;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krop.WinForms.Forms.ProductNotifications
{
    public partial class frmProductNotificationUpdate : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IServiceProvider _serviceProvider;
        private Panel panel;
        public Guid productNotificationId;

        public frmProductNotificationUpdate(IWebApiService webApiService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _webApiService = webApiService;
            panel = _serviceProvider.GetRequiredService<Panel>();
            employeeComboBoxControl.label1.Text = "Bildirim Yapılacak Çalışan :";
        }

        private void frmProductNotificationUpdate_Load(object sender, EventArgs e)
        {

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
                            SenderEmployeeId = panel.AppUserId,
                            SentEmployeeId = (Guid)employeeComboBoxControl.EmployeeComboBox.SelectedValue,
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
