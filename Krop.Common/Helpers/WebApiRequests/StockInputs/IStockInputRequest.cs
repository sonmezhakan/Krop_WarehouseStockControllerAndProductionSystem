using Krop.DTO.Dtos.StockInputs;

namespace Krop.Common.Helpers.WebApiRequests.StockInputs
{
    public interface IStockInputRequest
    {
        Task<HttpResponseMessage> GetAllAsync(Guid appUserId);
        Task<HttpResponseMessage> GetAllComboBoxAsync();
        Task<HttpResponseMessage> GetByIdAsync(Guid id);
        Task<HttpResponseMessage> AddAsync(CreateStockInputDTO createStockInputDTO);
        Task<HttpResponseMessage> UpdateAsync(UpdateStockInputDTO updateStockInputDTO);
        Task<HttpResponseMessage> DeleteAsync(Guid id, Guid appUserId);
    }
}
