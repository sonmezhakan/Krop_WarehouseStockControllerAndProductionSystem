using FluentValidation;
using FluentValidation.Results;
using Krop.Business.Features.AppUserRoles.Dtos;
using Krop.Business.Features.Suppliers.Dtos;
using Krop.Business.Services.AppUserRoles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserRoleController : ControllerBase
    {
        private readonly IAppUserRoleService _appUserRoleService;
        private readonly IValidator<CreateAppUserRoleDTO> _createAppUserRoleValidator;
        private readonly IValidator<UpdateAppUserRoleDTO> _updateAppUserRoleValidator;

        public AppUserRoleController(IAppUserRoleService appUserRoleService,
            IValidator<CreateAppUserRoleDTO> createAppUserRoleValidator,
            IValidator<UpdateAppUserRoleDTO> updateAppUserRoleValidator)
        {
            _appUserRoleService = appUserRoleService;
            _createAppUserRoleValidator = createAppUserRoleValidator;
            _updateAppUserRoleValidator = updateAppUserRoleValidator;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAppUserRoleDTO createAppUserRole, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _createAppUserRoleValidator.ValidateAsync(createAppUserRole);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            bool result = await _appUserRoleService.AddAsync(createAppUserRole);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAppUserRoleDTO updateAppUserRoleDTO, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _updateAppUserRoleValidator.ValidateAsync(updateAppUserRoleDTO);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            bool result = await _appUserRoleService.UpdateAsync(updateAppUserRoleDTO);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            bool result = await _appUserRoleService.DeleteAsync(id);

            return result ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _appUserRoleService.GetAllAsync();
            if (result.Count() > 0)
                return Ok(result);
            else if (result.Count() <= 0)
                return NoContent();

            return BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _appUserRoleService.GetByIdAsync(id);

            return result is not null ? Ok(result) : BadRequest(result);
        }
    }
}
