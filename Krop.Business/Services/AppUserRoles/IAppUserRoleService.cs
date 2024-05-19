using Krop.Business.Features.AppUserRoles.Dtos;
using Krop.Common.Utilits.Result;

namespace Krop.Business.Services.AppUserRoles
{
    public interface IAppUserRoleService
    {
        Task<IResult> AddAsync(CreateAppUserRoleDTO createAppUserRoleDTO);
        Task<IResult> UpdateAsync(UpdateAppUserRoleDTO updateAppUserRoleDTO);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<IEnumerable<GetAppUserRoleDTO>>> GetAllAsync();
        Task<IDataResult<GetAppUserRoleDTO>> GetByIdAsync(Guid id);
        Task<IDataResult<GetAppUserRoleDTO>> GetByRoleNameAsync(string roleName);
    }
}
