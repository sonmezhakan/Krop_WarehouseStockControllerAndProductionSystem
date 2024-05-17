using Krop.Business.Features.Branches.Dtos;

namespace Krop.Business.Services.Branches
{
    public interface IBranchService
    {
        Task<bool> AddAsync(CreateBranchDTO createBranchDTO);
        Task<bool> AddRangeAsync(List<CreateBranchDTO> createBranchDTOs);

        Task<bool> UpdateAsync(UpdateBranchDTO updateBranchDTO);
        Task<bool> UpdateRangeAsync(List<UpdateBranchDTO> updateBranchDTOs);

        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteRangeAsync(List<Guid> ids);

        Task<IEnumerable<GetBranchDTO>> GetAllAsync();
        Task<GetBranchDTO> GetByIdAsync(Guid id);
    }
}
