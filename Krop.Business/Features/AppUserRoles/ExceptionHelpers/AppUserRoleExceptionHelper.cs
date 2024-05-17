using Krop.Business.Exceptions.Types;
using Krop.Business.Features.AppUserRoles.Constants;
using Krop.Entities.Entities;

namespace Krop.Business.Features.AppUserRoles.ExceptionHelpers
{
    public class AppUserRoleExceptionHelper
    {
        public void ThrowAppUserRoleNotFound() => throw new NotFoundException(AppUserRoleMessages.AppUserRoleNotFound);
        public void ThrowAppUserRoleNameExists() => throw new BusinessException(AppUserRoleMessages.AppUserRoleNameExists);
    }
}
