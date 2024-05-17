using Krop.Business.Features.Brands.Dtos;

namespace Krop.Business.Services.Brands
{
    public interface IBrandService
    {
        Task<bool> AddAsync(CreateBrandDTO createBrandDTO);
        Task<bool> AddRangeAsync(List<CreateBrandDTO> createBrandDTOs);
        Task<bool> UpdateAsync(UpdateBrandDTO updateBrandDTO);
        Task<bool> UpdateRangeAsync(List<UpdateBrandDTO> updateBrandDTOs);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteRangeAsync(List<Guid> ids);

        Task<IEnumerable<GetBrandDTO>> GetAllAsync();
        Task<GetBrandDTO> GetByIdAsync(Guid id);

    }
}
