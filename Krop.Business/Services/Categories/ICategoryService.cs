using Krop.Business.Features.Categories.Dtos;
using Krop.Common.Utilits.Result;

namespace Krop.Business.Services.Categories
{
    public interface ICategoryService
    {
        Task<IResult> AddAsync(CreateCategoryDTO createCategoryDTO);
        Task<IResult> AddRangeAsync(List<CreateCategoryDTO> createCategoryDTOs);

        Task<IResult> UpdateAsync(UpdateCategoryDTO updateCategoryDTO);
        Task<IResult> UpdateRangeAsync(List<UpdateCategoryDTO> updateCategoryDTOs);

        Task<IResult> DeleteAsync(Guid id);
        Task<IResult> DeleteRangeAsync(List<Guid> ids);

        Task<IDataResult<IEnumerable<GetCategoryDTO>>> GetAllAsync();
        Task<IDataResult<GetCategoryDTO>> GetByIdAsync(Guid id);
        Task<IDataResult<GetCategoryDTO>> GetByCategoryNameAsync(string categoryName);

    }
}
