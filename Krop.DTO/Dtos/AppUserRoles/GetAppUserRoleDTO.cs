namespace Krop.DTO.Dtos.AppUserRoles
{
    public record class GetAppUserRoleDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }
}
