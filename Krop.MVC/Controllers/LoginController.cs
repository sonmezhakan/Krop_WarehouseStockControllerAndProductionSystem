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

        public LoginController(IWebApiService webApiService,SignInManager<AppUser> signInManager)
        {
            _webApiService = webApiService;
            _signInManager = signInManager;
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
