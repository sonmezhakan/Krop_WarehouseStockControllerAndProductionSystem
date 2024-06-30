namespace Krop.DTO.Dtos.AppUsers
{
    public record  UpdateAppUserPasswordDTO
    {
        public Guid Id{ get; init; }
        public string Password{ get; init; }
    }
}
