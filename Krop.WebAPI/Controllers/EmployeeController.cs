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

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateEmployeeDTO createEmployeeDTO, CancellationToken cancellationToken)
        {
            var result = await _employeeService.AddAsync(createEmployeeDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeDTO updateEmployeeDTO, CancellationToken cancellationToken)
        {
            var result = await _employeeService.UpdateAsync(updateEmployeeDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _employeeService.GetAllAsync();

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _employeeService.GetByIdAsync(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
