using Krop.Common.Helpers.WebApiService;
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
            await departmentComboBoxControl.DepartmentList(_webApiService);
        }
        private async void bttnDelete_Click(object sender, EventArgs e)
        {
            if (departmentComboBoxControl.DepartmentComboBox.SelectedValue is not null)
            {
                if (DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"department/delete/{(Guid)departmentComboBoxControl.DepartmentComboBox.SelectedValue}");

                    if (!response.IsSuccessStatusCode)
                    {
                        await ResponseController.ErrorResponseController(response);
                        return;
                    }

                    await departmentComboBoxControl.DepartmentList(_webApiService);
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void departmentComboBoxControl_Load(object sender, EventArgs e)
        {

        }
    }
}
