using Krop.Business.Features.Categories.ExceptionHelpers;
using Krop.DataAccess.Repositories.Abstracts;

namespace Krop.Business.Features.Categories.Rules
{
    public class CategoryBusinessRules
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryExceptionHelper _categoryExceptionHelper;

        public CategoryBusinessRules(ICategoryRepository categoryRepository,CategoryExceptionHelper categoryExceptionHelper)
        {
            _categoryRepository = categoryRepository;
            _categoryExceptionHelper = categoryExceptionHelper;
        }

        public async Task CategoryNameCannotBeDuplicatedWhenInserted(string categoryName)
        {
           bool result =  await _categoryRepository.AnyAsync(c => c.CategoryName == categoryName);

            if (result)
                _categoryExceptionHelper.ThrowCategoryNameExistsdException();
        }
        public async Task CategoryNameCannotBeDuplicatedWhenUpdated(string oldCategoryName, string newCategoryName)
        {
           if(oldCategoryName != newCategoryName)
            {
                bool result = await _categoryRepository.AnyAsync(c => c.CategoryName == newCategoryName);

                if (result)
                    _categoryExceptionHelper.ThrowCategoryNameExistsdException();
            }
        }
    }
}
