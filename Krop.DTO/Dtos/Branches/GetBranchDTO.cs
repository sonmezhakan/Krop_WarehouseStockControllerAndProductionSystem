namespace Krop.DTO.Dtos.Branches
{
    public record  GetBranchDTO
    {
        public Guid Id{ get; init; }
        public string BranchName{ get; init; }
        public string PhoneNumber{ get; init; }
        public string Email{ get; init; }
        public string Country{ get; init; }
        public string City{ get; init; }
        public string Addres{ get; init; }
    }
}
