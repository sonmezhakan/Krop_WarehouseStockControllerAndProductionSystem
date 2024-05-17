using FluentValidation;
using FluentValidation.Results;
using Krop.Business.Features.Suppliers.Dtos;
using Krop.Business.Services.Suppliers;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly IValidator<CreateSupplierDTO> _createSupplierValidator;
        private readonly IValidator<UpdateSupplierDTO> _updateSupplierValidator;

        public SupplierController(ISupplierService supplierService,
            IValidator<CreateSupplierDTO> createSupplierValidator,
            IValidator<UpdateSupplierDTO> updateSupplierValidator)
        {
            _supplierService = supplierService;
            _createSupplierValidator = createSupplierValidator;
            _updateSupplierValidator = updateSupplierValidator;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSupplierDTO createSupplierDTO, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _createSupplierValidator.ValidateAsync(createSupplierDTO);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            bool result = await _supplierService.AddAsync(createSupplierDTO);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSupplierDTO updateSupplierDTO, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _updateSupplierValidator.ValidateAsync(updateSupplierDTO);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            bool result = await _supplierService.UpdateAsync(updateSupplierDTO);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            bool result = await _supplierService.DeleteAsync(id);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _supplierService.GetAllAsync();
            if (result.Count() > 0)
                return Ok(result);
            else if (result.Count() <= 0)
                return NoContent();

            return BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _supplierService.GetByIdAsync(id);

            return result is not null ? Ok(result) : BadRequest(result);
        }
    }
}
