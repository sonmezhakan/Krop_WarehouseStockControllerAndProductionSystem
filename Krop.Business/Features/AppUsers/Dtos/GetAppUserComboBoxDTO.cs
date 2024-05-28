namespace Krop.Business.Features.AppUsers.Dtos
{
    public record class GetAppUserComboBoxDTO
    {
        public Guid Id { get; init; }
        public string UserName { get; init; }
    }
}
