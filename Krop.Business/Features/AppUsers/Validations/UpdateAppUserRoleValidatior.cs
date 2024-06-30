using FluentValidation;
using Krop.Business.Features.AppUsers.Constants;
using Krop.DTO.Dtos.AppUsers;

namespace Krop.Business.Features.AppUsers.Validations
{
    public class UpdateAppUserRoleValidatior:AbstractValidator<UpdateAppUserUpdateRoleDTO>
    {
        public UpdateAppUserRoleValidatior()
        {
            RuleFor(x => x.AppUserId)
                .NotNull().WithMessage(AppUserMessages.AppUserIdNotEmptyAndNull)
                .NotEmpty().WithMessage(AppUserMessages.AppUserIdNotEmptyAndNull);
        }
    }
}
