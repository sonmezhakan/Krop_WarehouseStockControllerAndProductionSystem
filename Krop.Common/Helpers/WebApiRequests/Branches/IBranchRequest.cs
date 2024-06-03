using Krop.DTO.Dtos.Branches;

namespace Krop.Common.Helpers.WebApiRequests.Branches
{
    public interface IBranchRequest
    {
        Task<HttpResponseMessage> GetAllAsync();
        Task<HttpResponseMessage> GetAllComboBoxAsync();
        Task<HttpResponseMessage> GetByIdAsync(Guid id);
        Task<HttpResponseMessage> AddAsync(CreateBranchDTO createBranchDTO);
        Task<HttpResponseMessage> UpdateAsync(UpdateBranchDTO updateBranchDTO);
        Task<HttpResponseMessage> DeleteAsync(Guid id);
    }
}
