using FluentValidation;
using Krop.Business.Features.Customers.Constants;
using Krop.Business.Features.Customers.Dtos;

namespace Krop.Business.Features.Customers.Valdiations
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerDTO>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(CustomerMessages.CustomerIdNotEmptyAndNull)
                .NotNull().WithMessage(CustomerMessages.CustomerIdNotEmptyAndNull);

            //CustomerName, ContactName, ContactTitle
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage(CustomerMessages.CustomerCompanyNameNotNull)
                .NotNull().WithMessage(CustomerMessages.CustomerCompanyNameNotNull)
                .MinimumLength(3).WithMessage(CustomerMessages.CustomerCompanyNameNotNull)
                .MaximumLength(255).WithMessage(CustomerMessages.CustomerCompanyNameNotNull);

            RuleFor(x => x.ContactName)
                .MaximumLength(255).WithMessage(CustomerMessages.CustomerCompanyNameMinAndMaxLenght);

            RuleFor(x => x.ContactTitle)
                .MaximumLength(64).WithMessage(CustomerMessages.CustomerContactTitleMaxLenght);

            //PhoneNumber, Email
            RuleFor(x => x.PhoneNumber)
                .MaximumLength(11).WithMessage(CustomerMessages.CustomerPhoneNumberPhoneNumberMaxLenght);

            RuleFor(x => x.Email)
                .MaximumLength(128).WithMessage(CustomerMessages.CustomerEmailMaxLenght);

            //Country, City, Address
            RuleFor(x => x.Country)
                .MaximumLength(64).WithMessage(CustomerMessages.CustomerCountryMaxLenght);

            RuleFor(x => x.City)
                .MaximumLength(64).WithMessage(CustomerMessages.CustomerCityMaxLenght);

            RuleFor(x => x.Addres)
                .MaximumLength(255).WithMessage(CustomerMessages.CustomerAddressMaxLenght);
        }
    }
}
