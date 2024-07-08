using Krop.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Krop.MVC.Controllers
{
    [Route("Cikis")]
    public class SignOutController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public SignOutController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await _signInManager.SignOutAsync();
            Response.Cookies.Delete("authToken");
            return RedirectToAction("Index", "Login");
        }
    }
}
