using Krop.Common.Helpers.WebApiService;
using Krop.DTO.Dtos.StockTransfers;
using System.Net.Http.Json;

namespace Krop.Common.Helpers.WebApiRequests.StockTransfers
{
    public class StockTransferRequest : IStockTransferRequest
    {
        private readonly IWebApiService _webApiService;

        public StockTransferRequest(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        public async Task<HttpResponseMessage> AddAsync(CreateStockTransferDTO createStockTransferDTO) => await _webApiService.httpClient.PostAsJsonAsync("stockTransfer/Add", createStockTransferDTO);

        public async Task<HttpResponseMessage> UpdateAsync(UpdateStockTransferDTO updateStockTransferDTO) => await _webApiService.httpClient.PutAsJsonAsync("stockTransfer/Update", updateStockTransferDTO);
        public async Task<HttpResponseMessage> DeleteAsync(Guid id, Guid appUserId) => await _webApiService.httpClient.DeleteAsync($"stockTransfer/Delete/{id}/{appUserId}");

        public Task<HttpResponseMessage> GetAllAsync(Guid appUserId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetAllComboBoxAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> GetByIdAsync(Guid id, Guid appUserId) => await _webApiService.httpClient.GetAsync($"stockTransfer/GetById/{id}/{appUserId}");

        public async Task<HttpResponseMessage> AppUserBranchGetAll(Guid appUserId) => await _webApiService.httpClient.GetAsync($"stockTransfer/AppUserBranchGetAll/{appUserId}");
    }
}
