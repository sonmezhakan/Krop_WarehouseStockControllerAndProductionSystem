using Krop.DTO.Dtos.AppUserRoles;

namespace Krop.ViewModel.ViewModels.AppUserRoles
{
    public record UpdateAppUserRoleVM
    {
        public List<GetAppUserRoleDTO>? GetAppUserRoleDTOs { get; init; }
        public UpdateAppUserRoleDTO? UpdateAppUserRoleDTO { get; init; }
    }
}
