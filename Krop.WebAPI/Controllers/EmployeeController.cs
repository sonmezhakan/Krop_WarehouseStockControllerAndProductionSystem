using Krop.Business.Services.Employees;
using Krop.DTO.Dtos.Employees;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
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
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _employeeService.GetAllAsync();

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComboBox(CancellationToken cancellationToken)
        {
            var result = await _employeeService.GetAllComboBoxAsync();

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid Id, CancellationToken cancellationToken)
        {
            var result = await _employeeService.GetByIdAsync(Id);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdCart(Guid Id, CancellationToken cancellationToken)
        {
            var result = await _employeeService.GetByIdCartAsync(Id);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
