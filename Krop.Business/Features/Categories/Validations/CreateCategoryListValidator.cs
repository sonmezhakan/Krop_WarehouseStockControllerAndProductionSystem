using FluentValidation;
using Krop.DTO.Dtos.Categroies;

namespace Krop.Business.Features.Categories.Validations
{
    /// <summary>
    /// Toplu kategori ekleme esnasında kullanılacak validator
    /// </summary>
    public class CreateCategoryListValidator:AbstractValidator<List<CreateCategoryDTO>>
    {
        public CreateCategoryListValidator()
        {
            RuleForEach(x=>x).SetValidator(new CreateCategoryValidator());
        }
    }
}
