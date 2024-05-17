using FluentValidation;
using FluentValidation.Results;
using Krop.Business.Features.Customers.Dtos;
using Krop.Business.Services.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IValidator<CreateCustomerDTO> _createCustomerValidator;
        private readonly IValidator<UpdateCustomerDTO> _updateCustomerValidator;

        public CustomerController(ICustomerService customerService,
            IValidator<CreateCustomerDTO> createCustomerValidator,
            IValidator<UpdateCustomerDTO> updateCustomerValidator)
        {
            _customerService = customerService;
            _createCustomerValidator = createCustomerValidator;
            _updateCustomerValidator = updateCustomerValidator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCustomerDTO createCustomerDTO, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _createCustomerValidator.ValidateAsync(createCustomerDTO);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            bool result = await _customerService.AddAsync(createCustomerDTO);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerDTO updateCustomerDTO, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _updateCustomerValidator.ValidateAsync(updateCustomerDTO);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            bool result = await _customerService.UpdateAsync(updateCustomerDTO);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            bool result = await _customerService.DeleteAsync(id);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _customerService.GetAllAsync();
            if (result.Count() > 0)
                return Ok(result);
            else if (result.Count() <= 0)
                return NoContent();

            return BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _customerService.GetByIdAsync(id);
            return result is not null ? Ok(result) : BadRequest(result);
        }
    }
}
