using FluentValidation;
using Krop.Business.Features.AppUsers.Constants;
using Krop.Business.Features.AppUsers.Dtos;

namespace Krop.Business.Features.AppUsers.Validations
{
    public class UpdatePasswordAppUserValidator : AbstractValidator<UpdateAppUserPasswordDTO>
    {
        public UpdatePasswordAppUserValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(AppUserMessages.AppUserIdNotEmptyAndNull)
                .NotNull().WithMessage(AppUserMessages.AppUserIdNotEmptyAndNull);

            //Password
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(AppUserMessages.AppUserPasswordNotEmptyAndNull)
                .NotNull().WithMessage(AppUserMessages.AppUserPasswordNotEmptyAndNull)
                .MinimumLength(8).WithMessage(AppUserMessages.AppUserPasswordMinAndMaxLenght)
                .MaximumLength(64).WithMessage(AppUserMessages.AppUserPasswordMinAndMaxLenght);

        }
    }
}
