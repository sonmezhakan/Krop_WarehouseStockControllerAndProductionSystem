using Krop.Common.Utilits.Result;
using Krop.DTO.Dtos.Categroies;

namespace Krop.Business.Services.Categories
{
    public interface ICategoryService
    {
        Task<IResult> AddAsync(CreateCategoryDTO createCategoryDTO);
        Task<IResult> AddRangeAsync(List<CreateCategoryDTO> createCategoryDTOs);

        Task<IResult> UpdateAsync(UpdateCategoryDTO updateCategoryDTO);

        Task<IResult> DeleteAsync(Guid id);

        Task<IDataResult<IEnumerable<GetCategoryDTO>>> GetAllAsync();
        Task<IDataResult<GetCategoryDTO>> GetByIdAsync(Guid id);

        Task<IDataResult<IEnumerable<GetCategoryComboBoxDTO>>> GetAllComboBoxAsync();
    }
}
