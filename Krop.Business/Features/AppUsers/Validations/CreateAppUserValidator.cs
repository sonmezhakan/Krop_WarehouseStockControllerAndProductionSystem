using FluentValidation;
using Krop.Business.Features.AppUsers.Constants;
using Krop.DTO.Dtos.AppUsers;

namespace Krop.Business.Features.AppUsers.Validations
{
    public class CreateAppUserValidator:AbstractValidator<CreateAppUserDTO>
    {
        public CreateAppUserValidator()
        {
            //UserName
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(AppUserMessages.UserNameNotNull)
                .NotNull().WithMessage(AppUserMessages.UserNameNotNull)
                .MinimumLength(3).WithMessage(AppUserMessages.UserNameMinAndMaxLenght)
                .MaximumLength(64).WithMessage(AppUserMessages.UserNameMinAndMaxLenght);

            //Password
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(AppUserMessages.AppUserPasswordNotEmptyAndNull)
                .NotNull().WithMessage(AppUserMessages.AppUserPasswordNotEmptyAndNull)
                .MinimumLength(8).WithMessage(AppUserMessages.AppUserPasswordMinAndMaxLenght)
                .MaximumLength(64).WithMessage(AppUserMessages.AppUserPasswordMinAndMaxLenght);

            //Email
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(AppUserMessages.EmailNotNull)
                .NotNull().WithMessage(AppUserMessages.EmailNotNull)
                .EmailAddress().WithMessage(AppUserMessages.EmailNotFormatted)
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
