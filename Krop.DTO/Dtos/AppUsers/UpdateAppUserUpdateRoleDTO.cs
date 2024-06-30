namespace Krop.DTO.Dtos.AppUsers
{
    public record UpdateAppUserUpdateRoleDTO
    {
        public Guid AppUserId{ get; init; }
        public List<string> Roles{ get; init; }
    }
}
