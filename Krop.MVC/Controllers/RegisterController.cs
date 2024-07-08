using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.DTO.Dtos.AppUsers;
using Microsoft.AspNetCore.Mvc;

namespace Krop.MVC.Controllers
{
    [Route("Kayit")]
    public class RegisterController : Controller
    {
        private readonly IWebApiService _webApiService;

        public RegisterController(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "Administrator" });
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateAppUserDTO createAppUserDTO)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("account/register",createAppUserDTO);
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["RegisterError"] = resultError.Detail;
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
