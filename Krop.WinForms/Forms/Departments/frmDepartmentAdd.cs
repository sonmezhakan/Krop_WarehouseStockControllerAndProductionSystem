using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Departments;
using Krop.WinForms.HelpersClass;
using System.Net.Http.Json;

namespace Krop.WinForms.Forms.Departments
{
    public partial class frmDepartmentAdd : Form
    {
        private readonly IWebApiService _webApiService;

        public frmDepartmentAdd(IWebApiService webApiService)
        {
            InitializeComponent();
            _webApiService = webApiService;
        }

        private void frmDepartmentAdd_Load(object sender, EventArgs e)
        {

        }

        private async void bttnAdd_Click(object sender, EventArgs e)
        {
            CreateDepartmentDTO createDepartmentDTO = new CreateDepartmentDTO
            {
                DepartmentName = txtDepartmentName.Text,
                Description = txtDescription.Text
            };

            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("department/add", createDepartmentDTO);

            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }
        }
    }
}
