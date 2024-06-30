namespace Krop.DTO.Dtos.Branches
{
    public record  GetBranchComboBoxDTO
    {
        public Guid Id{ get; init; }
        public string BranchName{ get; init; }
    }
}
