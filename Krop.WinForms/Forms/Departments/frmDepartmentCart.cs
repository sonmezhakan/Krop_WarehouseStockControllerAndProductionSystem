using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Departments;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.Forms.Departments
{
    public partial class frmDepartmentCart : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmDepartmentCart(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmDepartmentCart_Load(object sender, EventArgs e)
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

            var result = await ResponseController.SuccessDataResponseController<List<GetDepartmentComboBoxDTO>>(response);

            cmbBoxDepartmentSelect.DataSource = null;

            cmbBoxDepartmentSelect.DisplayMember = "DepartmentName";
            cmbBoxDepartmentSelect.ValueMember = "Id";

            cmbBoxDepartmentSelect.SelectedIndexChanged -= CmbBoxDepartmentSelect_SelectedIndexChanged;
            cmbBoxDepartmentSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxDepartmentSelect.SelectedIndex = -1;
            cmbBoxDepartmentSelect.SelectedIndexChanged += CmbBoxDepartmentSelect_SelectedIndexChanged;
        }

        private async void CmbBoxDepartmentSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxDepartmentSelect.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"department/GetById/{cmbBoxDepartmentSelect.SelectedValue}");
                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                var result = await ResponseController.SuccessDataResponseController<GetDepartmentDTO>(response);

                if (result is not null)
                {
                    txtDescription.Text = result.Data.Description;
                }
            }
        }
    }
}
