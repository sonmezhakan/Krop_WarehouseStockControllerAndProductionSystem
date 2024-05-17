using FluentValidation;
using FluentValidation.Results;
using Krop.Business.Features.Brands.Dtos;
using Krop.Business.Features.Products.Dtos;
using Krop.Business.Services.Brands;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IValidator<CreateBrandDTO> _createBrandValidator;
        private readonly IValidator<UpdateBrandDTO> _updateBrandValidator;

        public BrandController(IBrandService brandService,
            IValidator<CreateBrandDTO> createBrandValidator,
            IValidator<UpdateBrandDTO> updateBrandValidator)
        {
            _brandService = brandService;
            _createBrandValidator = createBrandValidator;
            _updateBrandValidator = updateBrandValidator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandDTO createBrandDTO, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _createBrandValidator.ValidateAsync(createBrandDTO);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            bool result = await _brandService.AddAsync(createBrandDTO);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandDTO updateBrandDTO, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _updateBrandValidator.ValidateAsync(updateBrandDTO);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            bool result = await _brandService.UpdateAsync(updateBrandDTO);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            bool result = await _brandService.DeleteAsync(id);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _brandService.GetAllAsync();

            if (result.Count() > 0)
                return Ok(result);
            else if (result.Count() <= 0)
                return NoContent();

            return BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _brandService.GetByIdAsync(id);

            return result is not null ? Ok(result) : BadRequest(result);
        }
    }
}