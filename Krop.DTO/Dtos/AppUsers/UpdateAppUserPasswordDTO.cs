namespace Krop.DTO.Dtos.AppUsers
{
    public record class UpdateAppUserPasswordDTO
    {
        public Guid Id { get; init; }
        public string Password { get; init; }
    }
}
