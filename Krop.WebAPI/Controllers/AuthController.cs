using Krop.Business.Services.Auths;
using Krop.DTO.Dtos.Auths;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var result = await _authService.LoginAsync(loginDTO);
            if (!result.Success)
                return BadRequest(result);

            var token = await _authService.CreateAccessToken(result.Data);
            if (token.Success)
                return Ok(token);


            return BadRequest(token);
        }
        [HttpGet("{email}")]
        public async Task<IActionResult> ResetPasswordEmailSender(string email)
        {
            var result = await _authService.ResetPasswordWinFormEmailSenderAsync(email);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
        {
            var result = await _authService.ResetPasswordAsync(resetPasswordDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
