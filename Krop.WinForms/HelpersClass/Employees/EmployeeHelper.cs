using Krop.Business.Features.Employees.Dtos;
using Krop.Common.Helpers.WebApiService;

namespace Krop.WinForms.HelpersClass.Employees
{
    public class EmployeeHelper : IEmployeeHelper
    {
        private readonly IWebApiService _webApiService;

        public EmployeeHelper(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }

        public IEnumerable<GetEmployeeListDTO> GetAllAsync()
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync("employee/GetAll").Result;
            if(!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataListResponseController<GetEmployeeListDTO>(response);

            return result.Data;
        }

        public IEnumerable<GetEmployeeComboBoxDTO> GetAllComboBoxAsync()
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync("employee/GetAllComboBox").Result;

            if(!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataListResponseController<GetEmployeeComboBoxDTO>(response);

            return result.Data;
        }

        public GetEmployeeDTO GetByEmployeeIdAsync(Guid Id)
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync($"employee/GetById/{Id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataResponseController<GetEmployeeDTO>(response);

            return result.Data;
        }

        public GetEmployeeCartDTO GetByEmployeeIdCartAsync(Guid Id)
        {
            HttpResponseMessage response = _webApiService.httpClient.GetAsync($"employee/GetByIdCart/{Id}").Result;

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return null;
            }

            var result = ResponseController.SuccessDataResponseController<GetEmployeeCartDTO>(response);

            return result.Data;
        }
    }
}
