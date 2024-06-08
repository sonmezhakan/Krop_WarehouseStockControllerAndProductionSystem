namespace Krop.DTO.Dtos.Auths
{
    public record class LoginResponseDTO
    {
        public Guid Id { get; init; }
        public string Token { get; set; }
    }
}
