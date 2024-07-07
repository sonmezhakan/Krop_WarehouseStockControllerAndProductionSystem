using Krop.DTO.Dtos.AppUserRoles;
using Krop.DTO.Dtos.AppUsers;

namespace Krop.ViewModel.ViewModels.AppUsers
{
    public record UpdateAppUserVM
    {
        public List<GetAppUserComboBoxDTO>? GetAppUserComboBoxDTOs { get; init; }
        public List<GetAppUserRoleDTO>? GetAppUserRoleDTOs { get; init; }
        public UpdateAppUserDTO? UpdateAppUserDTO { get; init; }
        public UpdateAppUserPasswordDTO? UpdateAppUserPasswordDTO { get; init; }
    }
}
