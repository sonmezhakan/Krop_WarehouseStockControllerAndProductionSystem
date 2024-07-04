using Krop.DTO.Dtos.Branches;

namespace Krop.ViewModel.ViewModel.Branches
{
    public record DeleteBranchVM
    {
        public List<GetBranchComboBoxDTO>? GetBranchComboBoxDTO { get; init; }
        public Guid? Id { get; init; }
    }
}
