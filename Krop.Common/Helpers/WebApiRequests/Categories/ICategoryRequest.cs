using Krop.DTO.Dtos.Categroies;

namespace Krop.Common.Helpers.WebApiRequests.Categories
{
    public interface ICategoryRequest
    {
        Task<HttpResponseMessage> GetAllAsync();
        Task<HttpResponseMessage> GetAllComboBoxAsync();
        Task<HttpResponseMessage> GetByIdAsync(Guid id);
        Task<HttpResponseMessage> AddAsync(CreateCategoryDTO createCategoryDTO);
        Task<HttpResponseMessage> AddRangeAsync(List<CreateCategoryDTO> createCategoryDTOs);
        Task<HttpResponseMessage> UpdateAsync(UpdateCategoryDTO updateCategoryDTO);
        Task<HttpResponseMessage> DeleteAsync(Guid id);
    }
}
