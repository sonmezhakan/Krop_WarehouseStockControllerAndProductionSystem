using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.ProductReceipts;
using System.Net.Http.Json;

namespace Krop.Common.Helpers.WebApiRequests.ProductReceipts
{
    public class ProductReceiptRequest:IProductReceiptRequest
    {
        private readonly IWebApiService _webApiService;

        public ProductReceiptRequest(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }

        public async Task<HttpResponseMessage> AddAsync(CreateProductReceiptDTO createProductReceiptDTO) => await _webApiService.httpClient.PostAsJsonAsync("productReceipt/Add", createProductReceiptDTO);

        public async Task<HttpResponseMessage> DeleteAsync(Guid produceProductId, Guid productId) => await _webApiService.httpClient.DeleteAsync($"productReceipt/Delete/{produceProductId}/{productId}");

        public async Task<HttpResponseMessage> GetAllAsync(Guid produceProductId) => await _webApiService.httpClient.GetAsync($"productReceipt/GetAll/{produceProductId}");

        public Task<HttpResponseMessage> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> UpdateAsync(UpdateProductReceiptDTO updateProductReceiptDTO) => await _webApiService.httpClient.PutAsJsonAsync("productReceipt/Update", updateProductReceiptDTO);
    }
}
