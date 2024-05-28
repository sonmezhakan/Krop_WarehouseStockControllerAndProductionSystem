using FluentValidation;
using Krop.Business.Features.AppUsers.Constants;
using Krop.Business.Features.AppUsers.Dtos;

namespace Krop.Business.Features.AppUsers.Validations
{
    public class UpdateAppUserValidator : AbstractValidator<UpdateAppUserDTO>
    {
        public UpdateAppUserValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(AppUserMessages.AppUserIdNotEmptyAndNull)
                .NotNull().WithMessage(AppUserMessages.AppUserIdNotEmptyAndNull);

            //Email
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(AppUserMessages.EmailNotNull)
                .NotNull().WithMessage(AppUserMessages.EmailNotNull)
                .MinimumLength(7).WithMessage(AppUserMessages.EmailMinAndMaxLenght)
                .MaximumLength(128).WithMessage(AppUserMessages.EmailMinAndMaxLenght);

            //Country, City, Address
            RuleFor(x => x.Country)
                .MaximumLength(64).WithMessage(AppUserMessages.CountryMaxLenght);

            RuleFor(x => x.City)
                .MaximumLength(64).WithMessage(AppUserMessages.CityMaxLenght);

            RuleFor(x => x.Addres)
                .MaximumLength(255).WithMessage(AppUserMessages.Address);

            //FirstName, LastName, NationalNumber
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage(AppUserMessages.FirstNameNotNull)
                .NotNull().WithMessage(AppUserMessages.FirstNameNotNull)
                .MinimumLength(3).WithMessage(AppUserMessages.FirstNameMinAndMaxLenght)
                .MaximumLength(128).WithMessage(AppUserMessages.FirstNameMinAndMaxLenght);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage(AppUserMessages.LastNameNotNull)
                .NotNull().WithMessage(AppUserMessages.LastNameNotNull)
                .MinimumLength(3).WithMessage(AppUserMessages.LastNameMinAndMaxLenght)
                .MaximumLength(128).WithMessage(AppUserMessages.LastNameMinAndMaxLenght);

            RuleFor(x => x.NationalNumber)
                .MaximumLength(11).WithMessage(AppUserMessages.NationalNumberMaxLenght);
        }
    }
}
