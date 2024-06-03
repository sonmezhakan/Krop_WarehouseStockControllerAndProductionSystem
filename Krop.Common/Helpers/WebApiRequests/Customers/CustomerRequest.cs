using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Customers;
using System.Net.Http.Json;

namespace Krop.Common.Helpers.WebApiRequests.Customers
{
    public class CustomerRequest : ICustomerRequest
    {
        private readonly IWebApiService _webApiService;

        public CustomerRequest(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        public async Task<HttpResponseMessage> AddAsync(CreateCustomerDTO createCustomerDTO) => await _webApiService.httpClient.PostAsJsonAsync("customer/add", createCustomerDTO);
        public async Task<HttpResponseMessage> UpdateAsync(UpdateCustomerDTO updateCustomerDTO) => await _webApiService.httpClient.PutAsJsonAsync("customer/update", updateCustomerDTO);
        public async Task<HttpResponseMessage> DeleteAsync(Guid id) => await _webApiService.httpClient.DeleteAsync($"customer/delete/{id}");

        public async Task<HttpResponseMessage> GetAllAsync() => await _webApiService.httpClient.GetAsync("customer/getall");

        public async Task<HttpResponseMessage> GetAllComboBoxAsync() => await _webApiService.httpClient.GetAsync("customer/GetAllComboBox");

        public async Task<HttpResponseMessage> GetByIdAsync(Guid id) => await _webApiService.httpClient.GetAsync($"customer/GetById/{id}");
    }
}
