using FluentValidation;
using Krop.Business.Features.Categories.Constants;
using Krop.Business.Features.Categories.Dtos;

namespace Krop.Business.Features.Categories.Validations
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage(CategoryMessages.CategoryIdNotEmptyAndNull)
                .NotNull().WithMessage(CategoryMessages.CategoryIdNotEmptyAndNull);

            RuleFor(c => c.CategoryName).
                  NotEmpty().WithMessage(CategoryMessages.CategoryNotNullAndEmpty)
                  .NotNull().WithMessage(CategoryMessages.CategoryNotNullAndEmpty)
                  .MinimumLength(3).WithMessage(CategoryMessages.CategoryNameMinAndMaxLenght)
                  .MaximumLength(64).WithMessage(CategoryMessages.CategoryNameMinAndMaxLenght);
        }
    }
}
