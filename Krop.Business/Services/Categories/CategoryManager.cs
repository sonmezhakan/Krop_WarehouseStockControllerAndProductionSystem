using AutoMapper;
using Krop.Business.Features.Categories.Dtos;
using Krop.Business.Features.Categories.ExceptionHelpers;
using Krop.Business.Features.Categories.Rules;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Krop.Business.Services.Categories
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;
        private readonly CategoryExceptionHelper _categoryExceptionHelper;

        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper,CategoryBusinessRules categoryBusinessRules,CategoryExceptionHelper categoryExceptionHelper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
            _categoryExceptionHelper = categoryExceptionHelper;
        }

        #region Add
        public async Task<bool> AddAsync(CreateCategoryDTO createCategoryDTO)
        {
            //Rule
            await _categoryBusinessRules.CategoryNameCannotBeDuplicatedWhenInserted(createCategoryDTO.CategoryName);

            Category category = _mapper.Map<Category>(createCategoryDTO);

            return await _categoryRepository.AddAsync(category);
        }

        public async Task<bool> AddRangeAsync(List<CreateCategoryDTO> createCategoryDTOs)
        {
            //Rule
            createCategoryDTOs.ForEach(async c =>
            {
                await _categoryBusinessRules.CategoryNameCannotBeDuplicatedWhenInserted(c.CategoryName);
            });

            List<Category> categories = _mapper.Map<List<Category>>(createCategoryDTOs);

            return await _categoryRepository.AddRangeAsync(categories);
        }
        #endregion
        #region Update
        public async Task<bool> UpdateAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            Category category = await _categoryRepository.FindAsync(updateCategoryDTO.Id);
            if (category is null)
                _categoryExceptionHelper.ThrowCategoryNotFoundException();//Eğer kategori yok ise hata fırlat

            await _categoryBusinessRules.CategoryNameCannotBeDuplicatedWhenUpdated(category.CategoryName, updateCategoryDTO.CategoryName);//Rule

            category = _mapper.Map(updateCategoryDTO, category);

            return await _categoryRepository.UpdateAsync(category);
        }

        public async Task<bool> UpdateRangeAsync(List<UpdateCategoryDTO> updatCategoryDTOs)
        {
            foreach (UpdateCategoryDTO item in updatCategoryDTOs)
            {
                Category category = await _categoryRepository.FindAsync(item.Id);
                if (category is null)
                    _categoryExceptionHelper.ThrowCategoryNotFoundException();//Eğer kategori yok ise hata fırlat

                await _categoryBusinessRules.CategoryNameCannotBeDuplicatedWhenUpdated(category.CategoryName, item.CategoryName);//Rule

            }

            List<Category> categories = _mapper.Map<List<Category>>(updatCategoryDTOs);

            return await _categoryRepository.UpdateRangeAsync(categories);
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteAsync(Guid id)
        {
            Category category = _categoryRepository.Find(id);
            if (category is null)
                _categoryExceptionHelper.ThrowCategoryNotFoundException();//Eğer kategori yok ise hata fırlat

            return await _categoryRepository.DeleteAsync(category);
        }

        public async Task<bool> DeleteRangeAsync(List<Guid> ids)
        {
            List<Category> categories = new();
            ids.ForEach(async c =>
            {
                Category category = await _categoryRepository.FindAsync(c);
                 if(category is null)
                    _categoryExceptionHelper.ThrowCategoryNotFoundException();//Eğer kategori yok ise hata fırlat

                categories.Add(category);
            });

            return await _categoryRepository.DeleteRangeAsync(categories);
        }
        #endregion
        #region Listed
        public async Task<IEnumerable<GetCategoryDTO>> GetAllAsync()
        {
            var result = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<GetCategoryDTO>>(result);
        }
        #endregion
        #region Search
        public async Task<GetCategoryDTO> GetByCategoryNameAsync(string categoryName)
        {
            Category category = await _categoryRepository.GetAsync(c => c.CategoryName == categoryName);
            if (category is null)
                _categoryExceptionHelper.ThrowCategoryNotFoundException();//Eğer kategori yok ise hata fırlat

            return _mapper.Map<GetCategoryDTO>(category);
        }

        public async Task<GetCategoryDTO> GetByIdAsync(Guid id)
        {
            Category category = await _categoryRepository.FindAsync(id);
            if (category is null)
                _categoryExceptionHelper.ThrowCategoryNotFoundException();//Eğer kategori yok ise hata fırlat

            return _mapper.Map<GetCategoryDTO>(category);
        }
        #endregion
    }

}
