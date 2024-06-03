using Krop.Common.Helpers.WebApiRequests.Departments;
using Krop.DTO.Dtos.Departments;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.Forms.Departments
{
    public partial class frmDepartmentAdd : Form
    {
        private readonly IDepartmentRequest _departmentRequest;

        public frmDepartmentAdd(IDepartmentRequest departmentRequest)
        {
            InitializeComponent();
            _departmentRequest = departmentRequest;
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

            HttpResponseMessage response = await _departmentRequest.AddAsync(createDepartmentDTO);

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }
        }
    }
}
