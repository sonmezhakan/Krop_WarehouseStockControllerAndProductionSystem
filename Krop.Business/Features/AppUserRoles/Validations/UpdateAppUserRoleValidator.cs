using FluentValidation;
using Krop.Business.Features.AppUserRoles.Constants;
using Krop.DTO.Dtos.AppUserRoles;

namespace Krop.Business.Features.AppUserRoles.Validations
{
    public class UpdateAppUserRoleValidator : AbstractValidator<UpdateAppUserRoleDTO>
    {
        public UpdateAppUserRoleValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(AppUserRoleMessages.AppUserRoleIdNotEmptyAndNull)
                .NotNull().WithMessage(AppUserRoleMessages.AppUserRoleIdNotEmptyAndNull);

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(AppUserRoleMessages.AppUserRoleNameNotNull)
                .NotNull().WithMessage(AppUserRoleMessages.AppUserRoleNameNotNull);


            RuleFor(x => x.Name)
                .MinimumLength(3).WithMessage(AppUserRoleMessages.AppUserRoleNameMinAndMaxLenght)
                .MaximumLength(64).WithMessage(AppUserRoleMessages.AppUserRoleNameMinAndMaxLenght);
        }
    }
}
