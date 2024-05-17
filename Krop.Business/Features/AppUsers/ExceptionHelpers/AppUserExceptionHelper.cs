using Krop.Business.Exceptions.Types;
using Krop.Business.Features.AppUsers.Constants;
using Krop.Entities.Entities;

namespace Krop.Business.Features.AppUsers.ExceptionHelpers
{
    public class AppUserExceptionHelper
    {
        public void ThrowAppUserNotFound() => throw new NotFoundException(AppUserMessages.AppUserNotFound);

        public void ThrowAppUserNameExists() => throw new BusinessException(AppUserMessages.AppUserNameExists);
        public void ThrowAppUserEmailExists() => throw new BusinessException(AppUserMessages.AppUserEmailExists);
        public void ThrowAppUserPhoneNumberExists() => throw new BusinessException(AppUserMessages.AppUserPhoneNumberExists);
        public void ThrowAppUserNationalNumberExists() => throw new BusinessException(AppUserMessages.AppUserNationalNumberExists);

        public void ThrowAppUserEmailNotConfirmed() => throw new BusinessException(AppUserMessages.AppUserEmailNotConfirm);

    }
}
