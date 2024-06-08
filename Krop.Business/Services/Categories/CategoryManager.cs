using AutoMapper;
using Krop.Business.Features.Categories.Rules;
using Krop.Business.Features.Categories.Validations;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.UnitOfWork;
using Krop.DTO.Dtos.Categroies;
using Krop.Entities.Entities;

namespace Krop.Business.Services.Categories
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper,CategoryBusinessRules categoryBusinessRules,IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
            _unitOfWork = unitOfWork;
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
            
            return new SuccessResult();
        }
        
        public async Task<IResult> AddRangeAsync(List<CreateCategoryDTO> createCategoryDTOs)
        {
            List<string> stringList = createCategoryDTOs.Select(c => c.CategoryName).ToList();

            var result = BusinessRules.Run(await _categoryBusinessRules.CategoryNameRangeCannotBeDuplicatedWhenInserted(stringList));
            if (!result.Success)
                return result;

            List <Category> categories = _mapper.Map<List<Category>>(createCategoryDTOs);
            await _categoryRepository.AddRangeAsync(categories);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }
        #endregion
        #region Update
        
        public async Task<IResult> UpdateAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            var result =await _categoryBusinessRules.CheckByCategoryId(updateCategoryDTO.Id);//Category Rule
            if (!result.Success)
                return result;

            await _categoryBusinessRules.CategoryNameCannotBeDuplicatedWhenUpdated(result.Data.CategoryName, updateCategoryDTO.CategoryName);//CategoryName Rule
                     
           Category category = _mapper.Map(updateCategoryDTO,result.Data);
            await _categoryRepository.UpdateAsync(category);

            await _unitOfWork.SaveChangesAsync();
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
            var result = await _categoryBusinessRules.CheckByCategoryId(id);//Category Rule
            if (!result.Success)
                return result;

            await _categoryRepository.DeleteAsync(result.Data);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult();
        }

        /*public async Task<IResult> DeleteRangeAsync(List<Guid> ids)
        {
            List<Category> categories = new();
            ids.ForEach(async c =>
            {
                var category = await _categoryBusinessRules.CheckByCategoryId(c);//Category Rule

                categories.Add(category);
            });

            await _categoryRepository.DeleteRangeAsync(categories);
            return new SuccessResult();
        }*/
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
            var result = await _categoryBusinessRules.CheckByCategoryName(categoryName);
            if (!result.Success)
                return new ErrorDataResult<GetCategoryDTO>(result.Status,result.Detail);

            return new SuccessDataResult<GetCategoryDTO>(
                _mapper.Map<GetCategoryDTO>(result.Data));
        }

        public async Task<IDataResult<GetCategoryDTO>> GetByIdAsync(Guid id)
        {
            var result = await _categoryBusinessRules.CheckByCategoryId(id);
            if (!result.Success)
                return new ErrorDataResult<GetCategoryDTO>(result.Status, result.Detail);

            return new SuccessDataResult<GetCategoryDTO>(
               _mapper.Map<GetCategoryDTO>(result.Data));
        }
 
        #endregion
    }

}
