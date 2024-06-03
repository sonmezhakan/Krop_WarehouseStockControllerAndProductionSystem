using Krop.DTO.Dtos.Brands;

namespace Krop.Common.Helpers.WebApiRequests.Brands
{
    public interface IBrandRequest
    {
        Task<HttpResponseMessage> GetAllAsync();
        Task<HttpResponseMessage> GetAllComboBoxAsync();
        Task<HttpResponseMessage> GetByIdAsync(Guid id);
        Task<HttpResponseMessage> AddAsync(CreateBrandDTO createBrandDTO);
        Task<HttpResponseMessage> UpdateAsync(UpdateBrandDTO updateBrandDTO);
        Task<HttpResponseMessage> DeleteAsync(Guid id);
    }
}
