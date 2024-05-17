using AutoMapper;
using Krop.Business.Features.Branches.Dtos;
using Krop.Business.Features.Brands.Dtos;
using Krop.Business.Features.Brands.ExceptionHelpers;
using Krop.Business.Features.Brands.Rules;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Krop.Business.Services.Brands
{
    public class BrandManager:IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _brandBusinessRules;
        private readonly BrandExceptionHelper _brandExceptionHelper;

        public BrandManager(IBrandRepository brandRepository,IMapper mapper,BrandBusinessRules brandBusinessRules,BrandExceptionHelper brandExceptionHelper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
            _brandExceptionHelper = brandExceptionHelper;
        }
      
        #region Add
        public async Task<bool> AddAsync(CreateBrandDTO createBrandDTO)
        {
            await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(createBrandDTO.BrandName);//BrandName Rule

            Brand brand = _mapper.Map<Brand>(createBrandDTO);

            return await _brandRepository.AddAsync(brand);
        }

        public async Task<bool> AddRangeAsync(List<CreateBrandDTO> createBrandDTOs)
        {
            createBrandDTOs.ForEach(async b =>
            {
                await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(b.BrandName);//BrandName Rule
            });
            List<Brand> brands = _mapper.Map<List<Brand>>(createBrandDTOs);
            return await _brandRepository.AddRangeAsync(brands);
        }
        #endregion
        #region Update
        public async Task<bool> UpdateAsync(UpdateBrandDTO updateBrandDTO)
        {
            Brand brand = await _brandRepository.FindAsync(updateBrandDTO.Id);
            if (brand is null)
                _brandExceptionHelper.ThrowBrandNotFound();

            await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenUpdated(brand.BrandName,updateBrandDTO.BrandName);//BrandName Rule

            brand = _mapper.Map(updateBrandDTO, brand);

            return await _brandRepository.UpdateAsync(brand);
        }

        public async Task<bool> UpdateRangeAsync(List<UpdateBrandDTO> updateBrandDTOs)
        {
            updateBrandDTOs.ForEach(async b =>
            {
                Brand brand = await _brandRepository.FindAsync(b.Id);
                if (brand is null)
                    _brandExceptionHelper.ThrowBrandNotFound();

                await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenUpdated(brand.BrandName, b.BrandName);
            });

            List<Brand> brands = _mapper.Map<List<Brand>>(updateBrandDTOs);

            return await _brandRepository.UpdateRangeAsync(brands);
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteAsync(Guid id)
        {
            Brand brand = await _brandRepository.FindAsync(id);
            if (brand is null)
                _brandExceptionHelper.ThrowBrandNotFound();

            return await _brandRepository.DeleteAsync(brand);
        }

        public async Task<bool> DeleteRangeAsync(List<Guid> ids)
        {
            List<Brand> brands = new();
            ids.ForEach(async b =>
            {
                Brand brand = await _brandRepository.FindAsync(b);
                if (brand is null)
                    _brandExceptionHelper.ThrowBrandNotFound();

                brands.Add(brand);
            });

            return await _brandRepository.DeleteRangeAsync(brands);
        }
        #endregion
        #region Listed
        public async Task<IEnumerable<GetBrandDTO>> GetAllAsync()
        {
           var result = await _brandRepository.GetAllAsync();

            return _mapper.Map<List<GetBrandDTO>>(result);
        }
        #endregion
        #region Search
        public async Task<GetBrandDTO> GetByIdAsync(Guid id)
        {
            Brand brand = await _brandRepository.FindAsync(id);
            if(brand is null)
                _brandExceptionHelper.ThrowBrandNotFound();

            return _mapper.Map<GetBrandDTO>(brand);
        }
        #endregion
    }
}
