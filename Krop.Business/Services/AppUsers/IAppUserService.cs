using Krop.Business.Features.AppUsers.Dtos;

namespace Krop.Business.Services.AppUsers
{
    public interface IAppUserService
    {
        Task<bool> AddAsync(CreateAppUserDTO createAppUserDTO);
        Task<bool> UpdateAsync(UpdateAppUserDTO updateAppUserDTO);
        Task<bool> UpdatePasswordAsync(UpdateAppUserPasswordDTO updateAppUserPasswordDTO);
        Task<IEnumerable<GetAppUserDTO>> GetAllAsync();
        Task<GetAppUserDTO> GetByIdAsync(Guid id);
        Task<bool> AnyByIdAsync(Guid id);
        Task<GetAppUserDTO> GetByUserNameAsync(string userName);
    }
}
