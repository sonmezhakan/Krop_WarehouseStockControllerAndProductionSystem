using Krop.DTO.Dtos.AppUserRoles;

namespace Krop.ViewModel.ViewModels.AppUserRoles
{
    public record DeleteAppUserRoleVM
    {
        public List<GetAppUserRoleDTO>? GetAppUserRoleDTOs { get; init; }
        public Guid? Id { get; init; }
    }
}
