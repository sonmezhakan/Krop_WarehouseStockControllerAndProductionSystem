using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.DTO.Dtos.Auths;
using Microsoft.AspNetCore.Mvc;

namespace Krop.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IWebApiService _webApiService;

        public AuthController(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        [HttpGet("Aktivasyon/{id}/{token}")]
        public async Task<IActionResult> Confirmation(Guid id,string token)
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"Account/Confirmation/{id}/{token}");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["ActivationError"] = resultError.Detail;
                return View();
            }
            TempData["ActivationSuccess"] = "Aktivasyon Başarılı! Yönlendiriliyorsunuz!";
            await Task.Delay(3000);
            return RedirectToAction("Index", "Login");
        }
        [HttpGet("Sifre-Sifirlama/{id}/{token}")]
        public async Task<IActionResult> ResetPassword(Guid id, string token)
        {
            return View();
        }
        [HttpPost("Sifre-Sifirlama/{id}/{token}")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            return View();
        }
    }
}
