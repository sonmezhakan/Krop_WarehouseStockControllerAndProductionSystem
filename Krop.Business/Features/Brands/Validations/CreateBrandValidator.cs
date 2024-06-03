using FluentValidation;
using Krop.Business.Features.Brands.Constants;
using Krop.DTO.Dtos.Brands;

namespace Krop.Business.Features.Brands.Validations
{
    public class CreateBrandValidator:AbstractValidator<CreateBrandDTO>
    {
        public CreateBrandValidator()
        {
            //BrandName
            RuleFor(x => x.BrandName)
                .NotEmpty().WithMessage(BrandMessages.BrandNameNotNull)
                .NotNull().WithMessage(BrandMessages.BrandNameNotNull)
                .MinimumLength(3).WithMessage(BrandMessages.BrandNameMinAndMaxLenght)
                .MaximumLength(128).WithMessage(BrandMessages.BrandNameMinAndMaxLenght);

            //PhoneNumber, Email
            RuleFor(x => x.PhoneNumber)
                .MaximumLength(11).WithMessage(BrandMessages.BrandPhoneNumberMaxLenght);

            RuleFor(x => x.Email)
                .MaximumLength(128).WithMessage(BrandMessages.BrandEmailMaxLenght);
        }
    }
}
