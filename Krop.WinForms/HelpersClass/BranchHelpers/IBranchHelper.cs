using Krop.Business.Features.Branches.Dtos;

namespace Krop.WinForms.HelpersClass.BranchHelpers
{
    public interface IBranchHelper
    {
        List<GetBranchComboBoxDTO> GetAllComboBoxAsync();
        List<GetBranchDTO> GetAllAsync();
        GetBranchDTO GetByBranchIdAsync(Guid Id);
    }
}
