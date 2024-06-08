namespace Krop.DTO.Dtos.AppUsers
{
    public record class LoginDTO
    {
        public string UserName { get; init; }
        public string Password { get; init; }
    }
}
