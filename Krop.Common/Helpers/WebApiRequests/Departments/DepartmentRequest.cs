using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Departments;
using System.Net.Http.Json;

namespace Krop.Common.Helpers.WebApiRequests.Departments
{
    public class DepartmentRequest:IDepartmentRequest
    {
        private readonly IWebApiService _webApiService;

        public DepartmentRequest(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }

        public async Task<HttpResponseMessage> AddAsync(CreateDepartmentDTO createDepartmentDTO) => await _webApiService.httpClient.PostAsJsonAsync("department/add", createDepartmentDTO);
        public async Task<HttpResponseMessage> UpdateAsync(UpdateDepartmentDTO updateDepartmentDTO) => await _webApiService.httpClient.PutAsJsonAsync("department/Update", updateDepartmentDTO);
        public async Task<HttpResponseMessage> DeleteAsync(Guid id) => await _webApiService.httpClient.DeleteAsync($"department/delete/{id}");

        public async Task<HttpResponseMessage> GetAllAsync() => await _webApiService.httpClient.GetAsync("department/getall");

        public async Task<HttpResponseMessage> GetAllComboBoxAsync() => await _webApiService.httpClient.GetAsync("department/GetAllComboBox");

        public async Task<HttpResponseMessage> GetByIdAsync(Guid id) => await _webApiService.httpClient.GetAsync($"department/GetById/{id}");
    }
}
