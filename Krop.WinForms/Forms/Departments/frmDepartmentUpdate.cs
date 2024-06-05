using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Departments;
using Krop.WinForms.HelpersClass;
using Krop.WinForms.HelpersClass.FromObjectHelpers;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.Departments
{
    public partial class frmDepartmentUpdate : Form
    {
        public Guid Id;
        private readonly IWebApiService _webApiService;

        public frmDepartmentUpdate(IWebApiService webApiService )
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private  async void frmDepartmentUpdate_Load(object sender, EventArgs e)
        {
            await departmentComboBoxControl.DepartmentList(_webApiService);
            departmentComboBoxControl.DepartmentComboBox.SelectedIndexChanged += CmbBoxDepartmentSelect_SelectedIndexChanged;
            departmentComboBoxControl.DepartmentSelect(Id);
        }
                private  async void CmbBoxDepartmentSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if(departmentComboBoxControl.DepartmentComboBox.SelectedValue is not null)
            {
                HttpResponseMessage response =await _webApiService.httpClient.GetAsync($"department/GetById/{(Guid)departmentComboBoxControl.DepartmentComboBox.SelectedValue}");
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

        private async void bttnUpdate_Click(object sender, EventArgs e)
        {
            if (departmentComboBoxControl.DepartmentComboBox.SelectedValue is not null)
            {
                if(DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    UpdateDepartmentDTO updateDepartmentDTO = new UpdateDepartmentDTO
                    {
                        Id = (Guid)departmentComboBoxControl.DepartmentComboBox.SelectedValue,
                        DepartmentName = txtDepartmentName.Text,
                        Description = txtDescription.Text
                    };

                    HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("department/Update", updateDepartmentDTO);

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
    }
}
