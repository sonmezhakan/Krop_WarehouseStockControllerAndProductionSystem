namespace Krop.DTO.Dtos.Auths
{
    public record class LoginDTO
    {
        public string UserName { get; init; }
        public string Password { get; init; }
    }
}
