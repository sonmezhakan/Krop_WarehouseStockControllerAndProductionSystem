using FluentValidation;
using Krop.Business.Features.AppUserRoles.Constants;
using Krop.Business.Features.AppUserRoles.Dtos;

namespace Krop.Business.Features.AppUserRoles.Validations
{
    public class UpdateAppUserRoleValidator : AbstractValidator<UpdateAppUserRoleDTO>
    {
        public UpdateAppUserRoleValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(AppUserRoleMessages.AppUserRoleIdNotEmptyAndNull)
                .NotNull().WithMessage(AppUserRoleMessages.AppUserRoleIdNotEmptyAndNull);

            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage(AppUserRoleMessages.AppUserRoleNameNotNull)
                .NotNull().WithMessage(AppUserRoleMessages.AppUserRoleNameNotNull);


            RuleFor(x => x.RoleName)
                .MinimumLength(3).WithMessage(AppUserRoleMessages.AppUserRoleNameMinAndMaxLenght)
                .MaximumLength(64).WithMessage(AppUserRoleMessages.AppUserRoleNameMinAndMaxLenght);
        }
    }
}
