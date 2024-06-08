using Krop.Business.Features.Brands.Constants;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Features.Brands.Rules
{
    public class BrandBusinessRules
    {
        private readonly IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<IDataResult<Brand>> CheckByBrandId(Guid id)
        {
            var result = await _brandRepository.GetAsync(b => b.Id == id);
            if (result is null)
                return new ErrorDataResult<Brand>(StatusCodes.Status404NotFound,BrandMessages.BrandNotFound);

            return new SuccessDataResult<Brand>(result);
        }
        public async Task<IResult> BrandNameCannotBeDuplicatedWhenInserted(string brandName)
        {
            bool result = await _brandRepository.AnyAsync(b=>b.BrandName == brandName);

            if (result)
                return new ErrorResult(StatusCodes.Status400BadRequest,BrandMessages.BrandNameExists);

            return new SuccessResult();
        }
        public async Task<IResult> BrandNameCannotBeDuplicatedWhenUpdated(string oldBrandName, string newBrandName)
        {
            if(oldBrandName != newBrandName)
            {
                bool result = await _brandRepository.AnyAsync(b => b.BrandName == newBrandName);

                if (result)
                    return new ErrorResult(StatusCodes.Status400BadRequest, BrandMessages.BrandNameExists);
            }
            return new SuccessResult();
        }
    }
}
