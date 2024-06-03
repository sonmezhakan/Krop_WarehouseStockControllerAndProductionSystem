using Krop.Business.Services.AppUserRoles;
using Krop.DTO.Dtos.AppUserRoles;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppUserRoleController : ControllerBase
    {
        private readonly IAppUserRoleService _appUserRoleService;

        public AppUserRoleController(IAppUserRoleService appUserRoleService)
        {
            _appUserRoleService = appUserRoleService;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAppUserRoleDTO createAppUserRole, CancellationToken cancellationToken)
        {
            var result = await _appUserRoleService.AddAsync(createAppUserRole);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAppUserRoleDTO updateAppUserRoleDTO, CancellationToken cancellationToken)
        {
            var result = await _appUserRoleService.UpdateAsync(updateAppUserRoleDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _appUserRoleService.DeleteAsync(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _appUserRoleService.GetAllAsync();

            return result.Success ? Ok(result): BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _appUserRoleService.GetByIdAsync(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
