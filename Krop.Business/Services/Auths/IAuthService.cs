using Krop.Common.Utilits.Result;
using Krop.DTO.Dtos.Auths;
using Krop.Entities.Entities;

namespace Krop.Business.Services.Auths
{
    public interface IAuthService
    {
        Task<IDataResult<AppUser>> LoginAsync(LoginDTO loginDTO);
        Task<IDataResult<LoginResponseDTO>> CreateAccessToken(AppUser appUser);
        Task<IResult> ResetPasswordWinFormEmailSenderAsync(string email);
        Task<IResult> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO);
    }
}
