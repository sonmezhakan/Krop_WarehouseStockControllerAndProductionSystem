using FluentValidation;
using FluentValidation.Results;
using Krop.Business.Features.Employees.Dtos;
using Krop.Business.Services.Employees;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IValidator<CreateEmployeeDTO> _createEmployeValidator;
        private readonly IValidator<UpdateEmployeeDTO> _uplodateEmployeValidator;

        public EmployeeController(IEmployeeService employeeService,
            IValidator<CreateEmployeeDTO> createEmployeValidator,
            IValidator<UpdateEmployeeDTO> uplodateEmployeValidator)
        {
            _employeeService = employeeService;
            _createEmployeValidator = createEmployeValidator;
            _uplodateEmployeValidator = uplodateEmployeValidator;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateEmployeeDTO createEmployeeDTO, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _createEmployeValidator.ValidateAsync(createEmployeeDTO);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            bool result = await _employeeService.AddAsync(createEmployeeDTO);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeDTO updateEmployeeDTO, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _uplodateEmployeValidator.ValidateAsync(updateEmployeeDTO);
            if (!validationResult.IsValid)
                return Ok(validationResult.Errors.Select(e => e.ErrorMessage));

            bool result = await _employeeService.UpdateAsync(updateEmployeeDTO);

            return result ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _employeeService.GetAllAsync();
            if (result.Count() > 0)
                return Ok(result);
            else if (result.Count() <= 0)
                return NoContent();

            return BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _employeeService.GetByIdAsync(id);

            return result is not null ? Ok(result) : BadRequest(result);
        }
    }
}
