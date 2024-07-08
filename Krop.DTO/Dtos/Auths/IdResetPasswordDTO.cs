namespace Krop.DTO.Dtos.Auths
{
    public record IdResetPasswordDTO
    {
        public Guid Id { get; init; }
        public string Password { get; init; }
        public string Token { get; init; }
    }
}
