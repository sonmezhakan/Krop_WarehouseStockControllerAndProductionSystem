using FluentValidation;
using FluentValidation.Results;
using Krop.Business.Features.Departments.Dtos;
using Krop.Business.Services.Deparments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IValidator<CreateDepartmentDTO> _createDepartmentValidator;
        private readonly IValidator<UpdateDepartmentDTO> _updateDepartmentValidator;

        public DepartmentController(IDepartmentService departmentService,
            IValidator<CreateDepartmentDTO> createDepartmentValidator,
            IValidator<UpdateDepartmentDTO> updateDepartmentValidator)
        {
            _departmentService = departmentService;
            _createDepartmentValidator = createDepartmentValidator;
            _updateDepartmentValidator = updateDepartmentValidator;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDepartmentDTO createDepartmentDTO, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _createDepartmentValidator.ValidateAsync(createDepartmentDTO);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            bool result = await _departmentService.AddAsync(createDepartmentDTO);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDepartmentDTO updateDepartmentDTO, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _updateDepartmentValidator.ValidateAsync(updateDepartmentDTO);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            bool result = await _departmentService.UpdateAsync(updateDepartmentDTO);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            bool result = await _departmentService.DeleteAsync(id);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _departmentService.GetAllAsync();
            if (result.Count() > 0)
                return Ok(result);
            else if (result.Count() <= 0)
                return NoContent();

            return BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _departmentService.GetById(id);

            return result is not null ? Ok(result) : BadRequest(result);
        }
    }
}
