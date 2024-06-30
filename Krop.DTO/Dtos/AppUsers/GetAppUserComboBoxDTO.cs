namespace Krop.DTO.Dtos.AppUsers
{
    public record  GetAppUserComboBoxDTO
    {
        public Guid Id{ get; init; }
        public string UserName{ get; init; }
    }
}
