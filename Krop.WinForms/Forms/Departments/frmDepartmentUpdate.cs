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
            await DepartmentList();
            if(cmbBoxDepartmentSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxDepartmentSelect.SelectedValue = Id;
        }
        private  async Task DepartmentList()
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

        private  async void CmbBoxDepartmentSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if(cmbBoxDepartmentSelect.SelectedValue is not null)
            {
                HttpResponseMessage response =await _webApiService.httpClient.GetAsync($"department/GetById/{cmbBoxDepartmentSelect.SelectedValue}");
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
            if (cmbBoxDepartmentSelect.SelectedValue is not null)
            {
                if(DialogResultHelper.UpdateDialogResult() == DialogResult.Yes)
                {
                    UpdateDepartmentDTO updateDepartmentDTO = new UpdateDepartmentDTO
                    {
                        Id = (Guid)cmbBoxDepartmentSelect.SelectedValue,
                        DepartmentName = txtDepartmentName.Text,
                        Description = txtDescription.Text
                    };

                    HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("department/Update", updateDepartmentDTO);

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
