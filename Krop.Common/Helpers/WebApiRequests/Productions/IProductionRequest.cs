using Krop.DTO.Dtos.Productions;

namespace Krop.Common.Helpers.WebApiRequests.Productions
{
    public interface IProductionRequest
    {
        Task<HttpResponseMessage> GetAllAsync(Guid appUserId);
        Task<HttpResponseMessage> GetAllComboBoxAsync();
        Task<HttpResponseMessage> GetByIdAsync(Guid id);
        Task<HttpResponseMessage> AddAsync(CreateProductionDTO createProductionDTO);
        Task<HttpResponseMessage> UpdateAsync(UpdateProductionDTO updateProductionDTO);
        Task<HttpResponseMessage> DeleteAsync(Guid id);
    }
}
