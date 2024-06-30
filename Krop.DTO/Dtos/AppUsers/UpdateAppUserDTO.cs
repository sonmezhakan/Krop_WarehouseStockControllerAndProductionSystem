namespace Krop.DTO.Dtos.AppUsers
{
    public record  UpdateAppUserDTO
    {
        public Guid Id{ get; init; }
        public string FirstName{ get; init; }
        public string LastName{ get; init; }
        public string NationalNumber{ get; init; }

        public string Email{ get; init; }
        public string? PhoneNumber{ get; init; }

        public string? Country{ get; init; }
        public string? City{ get; init; }
        public string? Addres{ get; init; }
        public List<string>? Roles{ get; init; }
    }
}
