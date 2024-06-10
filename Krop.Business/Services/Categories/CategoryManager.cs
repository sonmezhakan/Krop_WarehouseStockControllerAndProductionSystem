using AutoMapper;
using Krop.Business.Features.Categories.Rules;
using Krop.Business.Features.Categories.Validations;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Helpers.Caching;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.Categroies;
using Krop.Entities.Entities;

namespace Krop.Business.Services.Categories
{
    public partial class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;

        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules, IUnitOfWork unitOfWork, ICacheService cacheService)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
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

            await CacheAllRemove(new List<string> { "ICategoryService.GetAllAsync" });//CacheClear
            return new SuccessResult();
        }

        public async Task<IResult> AddRangeAsync(List<CreateCategoryDTO> createCategoryDTOs)
        {
            List<string> stringList = createCategoryDTOs.Select(c => c.CategoryName).ToList();

            var result = BusinessRules.Run(await _categoryBusinessRules.CategoryNameRangeCannotBeDuplicatedWhenInserted(stringList));
            if (!result.Success)
                return result;

            List<Category> categories = _mapper.Map<List<Category>>(createCategoryDTOs);
            await _categoryRepository.AddRangeAsync(categories);
            await _unitOfWork.SaveChangesAsync();

            await CacheAllRemove(new List<string> { "ICategoryService.GetAllAsync" });//CacheClear
            return new SuccessResult();
        }
        #endregion
        #region Update

        public async Task<IResult> UpdateAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            var result = await _categoryBusinessRules.CheckByCategoryId(updateCategoryDTO.Id);//Category Rule
            if (!result.Success)
                return result;

            await _categoryBusinessRules.CategoryNameCannotBeDuplicatedWhenUpdated(result.Data.CategoryName, updateCategoryDTO.CategoryName);//CategoryName Rule

            Category category = _mapper.Map(updateCategoryDTO, result.Data);
            await _categoryRepository.UpdateAsync(category);

            await _unitOfWork.SaveChangesAsync();

            await CacheControlAndListItemRemove(result.Data.Id);
            await CacheAllRemove(new List<string> { "ICategoryService.GetAllAsync" });//CacheClear
            return new SuccessResult();
        }

        #endregion
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var result = await _categoryBusinessRules.CheckByCategoryId(id);//Category Rule
            if (!result.Success)
                return result;

            await _categoryRepository.DeleteAsync(result.Data);
            await _unitOfWork.SaveChangesAsync();

            await CacheControlAndListItemRemove(result.Data.Id);
            await CacheAllRemove(new List<string> { "ICategoryService.GetAllAsync" });//CacheClear
            return new SuccessResult();
        }

        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetCategoryDTO>>> GetAllAsync()
        {
            IEnumerable<GetCategoryDTO> categories;
            if (!await _cacheService.IsAdd("ICategoryService.GetAllAsync"))
            {
                var result = await _categoryRepository.GetAllAsync();
                categories = _mapper.Map<IEnumerable<GetCategoryDTO>>(result);
                await _cacheService.Add("ICategoryService.GetAllAsync", categories, 43200);
            }
            else
            {
                var result = await _cacheService.Get<IEnumerable<Category>>("ICategoryService.GetAllAsync");
                categories = _mapper.Map<IEnumerable<GetCategoryDTO>>(result);
            }

            return new SuccessDataResult<IEnumerable<GetCategoryDTO>>(categories);
        }
        public async Task<IDataResult<IEnumerable<GetCategoryComboBoxDTO>>> GetAllComboBoxAsync()
        {
            IEnumerable<GetCategoryComboBoxDTO> categories;
            if (!await _cacheService.IsAdd("ICategoryService.GetAllComboBoxAsync"))
            {
                var result = await _categoryRepository.GetAllComboBoxAsync();
                categories = _mapper.Map<IEnumerable<GetCategoryComboBoxDTO>>(result);
                await _cacheService.Add("ICategoryService.GetAllComboBoxAsync", categories, 43200);
            }
            else
            {
                var result = await _cacheService.Get<IEnumerable<Category>>("ICategoryService.GetAllComboBoxAsync");
                categories = _mapper.Map<IEnumerable<GetCategoryComboBoxDTO>>(result);
            }

            return new SuccessDataResult<IEnumerable<GetCategoryComboBoxDTO>>(categories);
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetCategoryDTO>> GetByCategoryNameAsync(string categoryName)
        {
            GetCategoryDTO getCategoryDTO;
            if (await _cacheService.IsAdd($"ICategoryService.GetAsync"))
            {
                var cacheList = await _cacheService.GetList<GetCategoryDTO>("ICategoryService.GetAsync");
                if (cacheList.Any(x => x.CategoryName == categoryName))
                {
                    getCategoryDTO = cacheList.FirstOrDefault(x => x.CategoryName == categoryName);
                    return new SuccessDataResult<GetCategoryDTO>(getCategoryDTO);
                }
            }
            var result = await _categoryBusinessRules.CheckByCategoryName(categoryName);
            if (!result.Success)
                return new ErrorDataResult<GetCategoryDTO>(result.Status, result.Detail);

            getCategoryDTO = _mapper.Map<GetCategoryDTO>(result.Data);

            await _cacheService.AddList($"ICategoryService.GetAsync", getCategoryDTO, 60);//Cache Added

            return new SuccessDataResult<GetCategoryDTO>(getCategoryDTO);
        }
        public async Task<IDataResult<GetCategoryDTO>> GetByIdAsync(Guid id)
        {
            GetCategoryDTO getCategoryDTO;
            if (await _cacheService.IsAdd($"ICategoryService.GetAsync"))
            {
                var cacheList = await _cacheService.GetList<GetCategoryDTO>("ICategoryService.GetAsync");
                if (cacheList.Any(x => x.Id == id))
                {
                    getCategoryDTO = cacheList.FirstOrDefault(x => x.Id == id);
                    return new SuccessDataResult<GetCategoryDTO>(getCategoryDTO);
                }
            }

            var result = await _categoryBusinessRules.CheckByCategoryId(id);
            if (!result.Success)
                return new ErrorDataResult<GetCategoryDTO>(result.Status, result.Detail);

            getCategoryDTO = _mapper.Map<GetCategoryDTO>(result.Data);

            await _cacheService.AddList($"ICategoryService.GetAsync", getCategoryDTO, 60);//Cache Added

            return new SuccessDataResult<GetCategoryDTO>(getCategoryDTO);
        }

        #endregion
    }
    #region Custom Metot
    public partial class CategoryManager
    {
        private async Task CacheControlAndListItemRemove(Guid id)
        {
            string[] keys = new[] { "ICategoryService.GetAsync" };
            foreach (var key in keys)
            {
                if (await _cacheService.IsAdd(key))
                {
                    var cacheList = await _cacheService.GetList<GetCategoryDTO>(key);
                    if (cacheList.Any(x => x.Id == id))
                    {
                        await _cacheService.ListItemRemove(key, cacheList.FirstOrDefault(x => x.Id == id));
                    }
                }
            }
        }
        private async Task CacheAllRemove(List<string> keys)
        {
            foreach (var key in keys)
            {
                if (await _cacheService.IsAdd(key))
                {
                    await _cacheService.Remove(key);
                }
            }
        }
    }
    #endregion
}
