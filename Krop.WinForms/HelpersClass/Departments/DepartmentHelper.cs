using Krop.Business.Features.Departments.Dtos;
using Krop.Common.Helpers.WebApiService;

namespace Krop.WinForms.HelpersClass.Departments
{
    public class DepartmentHelper : IDepartmentHelper
    {
        private readonly IWebApiService _webApiService;

        public DepartmentHelper(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        public List<GetDepartmentDTO> GetAllAsync()
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync("department/getall").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataListResponseController<GetDepartmentDTO>(response);

            return result.Data;
        }

        public List<GetDepartmentComboBoxDTO> GetAllComboBoxAsync()
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync("department/GetAllComboBox").Result;

            if(!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataListResponseController<GetDepartmentComboBoxDTO>(response);

            return result.Data;
        }

        public GetDepartmentDTO GetByDepartmentId(Guid Id)
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync($"department/GetById/{Id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataResponseController<GetDepartmentDTO>(response);

            return result.Data;
        }
    }
}
