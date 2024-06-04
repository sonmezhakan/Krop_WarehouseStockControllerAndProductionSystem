using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Employees;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.Forms.Employees
{
    public partial class frmEmployeeCart : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmEmployeeCart(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private async void frmEmployeeCart_Load(object sender, EventArgs e)
        {
           await EmployeeList();
            if (cmbBoxAppUserSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxAppUserSelect.SelectedValue = Id;
        }
        private async Task EmployeeList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("employee/GetAllComboBox");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result =await ResponseController.SuccessDataResponseController<List<GetEmployeeComboBoxDTO>>(response);

            cmbBoxAppUserSelect.DataSource = null;
            cmbBoxAppUserSelect.DisplayMember = "UserName";
            cmbBoxAppUserSelect.ValueMember = "AppUserId";

            cmbBoxAppUserSelect.SelectedIndexChanged -= CmbBoxAppUserSelect_SelectedIndexChanged;
            cmbBoxAppUserSelect.DataSource = result is not null ? result.Data : null;
            cmbBoxAppUserSelect.SelectedValue = -1;
            cmbBoxAppUserSelect.SelectedIndexChanged += CmbBoxAppUserSelect_SelectedIndexChanged;
        }

        private async void CmbBoxAppUserSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbBoxAppUserSelect.SelectedValue is not null)
            {
                HttpResponseMessage response =await _webApiService.httpClient.GetAsync($"employee/GetById/{cmbBoxAppUserSelect.SelectedValue}");
                if (!response.IsSuccessStatusCode)
                {
                    await ResponseController.ErrorResponseController(response);
                    return;
                }

                var result =await ResponseController.SuccessDataResponseController<GetEmployeeCartDTO>(response);

                if(result is not null)
                {
                    txtDepartmentName.Text = result.Data.DepartmentName;
                    txtBranchName.Text = result.Data.BranchName;
                    txtSalary.Text = result.Data.Salary.ToString() + " ₺";
                    dateTimePickerStart.Value = result.Data.StartDateOfWork;
                    dateTimePickerEnd.Value = result.Data.EndDateOfWork == null || result.Data.EndDateOfWork == DateTime.MinValue ? DateTime.Now : result.Data.EndDateOfWork;
                    if (result.Data.WorkingStatu)
                        radioButtonActive.Checked = true;
                    else
                        radioButtonPassive.Checked = true;
                }
            }
        }
    }
}
