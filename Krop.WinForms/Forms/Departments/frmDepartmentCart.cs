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
            await departmentComboBoxControl.DepartmentList(_webApiService);
            departmentComboBoxControl.DepartmentComboBox.SelectedIndexChanged += CmbBoxDepartmentSelect_SelectedIndexChanged;
            departmentComboBoxControl.DepartmentSelect(Id);
        }
        

        private async void CmbBoxDepartmentSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (departmentComboBoxControl.DepartmentComboBox.SelectedValue is not null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"department/GetById/{(Guid)departmentComboBoxControl.DepartmentComboBox.SelectedValue}");
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
