namespace Krop.DTO.Dtos.AppUserRoles
{
    public record  UpdateAppUserRoleDTO
    {
        public Guid Id{ get; init; }
        public string Name{ get; init; }
    }
}
