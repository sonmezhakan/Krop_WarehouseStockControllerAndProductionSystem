using AutoMapper;
using Krop.Business.Features.Brands.Rules;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.Brands;
using Krop.Entities.Entities;

namespace Krop.Business.Services.Brands
{
    public class BrandManager:IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _brandBusinessRules;
        private readonly IUnitOfWork _unitOfWork;

        public BrandManager(IBrandRepository brandRepository,IMapper mapper,BrandBusinessRules brandBusinessRules,IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
            _unitOfWork = unitOfWork;
        }

        #region Add
        
        public async Task<IResult> AddAsync(CreateBrandDTO createBrandDTO)
        {
            var result = BusinessRules.Run(await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(createBrandDTO.BrandName));
            if (!result.Success)
                return result;

            await _brandRepository.AddAsync(
                _mapper.Map<Brand>(createBrandDTO));

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }

        /*[ValidationAspect(typeof(CreateBrandValidator))]
        public async Task<IResult> AddRangeAsync(List<CreateBrandDTO> createBrandDTOs)
        {
            createBrandDTOs.ForEach(async b =>
            {
                await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(b.BrandName);//BrandName Rule
            });

            await _brandRepository.AddRangeAsync(
                _mapper.Map<List<Brand>>(createBrandDTOs));

            return new SuccessResult();
        }*/
        #endregion
        #region Update
        
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
            return new SuccessResult();
        }

       /* [ValidationAspect(typeof(UpdateBrandValidator))]
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
        }*/
        #endregion
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var getBrand = await _brandBusinessRules.CheckByBrandId(id);
            if (!getBrand.Success)
                return getBrand;

            await _brandRepository.DeleteAsync(getBrand.Data);

            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }

        /*public async Task<IResult> DeleteRangeAsync(List<Guid> ids)
        {
            List<Brand> brands = new();
            ids.ForEach(async b =>
            {
                brands.Add(await _brandBusinessRules.CheckByBrandId(b));
            });

            await _brandRepository.DeleteRangeAsync(brands);

            return new SuccessResult();
        }*/
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
            var result = await _brandBusinessRules.CheckByBrandId(id);
            if (!result.Success)
                return new ErrorDataResult<GetBrandDTO>(result.Status,result.Detail);

            return new SuccessDataResult<GetBrandDTO>(
                _mapper.Map<GetBrandDTO>(result.Data));
        }

        
        #endregion
    }
}
