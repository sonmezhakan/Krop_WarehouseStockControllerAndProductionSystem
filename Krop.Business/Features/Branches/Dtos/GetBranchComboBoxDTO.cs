namespace Krop.Business.Features.Branches.Dtos
{
    public record class GetBranchComboBoxDTO
    {
        public Guid Id { get; set; }
        public string BranchName { get; set; }
    }
}
