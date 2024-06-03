using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Products;
using Krop.DTO.Dtos.Suppliers;
using System.Net.Http.Json;

namespace Krop.Common.Helpers.WebApiRequests.Suppliers
{
    public class SupplierRequest : ISupplierRequest
    {
        private readonly IWebApiService _webApiService;

        public SupplierRequest(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        public async Task<HttpResponseMessage> AddAsync(CreateSupplierDTO createSupplierDTO) => await _webApiService.httpClient.PostAsJsonAsync("supplier/Add", createSupplierDTO);
        public async Task<HttpResponseMessage> UpdateAsync(UpdateSupplierDTO updateSupplierDTO) => await _webApiService.httpClient.PutAsJsonAsync("supplier/update", updateSupplierDTO);
        public async Task<HttpResponseMessage> DeleteAsync(Guid id) => await _webApiService.httpClient.DeleteAsync($"supplier/delete/{id}");

        public async Task<HttpResponseMessage> GetAllAsync() => await _webApiService.httpClient.GetAsync("supplier/GetAll");

        public async Task<HttpResponseMessage> GetAllComboBoxAsync() => await _webApiService.httpClient.GetAsync("supplier/GetAllComboBox");

        public async Task<HttpResponseMessage> GetByIdAsync(Guid id) => await _webApiService.httpClient.GetAsync($"supplier/GetById/{id}");
       
    }
}
