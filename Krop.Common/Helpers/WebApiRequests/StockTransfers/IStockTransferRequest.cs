using Krop.DTO.Dtos.StockTransfers;

namespace Krop.Common.Helpers.WebApiRequests.StockTransfers
{
    public interface IStockTransferRequest
    {
        Task<HttpResponseMessage> GetAllAsync(Guid appUserId);
        Task<HttpResponseMessage> GetAllComboBoxAsync();
        Task<HttpResponseMessage> GetByIdAsync(Guid id, Guid appUserId);
        Task<HttpResponseMessage> AddAsync(CreateStockTransferDTO createStockTransferDTO);
        Task<HttpResponseMessage> UpdateAsync(UpdateStockTransferDTO updateStockTransferDTO);
        Task<HttpResponseMessage> DeleteAsync(Guid id, Guid appUserId);
        Task<HttpResponseMessage> AppUserBranchGetAll(Guid appUserId);
    }
}
