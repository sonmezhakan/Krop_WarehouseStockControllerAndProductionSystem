using Krop.Business.Features.Departments.Dtos;
using Krop.Common.Helpers.WebApiService;
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

        private void bttnAdd_Click(object sender, EventArgs e)
        {
            CreateDepartmentDTO createDepartmentDTO = new CreateDepartmentDTO
            {
                DepartmentName = txtDepartmentName.Text,
                Description = txtDescription.Text
            };

            HttpResponseMessage response = _webApiService.httpClient.PostAsJsonAsync("department/add", createDepartmentDTO).Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }
        }
    }
}
