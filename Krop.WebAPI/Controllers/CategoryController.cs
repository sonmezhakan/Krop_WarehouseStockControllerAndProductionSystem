using FluentValidation;
using FluentValidation.Results;
using Krop.Business.Features.Categories.Dtos;
using Krop.Business.Services.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IValidator<CreateCategoryDTO> _createCategoryValidator;
        private readonly IValidator<UpdateCategoryDTO> _updateCategoryValidator;

        public CategoryController(ICategoryService categoryService,
            IValidator<CreateCategoryDTO> createCategoryValidator,
            IValidator<UpdateCategoryDTO> updateCategoryValidator)
        {
            _categoryService = categoryService;
            _createCategoryValidator = createCategoryValidator;
            _updateCategoryValidator = updateCategoryValidator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryDTO createCategoryDTO, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _createCategoryValidator.ValidateAsync(createCategoryDTO);
            if (!validationResult.IsValid)
                return BadRequest(new { Success = false, Errors = validationResult.Errors.Select(e => e.ErrorMessage) });

            bool result = await _categoryService.AddAsync(createCategoryDTO);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDTO updateCategoryDTO, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _updateCategoryValidator.ValidateAsync(updateCategoryDTO);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            bool result = await _categoryService.UpdateAsync(updateCategoryDTO);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _categoryService.DeleteAsync(id);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetAllAsync();

            if (result.Count() > 0)
                return Ok(result);
            else if (result.Count() <= 0)
                return NoContent();

            return BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetByIdAsync(id);

            return result is not null ? Ok(result) : BadRequest(result);
        }
    }
}
