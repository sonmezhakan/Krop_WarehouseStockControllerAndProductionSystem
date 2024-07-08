using Krop.Business.Services.AppUsers;
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
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO,CancellationToken cancellationToken)
        {
            var result = await _authService.LoginAsync(loginDTO);
            if (!result.Success)
                return BadRequest(result);

            var token = await _authService.CreateAccessToken(result.Data);
            if (token.Success)
                return Ok(token);


            return BadRequest(token);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> ResetPasswordTokenEmailSender(Guid Id, CancellationToken cancellationToken)
        {
            var result = await _authService.ResetPasswordMailSenderAsync(Id);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{email}")]
        public async Task<IActionResult> ResetPasswordTokenEmailSender(string email, CancellationToken cancellationToken)
        {
            var result = await _authService.ResetPasswordWinFormEmailSenderAsync(email);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{email}")]
        public async Task<IActionResult> ResetPasswordEmailSender(string email, CancellationToken cancellationToken)
        {
            var result = await _authService.ResetPasswordEmailSenderAsync(email);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] MailResetPasswordDTO resetPasswordDTO, CancellationToken cancellationToken)
        {
            var result = await _authService.ResetPasswordAsync(resetPasswordDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost]
        public async Task<IActionResult> IdResetPassword([FromBody] IdResetPasswordDTO ıdResetPasswordDTO, CancellationToken cancellationToken)
        {
            var result = await _authService.IdResetPasswordAsync(ıdResetPasswordDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{Id}/{token}")]
        public async Task<IActionResult> Confirmation(Guid Id, string token)
        {
            var result = await _authService.ConfirmationAsync(Id, token);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
