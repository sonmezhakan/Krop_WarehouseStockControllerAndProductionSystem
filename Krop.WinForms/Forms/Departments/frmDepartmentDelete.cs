using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Departments;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Forms.Departments
{
    public partial class frmDepartmentDelete : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmDepartmentDelete(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmDepartmentDelete_Load(object sender, EventArgs e)
        {
           await DepartmentList();
            if (cmbBoxDepartmentSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxDepartmentSelect.SelectedValue = Id;
        }
        private async Task DepartmentList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("department/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result =await ResponseController.SuccessDataResponseController<List<GetDepartmentComboBoxDTO>>(response);

            cmbBoxDepartmentSelect.DataSource = null;

            cmbBoxDepartmentSelect.DisplayMember = "DepartmentName";
            cmbBoxDepartmentSelect.ValueMember = "Id";

            cmbBoxDepartmentSelect.SelectedIndexChanged -= CmbBoxDepartmentSelect_SelectedIndexChanged;
            cmbBoxDepartmentSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxDepartmentSelect.SelectedIndex = -1;
            cmbBoxDepartmentSelect.SelectedIndexChanged += CmbBoxDepartmentSelect_SelectedIndexChanged;
        }

        private void CmbBoxDepartmentSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {

        }

        private async void bttnDelete_Click(object sender, EventArgs e)
        {
            if (cmbBoxDepartmentSelect.SelectedValue is not null)
            {
                if (DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"department/delete/{cmbBoxDepartmentSelect.SelectedValue}");

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                   await DepartmentList();
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
