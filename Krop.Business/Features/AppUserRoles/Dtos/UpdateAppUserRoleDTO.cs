namespace Krop.Business.Features.AppUserRoles.Dtos
{
    public record class UpdateAppUserRoleDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }
}
