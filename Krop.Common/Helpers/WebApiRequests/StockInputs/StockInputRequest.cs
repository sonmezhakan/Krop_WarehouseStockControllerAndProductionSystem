using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.StockInputs;
using System.Net.Http.Json;

namespace Krop.Common.Helpers.WebApiRequests.StockInputs
{
    public class StockInputRequest : IStockInputRequest
    {
        private readonly IWebApiService _webApiService;

        public StockInputRequest(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        public async Task<HttpResponseMessage> AddAsync(CreateStockInputDTO createStockInputDTO) => await _webApiService.httpClient.PostAsJsonAsync("StockInput/add", createStockInputDTO);

        public async Task<HttpResponseMessage> DeleteAsync(Guid id,Guid appUserId) => await _webApiService.httpClient.DeleteAsync($"StockInput/Delete/{id}/{appUserId}");

        public async Task<HttpResponseMessage> GetAllAsync(Guid appUserId) => await _webApiService.httpClient.GetAsync($"stockInput/getall/{appUserId}");

        public Task<HttpResponseMessage> GetAllComboBoxAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> GetByIdAsync(Guid id) => await _webApiService.httpClient.GetAsync($"StockInput/GetById/{id}");

        public async Task<HttpResponseMessage> UpdateAsync(UpdateStockInputDTO updateStockInputDTO) => await _webApiService.httpClient.PutAsJsonAsync("StockInput/Update", updateStockInputDTO);
    }
}
