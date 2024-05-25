using Krop.Business.Features.AppUserRoles.Dtos;

namespace Krop.WinForms.HelpersClass.AppUserRoleHelpers
{
    public interface IAppUserRoleHelper
    {
        Task<List<GetAppUserRoleDTO>> GetAllAsync();
        Task<GetAppUserRoleDTO> GetByAppUserRoleIdAsync(Guid id);
    }
}
