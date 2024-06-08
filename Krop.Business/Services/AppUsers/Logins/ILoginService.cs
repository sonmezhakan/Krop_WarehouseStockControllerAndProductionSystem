using Krop.Common.Utilits.Result;
using Krop.DTO.Dtos.AppUsers;

namespace Krop.Business.Services.AppUsers.Logins
{
    public interface ILoginService
    {
        Task<IResult> LoginAsync(LoginDTO loginDTO);
    }
}
