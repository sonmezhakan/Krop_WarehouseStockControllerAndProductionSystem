using Krop.Business.Features.Categories.Dtos;

namespace Krop.Business.Services.Categories
{
    public interface ICategoryService
    {
        Task<bool> AddAsync(CreateCategoryDTO createCategoryDTO);
        Task<bool> AddRangeAsync(List<CreateCategoryDTO> createCategoryDTOs);

        Task<bool> UpdateAsync(UpdateCategoryDTO updateCategoryDTO);
        Task<bool> UpdateRangeAsync(List<UpdateCategoryDTO> updateCategoryDTOs);

        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteRangeAsync(List<Guid> ids);

        Task<IEnumerable<GetCategoryDTO>> GetAllAsync();
        Task<GetCategoryDTO> GetByIdAsync(Guid id);
        Task<GetCategoryDTO> GetByCategoryNameAsync(string categoryName);

    }
}
