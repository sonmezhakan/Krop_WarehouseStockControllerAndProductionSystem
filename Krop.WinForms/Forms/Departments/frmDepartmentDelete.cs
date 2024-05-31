using Krop.Common.Helpers.WebApiService;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.Departments;
using Krop.WinForms.HelpersClass.FromObjectHelpers;

namespace Krop.WinForms.Forms.Departments
{
    public partial class frmDepartmentDelete : Form
    {
        private readonly IWebApiService _webApiService;
        private readonly IDepartmentHelper _departmentHelper;
        public Guid Id;

        public frmDepartmentDelete(IWebApiService webApiService, IDepartmentHelper departmentHelper)
        {
            InitializeComponent();
            _webApiService = webApiService;
            _departmentHelper = departmentHelper;
        }

        private void frmDepartmentDelete_Load(object sender, EventArgs e)
        {
            DepartmentList();
            if (cmbBoxDepartmentSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxDepartmentSelect.SelectedValue = Id;
        }
        private void DepartmentList()
        {
            var result = _departmentHelper.GetAllComboBoxAsync();
            if (result is null)
                return;

            cmbBoxDepartmentSelect.DataSource = null;

            cmbBoxDepartmentSelect.DisplayMember = "DepartmentName";
            cmbBoxDepartmentSelect.ValueMember = "Id";

            cmbBoxDepartmentSelect.SelectedIndexChanged -= CmbBoxDepartmentSelect_SelectedIndexChanged;
            cmbBoxDepartmentSelect.DataSource = result;
            cmbBoxDepartmentSelect.SelectedIndex = -1;
            cmbBoxDepartmentSelect.SelectedIndexChanged += CmbBoxDepartmentSelect_SelectedIndexChanged;
        }

        private void CmbBoxDepartmentSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {

        }

        private void bttnDelete_Click(object sender, EventArgs e)
        {
            if (cmbBoxDepartmentSelect.SelectedValue is not null)
            {
                if (DialogResultHelper.DeleteDialogResult() == DialogResult.Yes)
                {
                    HttpResponseMessage response = _webApiService.httpClient.DeleteAsync($"department/delete/{cmbBoxDepartmentSelect.SelectedValue}").Result;

                    if (!response.IsSuccessStatusCode)
                    {
                        ResponseController.ErrorResponseController(response);
                        return;
                    }

                    DepartmentList();
                }
            }
            else
            {
                MessageBox.Show("Doğru Seçim Yapınız!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
