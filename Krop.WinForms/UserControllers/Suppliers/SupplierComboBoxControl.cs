using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Suppliers;
using Krop.WinForms.HelpersClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krop.WinForms.UserControllers.Suppliers
{
    public partial class SupplierComboBoxControl : UserControl
    {
        public SupplierComboBoxControl()
        {
            InitializeComponent();
        }

        private void SupplierComboBoxControl_Load(object sender, EventArgs e)
        {

        }
        public async Task SupplierList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("supplier/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetSupplierComboBoxDTO>>(response);

            cmbBoxSupplierSelect.DataSource = null;

            cmbBoxSupplierSelect.DisplayMember = "CompanyName";
            cmbBoxSupplierSelect.ValueMember = "Id";

            cmbBoxSupplierSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxSupplierSelect.SelectedIndex = -1;
        }
        public void SupplierSelect(Guid id)
        {
            if (cmbBoxSupplierSelect.DataSource != null && id != Guid.Empty)
                cmbBoxSupplierSelect.SelectedValue = id;
        }
        public ComboBox SupplierComboBox
        {
            get { return cmbBoxSupplierSelect; }
        }
    }
}
