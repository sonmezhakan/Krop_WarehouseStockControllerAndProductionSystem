using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Employees;
using System.Net.Http.Json;

namespace Krop.Common.Helpers.WebApiRequests.Employees
{
    public class EmployeeRequest : IEmployeeRequest
    {
        private readonly IWebApiService _webApiService;

        public EmployeeRequest(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        public async Task<HttpResponseMessage> AddAsync(CreateEmployeeDTO createEmployeeDTO) => await _webApiService.httpClient.PostAsJsonAsync("employee/add", createEmployeeDTO);
        public async Task<HttpResponseMessage> UpdateAsync(UpdateEmployeeDTO updateEmployeeDTO) => await _webApiService.httpClient.PutAsJsonAsync("employee/update", updateEmployeeDTO);
        public Task<HttpResponseMessage> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> GetAllAsync() => await _webApiService.httpClient.GetAsync("employee/GetAll");

        public async Task<HttpResponseMessage> GetAllComboBoxAsync() => await _webApiService.httpClient.GetAsync("employee/GetAllComboBox");

        public async Task<HttpResponseMessage> GetByIdAsync(Guid id) => await _webApiService.httpClient.GetAsync($"employee/GetById/{id}");

        public async Task<HttpResponseMessage> GetByIdCartAsync(Guid id) => await _webApiService.httpClient.GetAsync($"employee/GetByIdCart/{id}");
    }
}
