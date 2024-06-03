using Krop.Common.Utilits.Result;
using Krop.DTO.Dtos.Brands;

namespace Krop.Business.Services.Brands
{
    public interface IBrandService
    {
        Task<IResult> AddAsync(CreateBrandDTO createBrandDTO);
        Task<IResult> AddRangeAsync(List<CreateBrandDTO> createBrandDTOs);
        Task<IResult> UpdateAsync(UpdateBrandDTO updateBrandDTO);
        Task<IResult> UpdateRangeAsync(List<UpdateBrandDTO> updateBrandDTOs);
        Task<IResult> DeleteAsync(Guid id);
        Task<IResult> DeleteRangeAsync(List<Guid> ids);

        Task<IDataResult<IEnumerable<GetBrandDTO>>> GetAllAsync();
        Task<IDataResult<GetBrandDTO>> GetByIdAsync(Guid id);


        Task<IDataResult<IEnumerable<GetBrandComboBoxDTO>>> GetAllComboBoxAsync();
    }
}
