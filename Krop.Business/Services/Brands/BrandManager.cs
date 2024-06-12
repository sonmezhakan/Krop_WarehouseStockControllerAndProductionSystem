using AutoMapper;
using Krop.Business.Features.Brands.Constants;
using Krop.Business.Features.Brands.Rules;
using Krop.Business.Features.Brands.Validations;
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
            var getBrand = await _brandBusinessRules.CheckByBrandId(updateBrandDTO.Id);
            if (!getBrand.Success)
                return getBrand;

            var result = BusinessRules.Run(
                await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenUpdated(getBrand.Data.BrandName, updateBrandDTO.BrandName));
            if (!result.Success)
                return result;

            Brand brand = getBrand.Data;
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
            var getBrand = await _brandBusinessRules.CheckByBrandId(id);
            if (!getBrand.Success)
                return getBrand;

            await _brandRepository.DeleteAsync(getBrand.Data);

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
            IEnumerable<GetBrandDTO> getBrandDTOs = await _cacheHelper.GetOrAddListAsync(
                BrandCacheKeys.GetAllAsync,
                async () =>
                {
                    var result = await _brandRepository.GetAllAsync();
                    return _mapper.Map<IEnumerable<GetBrandDTO>>(result);
                },
                60);

            return new SuccessDataResult<IEnumerable<GetBrandDTO>>(getBrandDTOs);
        }
        public async Task<IDataResult<IEnumerable<GetBrandComboBoxDTO>>> GetAllComboBoxAsync()
        {
            IEnumerable<GetBrandComboBoxDTO> getBrandComboBoxDTOs = await _cacheHelper.GetOrAddListAsync(
                BrandCacheKeys.GetAllComboBoxAsync,
                async () =>
                {
                    var result = await _brandRepository.GetAllComboBoxAsync();
                    return _mapper.Map<IEnumerable<GetBrandComboBoxDTO>>(result);
                },
                60
                );

            return new SuccessDataResult<IEnumerable<GetBrandComboBoxDTO>>(getBrandComboBoxDTOs);
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetBrandDTO>> GetByIdAsync(Guid id)
        {
            GetBrandDTO getBrandDTO = await _cacheHelper.GetOrAddAsync<GetBrandDTO>($"{BrandCacheKeys.GetByIdAsync}+{id}",
                async () =>
                {
                    var result = await _brandBusinessRules.CheckByBrandId(id);
                    return _mapper.Map<GetBrandDTO>(result.Data);
                },
                60
                );
           if (getBrandDTO is null)
                return new ErrorDataResult<GetBrandDTO>(StatusCodes.Status404NotFound, BrandMessages.BrandNotFound);

            return new SuccessDataResult<GetBrandDTO>(getBrandDTO);
        }
        #endregion
    }
}
