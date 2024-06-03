using FluentValidation;
using Krop.Business.Features.AppUserRoles.Constants;
using Krop.DTO.Dtos.AppUserRoles;

namespace Krop.Business.Features.AppUserRoles.Validations
{
    public class CreateAppUserRoleValidator : AbstractValidator<CreateAppUserRoleDTO>
    {
        public CreateAppUserRoleValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().NotNull()
                .WithMessage(AppUserRoleMessages.AppUserRoleNameNotNull);

            RuleFor(x => x.Name)
                .MinimumLength(3)
                .MaximumLength(64)
                .WithMessage(AppUserRoleMessages.AppUserRoleNameMinAndMaxLenght);
        }
    }
}
