namespace Krop.Business.Features.AppUserRoles.Dtos
{
    public record class GetAppUserRoleDTO
    {
        public Guid Id { get; init; }
        public string RoleName { get; init; }
    }
}
