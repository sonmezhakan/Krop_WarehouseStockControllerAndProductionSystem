using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.Products;
using System.Net.Http.Json;

namespace Krop.Common.Helpers.WebApiRequests.Products
{
    public class ProductRequest : IProductRequest
    {
        private readonly IWebApiService _webApiService;

        public ProductRequest(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        public async Task<HttpResponseMessage> AddAsync(CreateProductDTO createProductDTO) => await _webApiService.httpClient.PostAsJsonAsync("product/Add", createProductDTO);
        public async Task<HttpResponseMessage> UpdateAsync(UpdateProductDTO updateProductDTO) => await _webApiService.httpClient.PutAsJsonAsync("product/update", updateProductDTO);
        public async Task<HttpResponseMessage> DeleteAsync(Guid id) => await _webApiService.httpClient.DeleteAsync($"product/delete/{id}");

        public async Task<HttpResponseMessage> GetAllAsync() => await _webApiService.httpClient.GetAsync("product/GetAll");

        public async Task<HttpResponseMessage> GetAllComboBoxAsync() => await _webApiService.httpClient.GetAsync("product/GetAllComboBox");

        public async Task<HttpResponseMessage> GetByIdAsync(Guid id) => await _webApiService.httpClient.GetAsync($"product/GetById/{id}");

        public async Task<HttpResponseMessage> GetByIdCartAsync(Guid id) => await _webApiService.httpClient.GetAsync($"product/GetByIdCart/{id}");
    }
}
