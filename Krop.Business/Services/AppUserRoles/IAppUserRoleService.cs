using Krop.Business.Features.AppUserRoles.Dtos;

namespace Krop.Business.Services.AppUserRoles
{
    public interface IAppUserRoleService
    {
        Task<bool> AddAsync(CreateAppUserRoleDTO createAppUserRoleDTO);
        Task<bool> UpdateAsync(UpdateAppUserRoleDTO updateAppUserRoleDTO);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<GetAppUserRoleDTO>> GetAllAsync();
        Task<GetAppUserRoleDTO> GetByIdAsync(Guid id);
        Task<bool> GetByRoleNameAsync(string roleName);
    }
}
