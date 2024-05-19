using Krop.Business.Features.AppUsers.Dtos;
using Krop.Common.Utilits.Result;

namespace Krop.Business.Services.AppUsers
{
    public interface IAppUserService
    {
        Task<IResult> AddAsync(CreateAppUserDTO createAppUserDTO);
        Task<IResult> UpdateAsync(UpdateAppUserDTO updateAppUserDTO);
        Task<IResult> UpdatePasswordAsync(UpdateAppUserPasswordDTO updateAppUserPasswordDTO);
        Task<IDataResult<IEnumerable<GetAppUserDTO>>> GetAllAsync();
        Task<IDataResult<GetAppUserDTO>> GetByIdAsync(Guid id);
        Task<IResult> AnyByIdAsync(Guid id);
        Task<IDataResult<GetAppUserDTO>> GetByUserNameAsync(string userName);
    }
}
