using Krop.Business.Features.Branches.Dtos;

namespace Krop.WinForms.HelpersClass.BranchHelpers
{
    public interface IBranchHelper
    {
        Task<List<GetBranchComboBoxDTO>> GetAllComboBoxAsync();
        Task<List<GetBranchDTO>> GetAllAsync();
        Task<GetBranchDTO> GetByBranchIdAsync(Guid Id);
    }
}
