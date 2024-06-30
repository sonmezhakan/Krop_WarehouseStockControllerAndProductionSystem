namespace Krop.DTO.Dtos.Auths
{
    public record  ResetPasswordDTO
    {
        public string Email{ get; init; }
        public string Password{ get; init; }
        public string Token{ get; init; }
    }
}
