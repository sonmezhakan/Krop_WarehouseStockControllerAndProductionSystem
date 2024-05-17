namespace Krop.Business.Features.AppUsers.Dtos
{
    public record class UpdateAppUserPasswordDTO
    {
        public Guid Id { get; init; }
        public string Password { get; init; }
    }
}
