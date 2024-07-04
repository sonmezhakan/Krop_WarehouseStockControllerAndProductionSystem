using Krop.DTO.Dtos.Branches;

namespace Krop.ViewModel.ViewModel.Branches
{
    public record UpdateBranchVM
    {
        public List<GetBranchComboBoxDTO>? GetBranchComboBoxDTO { get; init; }
        public UpdateBranchDTO? UpdateBranchDTO { get; init; }
    }
}
