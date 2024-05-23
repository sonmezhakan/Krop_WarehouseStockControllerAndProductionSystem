using Krop.Business.Features.Brands.Dtos;
using Krop.Business.Services.Brands;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandDTO createBrandDTO, CancellationToken cancellationToken)
        {
            var result = await _brandService.AddAsync(createBrandDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandDTO updateBrandDTO, CancellationToken cancellationToken)
        {
            var result = await _brandService.UpdateAsync(updateBrandDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _brandService.DeleteAsync(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _brandService.GetAllAsync();

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComboBox(CancellationToken cancellationToken)
        {
            var result = await _brandService.GetAllComboBoxAsync();

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _brandService.GetByIdAsync(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}