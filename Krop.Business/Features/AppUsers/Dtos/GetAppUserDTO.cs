namespace Krop.Business.Features.AppUsers.Dtos
{
    public record class GetAppUserDTO
    {
        public Guid Id { get; init; }
        public string UserName { get; init; }
        public string Password { get; init; }

        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string NationalNumber { get; init; }

        public string Email { get; init; }
        public string PhoneNumber { get; init; }

        public string Country { get; init; }
        public string City { get; init; }
        public string Address { get; init; }
    }
}
