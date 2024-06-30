namespace Krop.DTO.Dtos.Auths
{
    public record  LoginResponseDTO
    {
        public Guid Id { get; init; }
        public string Token{ get; init; }
    }
}
