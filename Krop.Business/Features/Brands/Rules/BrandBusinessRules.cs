using Krop.Business.Features.Brands.ExceptionHelpers;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Brands.Rules
{
    public class BrandBusinessRules
    {
        private readonly IBrandRepository _brandRepository;
        private readonly BrandExceptionHelper _brandExceptionHelper;

        public BrandBusinessRules(IBrandRepository brandRepository,BrandExceptionHelper brandExceptionHelper)
        {
            _brandRepository = brandRepository;
            _brandExceptionHelper = brandExceptionHelper;
        }

        public async Task<Brand> CheckByBrandId(Guid id)
        {
            var result = await _brandRepository.GetAsync(b => b.Id == id);
            if (result is null)
                _brandExceptionHelper.ThrowBrandNotFound();

            return result;
        }
        public async Task BrandNameCannotBeDuplicatedWhenInserted(string brandName)
        {
            bool result = await _brandRepository.AnyAsync(b=>b.BrandName == brandName);

            if (result)
                _brandExceptionHelper.ThrowBrandNameExists();
        }
        public async Task BrandNameCannotBeDuplicatedWhenUpdated(string oldBrandName, string newBrandName)
        {
            if(oldBrandName != newBrandName)
            {
                bool result = await _brandRepository.AnyAsync(b => b.BrandName == newBrandName);

                if (result)
                    _brandExceptionHelper.ThrowBrandNameExists();
            }
        }
    }
}
