using FluentValidation;
using Krop.Business.Features.AppUserRoles.Constants;
using Krop.Business.Features.AppUserRoles.Dtos;

namespace Krop.Business.Features.AppUserRoles.Validations
{
    public class CreateAppUserRoleValidator : AbstractValidator<CreateAppUserRoleDTO>
    {
        public CreateAppUserRoleValidator()
        {
            RuleFor(x => x.RoleName)
                .NotEmpty().NotNull()
                .WithMessage(AppUserRoleMessages.AppUserRoleNameNotNull);

            RuleFor(x => x.RoleName)
                .MinimumLength(3)
                .MaximumLength(64)
                .WithMessage(AppUserRoleMessages.AppUserRoleNameMinAndMaxLenght);
        }
    }
}
