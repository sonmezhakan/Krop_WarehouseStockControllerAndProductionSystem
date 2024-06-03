using Krop.Business.Services.Categories;
using Krop.DTO.Dtos.Categroies;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryDTO createCategoryDTO, CancellationToken cancellationToken)
        {
            var result = await _categoryService.AddAsync(createCategoryDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddRange([FromBody] List<CreateCategoryDTO> createCategoryDTOs, CancellationToken cancellationToken)
        {
            var result = await _categoryService.AddRangeAsync(createCategoryDTOs);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDTO updateCategoryDTO, CancellationToken cancellationToken)
        {
            var result = await _categoryService.UpdateAsync(updateCategoryDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _categoryService.DeleteAsync(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet]//Genel Liste
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetAllAsync();

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet]//ComboBox için oluşturulmuş liste
        public async Task<IActionResult> GetAllComboBox(CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetAllAsync();

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetByIdAsync(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
