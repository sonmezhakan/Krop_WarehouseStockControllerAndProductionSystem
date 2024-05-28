using Krop.Business.Features.AppUserRoles.Dtos;

namespace Krop.WinForms.HelpersClass.AppUserRoleHelpers
{
    public interface IAppUserRoleHelper
    {
        List<GetAppUserRoleDTO> GetAllAsync();
        GetAppUserRoleDTO GetByAppUserRoleIdAsync(Guid id);
    }
}
