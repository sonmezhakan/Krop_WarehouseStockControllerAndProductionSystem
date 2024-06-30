using AutoMapper;
using Krop.Business.Features.Brands.Constants;
using Krop.Business.Features.Brands.Rules;
using Krop.Business.Features.Brands.Validations;
using Krop.Business.Features.Categories.Constants;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Helpers.CacheHelpers;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.Brands;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Services.Brands
{
    public partial class BrandManager : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _brandBusinessRules;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheHelper _cacheHelper;

        public BrandManager(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules, IUnitOfWork unitOfWork, ICacheHelper cacheHelper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
            _unitOfWork = unitOfWork;
            _cacheHelper = cacheHelper;
        }

        #region Add
        [ValidationAspect(typeof(CreateBrandValidator))]
        public async Task<IResult> AddAsync(CreateBrandDTO createBrandDTO)
        {
            var result = BusinessRules.Run(await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(createBrandDTO.BrandName));
            if (!result.Success)
                return result;

            await _brandRepository.AddAsync(
                _mapper.Map<Brand>(createBrandDTO));

            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                BrandCacheKeys.GetAllAsync,
                BrandCacheKeys.GetAllComboBoxAsync
            });
            return new SuccessResult();
        }

        #endregion
        #region Update
        [ValidationAspect(typeof(UpdateBrandValidator))]
        public async Task<IResult> UpdateAsync(UpdateBrandDTO updateBrandDTO)
        {
            var getBrand = await _brandRepository.GetAsync(x => x.Id == updateBrandDTO.Id);
            if (getBrand is null)
                return new ErrorResult(StatusCodes.Status404NotFound, BrandMessages.BrandNotFound);

            var result = BusinessRules.Run(
                await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenUpdated(getBrand.BrandName, updateBrandDTO.BrandName));
            if (!result.Success)
                return result;

            Brand brand = getBrand;
            brand = _mapper.Map(updateBrandDTO, brand);
            await _brandRepository.UpdateAsync(brand);

            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                BrandCacheKeys.GetAllAsync,
                BrandCacheKeys.GetAllComboBoxAsync,
                $"{BrandCacheKeys.GetByIdAsync}{updateBrandDTO.Id}"
            });
            return new SuccessResult();
        }
        #endregion
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var getBrand = await _brandRepository.GetAsync(x => x.Id == id);
            if (getBrand is null)
                return new ErrorResult(StatusCodes.Status404NotFound, BrandMessages.BrandNotFound);

            await _brandRepository.DeleteAsync(getBrand);

            await _unitOfWork.SaveChangesAsync();
            await _cacheHelper.RemoveAsync(new string[]
            {
                BrandCacheKeys.GetAllAsync,
                BrandCacheKeys.GetAllComboBoxAsync,
                $"{BrandCacheKeys.GetByIdAsync}{id}" });
            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetBrandDTO>>> GetAllAsync()
        {
            IEnumerable<GetBrandDTO>? getBrandDTOs = await _cacheHelper.GetOrAddListAsync(
                BrandCacheKeys.GetAllAsync,
                async () =>
                {
                    var result = await _brandRepository.GetAllAsync();
                    return result is null ? null : _mapper.Map<IEnumerable<GetBrandDTO>>(result);
                },
                60);

            return new SuccessDataResult<IEnumerable<GetBrandDTO>>(getBrandDTOs);
        }
        public async Task<IDataResult<IEnumerable<GetBrandComboBoxDTO>>> GetAllComboBoxAsync()
        {
            IEnumerable<GetBrandComboBoxDTO>? getBrandComboBoxDTOs = await _cacheHelper.GetOrAddListAsync(
                BrandCacheKeys.GetAllComboBoxAsync,
                async () =>
                {
                    var result = await _brandRepository.GetAllComboBoxAsync();
                    return result is null ? null : _mapper.Map<IEnumerable<GetBrandComboBoxDTO>>(result);
                },
                60
                );

            return new SuccessDataResult<IEnumerable<GetBrandComboBoxDTO>>(getBrandComboBoxDTOs);
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetBrandDTO>> GetByIdAsync(Guid id)
        {
            GetBrandDTO? getBrandDTO = await _cacheHelper.GetOrAddAsync($"{BrandCacheKeys.GetByIdAsync}{id}",
                async () =>
                {
                    var result = await _brandRepository.GetAsync(x => x.Id == id);
                    return _mapper.Map<GetBrandDTO>(result);
                },
                60
                );
            return getBrandDTO is null ?
                 new ErrorDataResult<GetBrandDTO>(StatusCodes.Status404NotFound, BrandMessages.BrandNotFound) :
                 new SuccessDataResult<GetBrandDTO>(getBrandDTO);
        }
        #endregion
    }
}
