using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.DTO.Dtos.Auths;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Krop.MVC.Controllers
{
    [Route("Giris")]
    public class LoginController : Controller
    {
        private readonly IWebApiService _webApiService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(IWebApiService webApiService,SignInManager<AppUser> signInManager,UserManager<AppUser> userManager)
        {
            _webApiService = webApiService;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public  IActionResult Index()
        {     
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "Administrator" });
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDTO loginDTO)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("Auth/Login", loginDTO);
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["LoginError"] = resultError.Detail;
                
                return View();
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<LoginResponseDTO>>(response);

            await _signInManager.PasswordSignInAsync(loginDTO.UserName, loginDTO.Password, false, false);

            var user = await _userManager.FindByNameAsync(loginDTO.UserName);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
    };

            await _signInManager.SignInWithClaimsAsync(user, isPersistent: false, claims);
            var cookieOptions = new CookieOptions
             {
                 HttpOnly = true,
                 Secure = true,
                 SameSite = SameSiteMode.Strict,
                 Expires = DateTime.Now.AddMinutes(600)
             };
             Response.Cookies.Append("authToken",resultSuccess.Data.Token,cookieOptions);

            return RedirectToAction("Index", "Home", new {area="Administrator"});
        }
        
    }
}
