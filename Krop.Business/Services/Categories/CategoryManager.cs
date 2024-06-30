using AutoMapper;
using Krop.Business.Features.Categories.Constants;
using Krop.Business.Features.Categories.Rules;
using Krop.Business.Features.Categories.Validations;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Helpers.CacheHelpers;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.Categroies;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Services.Categories
{
    public partial class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheHelper _cacheHelper;

        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules, IUnitOfWork unitOfWork, ICacheHelper cacheHelper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
            _unitOfWork = unitOfWork;
            _cacheHelper = cacheHelper;
        }

        #region Add
        [ValidationAspect(typeof(CreateCategoryValidator))]
        public async Task<IResult> AddAsync(CreateCategoryDTO createCategoryDTO)
        {
            var result = BusinessRules.Run(await _categoryBusinessRules.CategoryNameCannotBeDuplicatedWhenInserted(createCategoryDTO.CategoryName));
            if (!result.Success)
                return result;

            Category category = _mapper.Map<Category>(createCategoryDTO);

            await _categoryRepository.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();

            await _cacheHelper.RemoveAsync(new string[] { CategoryCacheKeys.GetAllAsync });//CacheClear
            return new SuccessResult();
        }

        [ValidationAspect(typeof(List<CreateCategoryListValidator>))]
        public async Task<IResult> AddRangeAsync(List<CreateCategoryDTO> createCategoryDTOs)
        {
            List<string> stringList = createCategoryDTOs.Select(c => c.CategoryName).ToList();

            var result = BusinessRules.Run(await _categoryBusinessRules.CategoryNameRangeCannotBeDuplicatedWhenInserted(stringList));
            if (!result.Success)
                return result;

            List<Category> categories = _mapper.Map<List<Category>>(createCategoryDTOs);
            await _categoryRepository.AddRangeAsync(categories);
            await _unitOfWork.SaveChangesAsync();

            await _cacheHelper.RemoveAsync(new string[]
            {
                CategoryCacheKeys.GetAllAsync ,
                CategoryCacheKeys.GetAllComboBoxAsync});//CacheClear
            return new SuccessResult();
        }
        #endregion
        #region Update
        [ValidationAspect(typeof(UpdateCategoryValidator))]
        public async Task<IResult> UpdateAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            var result = await _categoryRepository.GetAsync(x => x.Id == updateCategoryDTO.Id);
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, CategoryMessages.CategoryNotFound);

            var businessRule = BusinessRules.Run(await _categoryBusinessRules.CategoryNameCannotBeDuplicatedWhenUpdated(result.CategoryName, updateCategoryDTO.CategoryName));
            if(!businessRule.Success)
                return businessRule;

            Category category = _mapper.Map(updateCategoryDTO, result);
            await _categoryRepository.UpdateAsync(category);

            await _unitOfWork.SaveChangesAsync();

            await _cacheHelper.RemoveAsync(new string[]
            {
                CategoryCacheKeys.GetAllAsync,
                CategoryCacheKeys.GetAllComboBoxAsync,
                $"{CategoryCacheKeys.GetByIdAsync}{updateCategoryDTO.Id}" });//CacheClear
            return new SuccessResult();
        }

        #endregion
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var result = await _categoryRepository.GetAsync(x=>x.Id == id);
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, CategoryMessages.CategoryNotFound);

            await _categoryRepository.DeleteAsync(result);
            await _unitOfWork.SaveChangesAsync();

            await _cacheHelper.RemoveAsync(new string[]
            {
                CategoryCacheKeys.GetAllAsync,
                CategoryCacheKeys.GetAllComboBoxAsync,
                $"{CategoryCacheKeys.GetByIdAsync}{id}" });//CacheClear
            return new SuccessResult();
        }

        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetCategoryDTO>>> GetAllAsync()
        {
            IEnumerable<GetCategoryDTO>? categories = await _cacheHelper.GetOrAddListAsync(CategoryCacheKeys.GetAllAsync,
                async () =>
                {
                    var result = await _categoryRepository.GetAllAsync();
                    return result is null ? null : _mapper.Map<IEnumerable<GetCategoryDTO>>(result);
                },
                60
                );

            return new SuccessDataResult<IEnumerable<GetCategoryDTO>>(categories);
        }
        public async Task<IDataResult<IEnumerable<GetCategoryComboBoxDTO>>> GetAllComboBoxAsync()
        {
            IEnumerable<GetCategoryComboBoxDTO>? categories = await _cacheHelper.GetOrAddListAsync(CategoryCacheKeys.GetAllComboBoxAsync,
                async () =>
                {
                    var result = await _categoryRepository.GetAllComboBoxAsync();
                    return result is null ? null : _mapper.Map<IEnumerable<GetCategoryComboBoxDTO>>(result);
                },
                60);

            return new SuccessDataResult<IEnumerable<GetCategoryComboBoxDTO>>(categories);
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetCategoryDTO>> GetByIdAsync(Guid id)
        {
            GetCategoryDTO? getCategoryDTO = await _cacheHelper.GetOrAddAsync(
                $"{CategoryCacheKeys.GetByIdAsync}{id}",
                async () =>
            {
                var result = await _categoryRepository.GetAsync(x => x.Id == id);
                return result is null ? null : _mapper.Map<GetCategoryDTO>(result);
            },
            60);

            return getCategoryDTO is null ?
                 new ErrorDataResult<GetCategoryDTO>(StatusCodes.Status404NotFound, CategoryMessages.CategoryNotFound) :
                 new SuccessDataResult<GetCategoryDTO>(getCategoryDTO);
        }

        #endregion
    }
}
