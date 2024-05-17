using FluentValidation;
using Krop.Business.Features.Products.Constants;
using Krop.Business.Features.Products.Dtos;

namespace Krop.Business.Features.Products.Validations
{
    public class CreateProductValidator:AbstractValidator<CreateProductDTO>
    {
        public CreateProductValidator()
        {
            //ProductName , ProductCode, Description
            RuleFor(x => x.ProductName)
                .NotNull().WithMessage(ProductMessages.ProductNameNotNull)
                .NotEmpty().WithMessage(ProductMessages.ProductNameNotNull)
                .MinimumLength(3).WithMessage(ProductMessages.ProductNameMinAndMaxLenght)
                .MaximumLength(255).WithMessage(ProductMessages.ProductNameMinAndMaxLenght);

            RuleFor(x => x.ProductCode)
                .NotNull().WithMessage(ProductMessages.ProductCodeNotNull)
                .NotEmpty().WithMessage(ProductMessages.ProductCodeNotNull)
                .MinimumLength(3).WithMessage(ProductMessages.ProductCodeMinAndMaxLenght)
                .MaximumLength(255).WithMessage(ProductMessages.ProductCodeMinAndMaxLenght);

            RuleFor(x => x.Description)
                .MaximumLength(255).WithMessage(ProductMessages.ProductDescriptionMaxLenght);

            //Category
            RuleFor(x => x.CategoryId)
                .NotNull().WithMessage(ProductMessages.CategoryNotNull)
                .NotEmpty().WithMessage(ProductMessages.CategoryNotNull);
        }
    }
}
