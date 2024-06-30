using Krop.Business.Features.AppUsers.Validations;
using Krop.Business.Services.AppUsers;
using Krop.DTO.Dtos.AppUsers;
using Krop.DTO.Dtos.Auths;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AccountController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        [HttpGet]
        public async Task<IActionResult> Confirmation(Guid Id,string token)
        {
            var result  = await _appUserService.ConfirmationAsync(Id, token);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateAppUserDTO createAppUserDTO)
        {
            var result = await _appUserService.AddAsync(createAppUserDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateAppUserDTO updateAppUserDTO)
        {
            var result = await _appUserService.UpdateAsync(updateAppUserDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdateAppUserPasswordDTO updateAppUserPasswordDTO)
        {
            var result = await _appUserService.UpdatePasswordAsync(updateAppUserPasswordDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _appUserService.GetAllAsync();

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComboBox()
        {
            var result = await _appUserService.GetAllComboBoxAsync();

            return result.Success ? Ok(result):BadRequest(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> ConfirmationMailSender(Guid Id)
        {
            var result = await _appUserService.ConfirmationMailSenderAsync(Id);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> ResetPasswordMailSender(Guid Id)
        {
            var result = await _appUserService.ResetPasswordMailSenderAsync(Id);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> ResetPassword([FromBody]UpdateAppUserPasswordDTO updateAppUserPasswordDTO)
        {
            var result = await _appUserService.UpdatePasswordAsync(updateAppUserPasswordDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var result = await _appUserService.GetByIdAsync(Id);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> UserUpdateRole([FromBody]UpdateAppUserUpdateRoleDTO updateAppUserUpdateRoleDTO)
        {
            var result = await _appUserService.UpdateAppUserRoleAsync(updateAppUserUpdateRoleDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
