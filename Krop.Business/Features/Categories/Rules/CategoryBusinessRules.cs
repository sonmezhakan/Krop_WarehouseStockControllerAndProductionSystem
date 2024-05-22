using Krop.Business.Features.Categories.ExceptionHelpers;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

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

        public async Task<Category> CheckByCategoryId(Guid id)
        {
            var result = await _categoryRepository.GetAsync(c=>c.Id == id);
            if (result is null)
                _categoryExceptionHelper.ThrowCategoryNotFoundException();

            return result;
        }
        public async Task<Category> CheckByCategoryName(string categoryName)
        {
            var result = await _categoryRepository.GetAsync(c => c.CategoryName == categoryName);
            if (result is null)
                _categoryExceptionHelper.ThrowCategoryNotFoundException();

            return result;
        }

        public async Task CategoryNameCannotBeDuplicatedWhenInserted(string categoryName)
        {
           bool result =  await _categoryRepository.AnyAsync(c => c.CategoryName == categoryName);

            if (result)
                _categoryExceptionHelper.ThrowCategoryNameExistsdException();
        }
        public async Task CategoryNameRangeCannotBeDuplicatedWhenInserted(List<string> categoryNames)//CategoryNameRange
        {
            bool result = false;
            foreach (var categoryName in categoryNames)
            {
                if(categoryNames.Where(x=>x == categoryName).Count() > 1)//Çoklu olarak ekleme yapılacak liste içerisinde aynı isim olup olmadığı kontrol ediliyor.
                    _categoryExceptionHelper.ThrowCategoryNameExistsdException();

                result = await _categoryRepository.AnyAsync(c => c.CategoryName == categoryName);//Çoklu olarak ekleme yapılacak kategori isimlerinin veritabanında olup olmadığı kontrol ediliyor.
                if (result)
                    _categoryExceptionHelper.ThrowCategoryNameExistsdException();
            }  
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
