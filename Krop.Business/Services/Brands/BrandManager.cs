using AutoMapper;
using Krop.Business.Features.Brands.Dtos;
using Krop.Business.Features.Brands.Rules;
using Krop.Business.Features.Brands.Validations;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.Business.Services.Brands
{
    public class BrandManager:IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _brandBusinessRules;

        public BrandManager(IBrandRepository brandRepository,IMapper mapper,BrandBusinessRules brandBusinessRules)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
        }

        #region Add
        [ValidationAspect(typeof(CreateBrandValidator))]
        public async Task<IResult> AddAsync(CreateBrandDTO createBrandDTO)
        {
            await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(createBrandDTO.BrandName);//BrandName Rule

            await _brandRepository.AddAsync(
                _mapper.Map<Brand>(createBrandDTO));

            return new SuccessResult();
        }

        [ValidationAspect(typeof(CreateBrandValidator))]
        public async Task<IResult> AddRangeAsync(List<CreateBrandDTO> createBrandDTOs)
        {
            createBrandDTOs.ForEach(async b =>
            {
                await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(b.BrandName);//BrandName Rule
            });

            await _brandRepository.AddRangeAsync(
                _mapper.Map<List<Brand>>(createBrandDTOs));

            return new SuccessResult();
        }
        #endregion
        #region Update
        [ValidationAspect(typeof(UpdateBrandValidator))]
        public async Task<IResult> UpdateAsync(UpdateBrandDTO updateBrandDTO)
        {
            var brand = await _brandBusinessRules.CheckByBrandId(updateBrandDTO.Id);//BrandId Rule

            await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenUpdated(brand.BrandName,updateBrandDTO.BrandName);//BrandName Rule

            brand = _mapper.Map(updateBrandDTO, brand);
            await _brandRepository.UpdateAsync(brand);

            return new SuccessResult();
        }

        [ValidationAspect(typeof(UpdateBrandValidator))]
        public async Task<IResult> UpdateRangeAsync(List<UpdateBrandDTO> updateBrandDTOs)
        {
            updateBrandDTOs.ForEach(async b =>
            {
                var brand = await _brandBusinessRules.CheckByBrandId(b.Id);//BrandId Rule

                await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenUpdated(brand.BrandName, b.BrandName);//BrandName Rule
            });

            await _brandRepository.UpdateRangeAsync(
                _mapper.Map<List<Brand>>(updateBrandDTOs));

            return new SuccessResult();
        }
        #endregion
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var brand = await _brandBusinessRules.CheckByBrandId(id);

            await _brandRepository.DeleteAsync(brand);

            return new SuccessResult();
        }

        public async Task<IResult> DeleteRangeAsync(List<Guid> ids)
        {
            List<Brand> brands = new();
            ids.ForEach(async b =>
            {
                brands.Add(await _brandBusinessRules.CheckByBrandId(b));
            });

            await _brandRepository.DeleteRangeAsync(brands);

            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetBrandDTO>>> GetAllAsync()
        {
           var result = await _brandRepository.GetAllAsync();

            return new SuccessDataResult<IEnumerable<GetBrandDTO>>(
                _mapper.Map<List<GetBrandDTO>>(result));
        }
        public async Task<IDataResult<IEnumerable<GetBrandComboBoxDTO>>> GetAllComboBoxAsync()
        {
            var result = await _brandRepository.GetAllComboBoxAsync();

            return new SuccessDataResult<IEnumerable<GetBrandComboBoxDTO>>(
                _mapper.Map<IEnumerable<GetBrandComboBoxDTO>>(result));
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetBrandDTO>> GetByIdAsync(Guid id)
        {
            var brand = await _brandBusinessRules.CheckByBrandId(id);

            return new SuccessDataResult<GetBrandDTO>(
                _mapper.Map<GetBrandDTO>(brand));
        }

        
        #endregion
    }
}
