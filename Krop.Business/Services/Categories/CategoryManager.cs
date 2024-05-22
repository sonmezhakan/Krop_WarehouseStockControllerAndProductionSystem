using AutoMapper;
using Krop.Business.Features.Categories.Dtos;
using Krop.Business.Features.Categories.Rules;
using Krop.Business.Features.Categories.Validations;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.Business.Services.Categories
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper,CategoryBusinessRules categoryBusinessRules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
        }

        #region Add
        [ValidationAspect(typeof(CreateCategoryValidator))]
        public async Task<IResult> AddAsync(CreateCategoryDTO createCategoryDTO)
        {
            //Rule
            await _categoryBusinessRules.CategoryNameCannotBeDuplicatedWhenInserted(createCategoryDTO.CategoryName);

            Category category = _mapper.Map<Category>(createCategoryDTO);

            await _categoryRepository.AddAsync(category);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(CreateCategoryListValidator))]
        public async Task<IResult> AddRangeAsync(List<CreateCategoryDTO> createCategoryDTOs)
        {
            List<string> stringList = createCategoryDTOs.Select(c => c.CategoryName).ToList();
            //Rule
            await _categoryBusinessRules.CategoryNameRangeCannotBeDuplicatedWhenInserted(stringList);

            List <Category> categories = _mapper.Map<List<Category>>(createCategoryDTOs);
            await _categoryRepository.AddRangeAsync(categories);

            return new SuccessResult();
        }
        #endregion
        #region Update
        [ValidationAspect(typeof(UpdateCategoryValidator))]
        public async Task<IResult> UpdateAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            var category =await _categoryBusinessRules.CheckByCategoryId(updateCategoryDTO.Id);//Category Rule

            await _categoryBusinessRules.CategoryNameCannotBeDuplicatedWhenUpdated(category.CategoryName, updateCategoryDTO.CategoryName);//CategoryName Rule

            category = _mapper.Map(updateCategoryDTO, category);
            await _categoryRepository.UpdateAsync(category);

            return new SuccessResult();
        }

        /*[ValidationAspect(typeof(UpdateCategoryValidator))]
        public async Task<IResult> UpdateRangeAsync(List<UpdateCategoryDTO> updatCategoryDTOs)
        {
            updatCategoryDTOs.ForEach(async c =>
            {
                var category = await _categoryBusinessRules.CheckByCategoryId(c.Id);//Category Rule

                await _categoryBusinessRules.CategoryNameCannotBeDuplicatedWhenUpdated(category.CategoryName, c.CategoryName);//Rule
            });

            List<Category> categories = _mapper.Map<List<Category>>(updatCategoryDTOs);
            await _categoryRepository.UpdateRangeAsync(categories);

            return new SuccessResult();
        }*/
        #endregion
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var category = await _categoryBusinessRules.CheckByCategoryId(id);//Category Rule

            await _categoryRepository.DeleteAsync(category);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteRangeAsync(List<Guid> ids)
        {
            List<Category> categories = new();
            ids.ForEach(async c =>
            {
                var category = await _categoryBusinessRules.CheckByCategoryId(c);//Category Rule

                categories.Add(category);
            });

            await _categoryRepository.DeleteRangeAsync(categories);
            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetCategoryDTO>>> GetAllAsync()
        {
            var result = await _categoryRepository.GetAllAsync();

            return new SuccessDataResult<IEnumerable<GetCategoryDTO>>(
                _mapper.Map<IEnumerable<GetCategoryDTO>>(result));
        }
        public async Task<IDataResult<IEnumerable<GetCategoryComboBoxDTO>>> GetAllComboBoxAsync()
        {
            var result = await _categoryRepository.GetAllComboBoxAsync();

            return new SuccessDataResult<IEnumerable<GetCategoryComboBoxDTO>>(
                _mapper.Map<IEnumerable<GetCategoryComboBoxDTO>>(result));
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetCategoryDTO>> GetByCategoryNameAsync(string categoryName)
        {
            var category = await _categoryBusinessRules.CheckByCategoryName(categoryName);//Category Rule

            return new SuccessDataResult<GetCategoryDTO>(
                _mapper.Map<GetCategoryDTO>(category));
        }

        public async Task<IDataResult<GetCategoryDTO>> GetByIdAsync(Guid id)
        {
            var category = await _categoryBusinessRules.CheckByCategoryId(id);//Category Rule

            return new SuccessDataResult<GetCategoryDTO>(
               _mapper.Map<GetCategoryDTO>(category));
        }
 
        #endregion
    }

}
