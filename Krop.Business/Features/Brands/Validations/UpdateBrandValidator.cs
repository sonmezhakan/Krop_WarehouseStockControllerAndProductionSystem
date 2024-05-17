using FluentValidation;
using Krop.Business.Features.Brands.Constants;
using Krop.Business.Features.Brands.Dtos;

namespace Krop.Business.Features.Brands.Validations
{
    public class UpdateBrandValidator : AbstractValidator<UpdateBrandDTO>
    {
        public UpdateBrandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage(BrandMessages.BrandIdNotEmptyAndNull)
                .NotEmpty().WithMessage(BrandMessages.BrandIdNotEmptyAndNull);

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
