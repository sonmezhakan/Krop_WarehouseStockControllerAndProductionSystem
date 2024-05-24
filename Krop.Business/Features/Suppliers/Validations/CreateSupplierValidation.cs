using FluentValidation;
using Krop.Business.Features.Suppliers.Constants;
using Krop.Business.Features.Suppliers.Dtos;

namespace Krop.Business.Features.Suppliers.Validations
{
    public class CreateSupplierValidation : AbstractValidator<CreateSupplierDTO>
    {
        public CreateSupplierValidation()
        {
            //CustomerName, ContactName, ContactTitle
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage(SupplierMessages.SupplierCompanyNameNotNull)
                .NotNull().WithMessage(SupplierMessages.SupplierCompanyNameNotNull)
                .MinimumLength(3).WithMessage(SupplierMessages.SupplierCompanyNameMinAndMaxLenght)
                .MaximumLength(255).WithMessage(SupplierMessages.SupplierCompanyNameNotNull);

            RuleFor(x => x.ContactName)
                .MaximumLength(255).WithMessage(SupplierMessages.SupplierContactNameMaxLenght);

            RuleFor(x => x.ContactTitle)
                .MaximumLength(64).WithMessage(SupplierMessages.SupplierContactTitleMaxLenght);

            //PhoneNumber, Email
            RuleFor(x => x.PhoneNumber)
                .MaximumLength(11).WithMessage(SupplierMessages.SupplierPhoneNumberPhoneNumberMaxLenght);

            RuleFor(x => x.Email)
                .MaximumLength(128).WithMessage(SupplierMessages.SupplierEmailMaxLenght);

            //Country, City, Address
            RuleFor(x => x.Country)
                .MaximumLength(64).WithMessage(SupplierMessages.SupplierCountryMaxLenght);

            RuleFor(x => x.City)
                .MaximumLength(64).WithMessage(SupplierMessages.SupplierCityMaxLenght);

            RuleFor(x => x.Addres)
                .MaximumLength(255).WithMessage(SupplierMessages.SupplierAddressMaxLenght);

        }
    }
}
