using Krop.Common.Utilits.Result;
using Krop.DTO.Dtos.Branches;

namespace Krop.Business.Services.Branches
{
    public interface IBranchService
    {
        Task<IResult> AddAsync(CreateBranchDTO createBranchDTO);
        Task<IResult> AddRangeAsync(List<CreateBranchDTO> createBranchDTOs);

        Task<IResult> UpdateAsync(UpdateBranchDTO updateBranchDTO);
        Task<IResult> UpdateRangeAsync(List<UpdateBranchDTO> updateBranchDTOs);

        Task<IResult> DeleteAsync(Guid id);
        Task<IResult> DeleteRangeAsync(List<Guid> ids);

        Task<IDataResult<IEnumerable<GetBranchDTO>>> GetAllAsync();
        Task<IDataResult<GetBranchDTO>> GetByIdAsync(Guid id);

        Task<IDataResult<IEnumerable<GetBranchComboBoxDTO>>> GetAllComboBoxAsync();
    }
}
