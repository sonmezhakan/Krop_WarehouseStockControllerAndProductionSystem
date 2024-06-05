using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Departments;
using Krop.WinForms.HelpersClass;
using System.ComponentModel;

namespace Krop.WinForms.UserControllers.Departments
{
    public partial class DepartmentListControl : UserControl
    {
        public BindingList<GetDepartmentDTO> _originalData;
        public BindingList<GetDepartmentDTO> _filteredData;
        public DepartmentListControl()
        {
            InitializeComponent();
        }
        public void DgwDepartmentListSettings()
        {
            dgwDepartmentList.Columns[0].HeaderText = "Id";
            dgwDepartmentList.Columns[1].HeaderText = "Departman Adı";
            dgwDepartmentList.Columns[2].HeaderText = "Açıklama";

            dgwDepartmentList.Columns[0].Visible = false;
        }
        public async Task DepartmentList(IWebApiService webApiService)
        {
            HttpResponseMessage response = await webApiService.httpClient.GetAsync("department/getall");
            if (!response.IsSuccessStatusCode)
            {
                await ResponseController.ErrorResponseController(response);
                return;
            }

            var result = await ResponseController.SuccessDataResponseController<List<GetDepartmentDTO>>(response);

            if (result is not null)
            {
                _originalData = new BindingList<GetDepartmentDTO>(result.Data);
                _filteredData = new BindingList<GetDepartmentDTO>(_originalData.ToList());

                dgwDepartmentList.DataSource = _filteredData;

                DgwDepartmentListSettings();
            }
        }
        public DataGridView DataGridViewDepartmentList
        {
            get { return dgwDepartmentList; }
        }
    }
}