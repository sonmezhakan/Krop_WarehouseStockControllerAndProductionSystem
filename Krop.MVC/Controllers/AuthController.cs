using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.DTO.Dtos.Auths;
using Krop.ViewModel.ViewModels.Auths;
using Microsoft.AspNetCore.Mvc;

namespace Krop.MVC.Controllers
{
    [Route("Auth")]
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
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"Auth/Confirmation/{id}/{token}");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["ActivationError"] = resultError.Detail;
                return View();
            }
            else
            {
                TempData["ActivationSuccess"] = "Aktivasyon Başarılı! Yönlendiriliyorsunuz!";
                return RedirectToAction("Index", "Login");
            }
            
        }
        [HttpGet("Sifre-Unuttum")]
        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }
        [HttpPost("Sifre-Unuttum")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM forgotPasswordVM)
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"Auth/ResetPasswordEmailSender/{forgotPasswordVM.Email}");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["ForgotPasswordError"] = resultError.Detail;
                return View();
            }
            else
            {
                TempData["ForgotPasswordSuccess"] = "Şifre Sıfırlama Maili Gönderilmiştir!";
                return View();
            }
            
        }
        [HttpGet("Sifre-Sifirlama/{id}/{token}")]
        public async Task<IActionResult> ResetPassword(Guid id, string token)
        {

            if(id== null || id == Guid.Empty || token == null)
            {
                return RedirectToAction("ForgotPassword", "Auth");
            }
            return View();
        }
        [HttpPost("Sifre-Sifirlama/{id}/{token}")]
        public async Task<IActionResult> ResetPassword(IdResetPasswordDTO ıdResetPasswordDTO)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync($"Auth/IdResetPassword", ıdResetPasswordDTO);
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["ResetPasswordError"] = resultError.Detail;
                return View();
            }
            TempData["ResetPasswordSuccess"] = "Şifre Güncelleme İşlemi Başarılı!";
            return View();
        }
    }
}
