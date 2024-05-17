using FluentValidation;
using FluentValidation.Results;
using Krop.Business.Features.Branches.Dtos;
using Krop.Business.Features.Departments.Dtos;
using Krop.Business.Services.Branches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;
        private readonly IValidator<CreateBranchDTO> _createBranchDTO;
        private readonly IValidator<UpdateBranchDTO> _updateBranchDTO;

        public BranchController(IBranchService branchService,
            IValidator<CreateBranchDTO> createBranchDTO,
            IValidator<UpdateBranchDTO> updateBranchDTO)
        {
            _branchService = branchService;
            _createBranchDTO = createBranchDTO;
            _updateBranchDTO = updateBranchDTO;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBranchDTO createBranchDTO, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _createBranchDTO.ValidateAsync(createBranchDTO);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            bool result = await _branchService.AddAsync(createBranchDTO);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBranchDTO updateBranchDTO, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _updateBranchDTO.ValidateAsync(updateBranchDTO);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            bool result = await _branchService.UpdateAsync(updateBranchDTO);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            bool result = await _branchService.DeleteAsync(id);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _branchService.GetAllAsync();
            if (result.Count() > 0)
                return Ok(result);
            else if (result.Count() <= 0)
                return NoContent();

            return BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _branchService.GetByIdAsync(id);

            return result is not null ? Ok(result) : BadRequest(result);
        }
    }
}
