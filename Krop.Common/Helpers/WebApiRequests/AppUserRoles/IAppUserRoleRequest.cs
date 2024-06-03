using Krop.DTO.Dtos.AppUserRoles;
using Krop.DTO.Dtos.AppUsers;

namespace Krop.Common.Helpers.WebApiRequests.AppUserRoles
{
    public interface IAppUserRoleRequest
    {
        Task<HttpResponseMessage> GetAllAsync();
        Task<HttpResponseMessage> GetByIdAsync(Guid id);

        Task<HttpResponseMessage> AddAsync(CreateAppUserRoleDTO createAppUserRoleDTO);
        Task<HttpResponseMessage> UpdateAsync(UpdateAppUserRoleDTO updateAppUserRoleDTO);
        Task<HttpResponseMessage> DeleteAsync(Guid id);
    }
}
