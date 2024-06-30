using FluentValidation;
using Krop.Business.Features.AppUsers.Constants;
using Krop.DTO.Dtos.Auths;

namespace Krop.Business.Features.Auths.Validations
{
    public class LoginValidator:AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(AppUserMessages.UserNameNotNull)
                .NotNull().WithMessage(AppUserMessages.UserNameNotNull);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(AppUserMessages.AppUserPasswordNotEmptyAndNull)
                .NotNull().WithMessage(AppUserMessages.AppUserPasswordNotEmptyAndNull)
                .MinimumLength(8).WithMessage(AppUserMessages.AppUserPasswordMinAndMaxLenght);
        }
    }
}
