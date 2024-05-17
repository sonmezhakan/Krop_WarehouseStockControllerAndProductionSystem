using FluentValidation;
using FluentValidation.Results;
using Krop.Business.Features.Products.Dtos;
using Krop.Business.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IValidator<CreateProductDTO> _createProductValidator;
        private readonly IValidator<UpdateProductDTO> _updateProductValidator;

        public ProductController(IProductService productService,
            IValidator<CreateProductDTO> createProductValidator,
            IValidator<UpdateProductDTO> updateProductValidator)
        {
            _productService = productService;
            _createProductValidator = createProductValidator;
            _updateProductValidator = updateProductValidator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductDTO createProductDTO, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _createProductValidator.ValidateAsync(createProductDTO);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            var result = await _productService.AddAsync(createProductDTO);
            if (result is true)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductDTO updateProductDTO, CancellationToken cancellationToken)
        {
            ValidationResult validatorResult = await _updateProductValidator.ValidateAsync(updateProductDTO);
            if (!validatorResult.IsValid)
                return BadRequest(validatorResult.Errors.Select(e => e.ErrorMessage));

            var result = await _productService.UpdateAsync(updateProductDTO);
            if (result is true)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _productService.DeleteAsync(id);

            if (result is true)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _productService.GetAllAsync();

            if (result is GetProductDTO && result.Count() > 0)
                return Ok(result);
            else if (result.Count() <= 0)
                return NoContent();

            return BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _productService.GetByIdAsync(id);

            return result is not null ? Ok(result) : BadRequest(result);
        }
    }
}
