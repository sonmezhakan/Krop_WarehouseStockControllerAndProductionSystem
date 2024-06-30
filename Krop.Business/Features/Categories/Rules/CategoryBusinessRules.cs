using Krop.Business.Features.Categories.Constants;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Features.Categories.Rules
{
    public class CategoryBusinessRules
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryBusinessRules(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IResult> CategoryNameCannotBeDuplicatedWhenInserted(string categoryName)
        {
           bool result =  await _categoryRepository.AnyAsync(c => c.CategoryName == categoryName);

            if (result)
                return new ErrorResult(StatusCodes.Status400BadRequest,CategoryMessages.CategoryNameExists);

            return new SuccessResult();
        }
        public async Task<IResult> CategoryNameRangeCannotBeDuplicatedWhenInserted(List<string> categoryNames)//CategoryNameRange
        {
            bool result = false;
            foreach (var categoryName in categoryNames)
            {
                if(categoryNames.Where(x=>x == categoryName).Count() > 1)//Çoklu olarak ekleme yapılacak liste içerisinde aynı isim olup olmadığı kontrol ediliyor.
                    return new ErrorResult(StatusCodes.Status400BadRequest, CategoryMessages.CategoryNameExists); ;

                result = await _categoryRepository.AnyAsync(c => c.CategoryName == categoryName);//Çoklu olarak ekleme yapılacak kategori isimlerinin veritabanında olup olmadığı kontrol ediliyor.
                if (result)
                    return new ErrorResult(StatusCodes.Status400BadRequest, CategoryMessages.CategoryNameExists);
            }

            return new SuccessResult();
        }
        public async Task<IResult> CategoryNameCannotBeDuplicatedWhenUpdated(string oldCategoryName, string newCategoryName)
        {
           if(oldCategoryName != newCategoryName)
            {
                bool result = await _categoryRepository.AnyAsync(c => c.CategoryName == newCategoryName);

                if (result)
                    return new ErrorResult(StatusCodes.Status400BadRequest, CategoryMessages.CategoryNameExists);
            }
            return new SuccessResult();
        }
    }
}
