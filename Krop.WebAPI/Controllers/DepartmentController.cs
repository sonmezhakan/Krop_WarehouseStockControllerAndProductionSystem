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

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDepartmentDTO createDepartmentDTO, CancellationToken cancellationToken)
        {
            var result = await _departmentService.AddAsync(createDepartmentDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDepartmentDTO updateDepartmentDTO, CancellationToken cancellationToken)
        {
            var result = await _departmentService.UpdateAsync(updateDepartmentDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _departmentService.DeleteAsync(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _departmentService.GetAllAsync();

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _departmentService.GetById(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
