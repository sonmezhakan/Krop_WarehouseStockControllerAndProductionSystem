using Krop.Business.Services.AppUsers.Logins;
using Krop.DTO.Dtos.AppUsers;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var result = await _loginService.LoginAsync(loginDTO);

            return result.Success ?  Ok(result): BadRequest(result);
        }
    }
}
