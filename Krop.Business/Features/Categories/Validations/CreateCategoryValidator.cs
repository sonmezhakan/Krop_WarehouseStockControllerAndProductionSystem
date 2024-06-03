using FluentValidation;
using Krop.Business.Features.Categories.Constants;
using Krop.DTO.Dtos.Categroies;

namespace Krop.Business.Features.Categories.Validations
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryValidator()
        {
          RuleFor(c => c.CategoryName).
                NotEmpty().WithMessage(CategoryMessages.CategoryNotNullAndEmpty)
                .NotNull().WithMessage(CategoryMessages.CategoryNotNullAndEmpty)
                .MinimumLength(3).WithMessage(CategoryMessages.CategoryNameMinAndMaxLenght)
                .MaximumLength(64).WithMessage(CategoryMessages.CategoryNameMinAndMaxLenght);
        }
    }
}
