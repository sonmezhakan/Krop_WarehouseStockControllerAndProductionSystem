using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.DTO.Dtos.AppUserRoles;
using Krop.DTO.Dtos.AppUsers;
using Krop.ViewModel.ViewModels.AppUsers;
using Microsoft.AspNetCore.Mvc;

namespace Krop.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Route("Kullanici")]
    public class AppUserController : Controller
    {
        private readonly IWebApiService _webApiService;
        public AppUserController(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        [HttpGet("Listele")]
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("account/getall");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View();
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetAppUserDTO>>>(response);
            TempData["Action"] = "Index";
            return View(resultSuccess.Data);
        }
        [HttpGet("Ekle")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost("Ekle")]
        public async Task<IActionResult> Create(CreateAppUserDTO createAppUserDTO)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("Account/register",createAppUserDTO);
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View();
            }
            TempData["Success"] = "Kullanıcı Oluşturudu!";
            return View();
        }
        [HttpGet("Guncelle/{id?}")]
        public async Task<IActionResult> Update(Guid? id)
        {
            TempData["Action"] = "Update";
            if (id != null && id != Guid.Empty)
            {
                HttpResponseMessage response = await GetById((Guid)id);
                if(!response.IsSuccessStatusCode)
                {
                    var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                    TempData["Error"] = resultError.Detail;
                    return View(new UpdateAppUserVM
                    {
                        GetAppUserComboBoxDTOs = await AppUserSelectList(),
                        GetAppUserRoleDTOs = await AppUserRoleSelectList(),
                    });
                }
                var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<UpdateAppUserDTO>>(response);
                return View(new UpdateAppUserVM
                {
                    GetAppUserComboBoxDTOs = await AppUserSelectList(),
                    GetAppUserRoleDTOs = await AppUserRoleSelectList(),
                    UpdateAppUserDTO = resultSuccess.Data
                });
            }
            return View(new UpdateAppUserVM
            {
                GetAppUserComboBoxDTOs = await AppUserSelectList(),
                GetAppUserRoleDTOs = await AppUserRoleSelectList()
            });
        }
        [HttpPost("Guncelle/{id?}")]
        public async Task<IActionResult> Update(UpdateAppUserVM updateAppUserVM)
        {
            if(updateAppUserVM.UpdateAppUserDTO != null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("account/update", updateAppUserVM.UpdateAppUserDTO);
                if (!response.IsSuccessStatusCode)
                {
                    var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                    TempData["ErrorUserInformation"] = resultError.Detail;
                    return View(new UpdateAppUserVM
                    {
                        GetAppUserComboBoxDTOs = await AppUserSelectList(),
                        GetAppUserRoleDTOs = await AppUserRoleSelectList(),
                        UpdateAppUserDTO = updateAppUserVM.UpdateAppUserDTO
                    });
                }
                TempData["SuccessUserInformation"] = "Kullanıcı Güncelleme İşlemi Başarılı!";
            }
            if(updateAppUserVM.UpdateAppUserPasswordDTO.Password != null)
            {
                HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("account/updatePassword", new UpdateAppUserPasswordDTO { Id = updateAppUserVM.UpdateAppUserDTO.Id, Password = updateAppUserVM.UpdateAppUserPasswordDTO.Password});
                if(!response.IsSuccessStatusCode)
                {
                    var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                    TempData["ErrorUserPassword"] = resultError.Detail;
                    return View(new UpdateAppUserVM
                    {
                        GetAppUserComboBoxDTOs = await AppUserSelectList(),
                        GetAppUserRoleDTOs = await AppUserRoleSelectList(),
                        UpdateAppUserDTO = updateAppUserVM.UpdateAppUserDTO
                    });
                }
                TempData["SuccessUserPassword"] = "Kullanıcı Şifre Güncelleme İşlemi Başarılı!";
            }
            
            return RedirectToAction("Update", "AppUser", new { id = updateAppUserVM.UpdateAppUserDTO.Id });
        }
        [HttpGet("Aktivasyon-Maili-Gonder/{id}")]
        public async Task<IActionResult> ConfirmationMailSender(Guid id)
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"Account/ConfirmationMailSender/{id}");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return TempData["Action"] != null && TempData["Action"] == "Update" ?
                    RedirectToAction(TempData["Action"].ToString(), "AppUser", new { id = id }) :
                    RedirectToAction(TempData["Action"].ToString(), "AppUser");
            }
            TempData["Success"] ="Aktivasyon Maili Gönderilmiştir!";
            return TempData["Action"] != null && TempData["Action"] == "Update" ?
                    RedirectToAction(TempData["Action"].ToString(), "AppUser", new { id = id }) :
                    RedirectToAction(TempData["Action"].ToString(), "AppUser");
        }
        [HttpGet("Sifre-Sifirlama-Maili-Gonder/{id}")]
        public async Task<IActionResult> ResetPasswordMailSender(Guid id)
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"Account/ResetPasswordMailSender/{id}");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel> (response);
                TempData["Error"] = resultError.Detail;
                return TempData["Action"] != null && TempData["Action"] == "Update" ?
                    RedirectToAction(TempData["Action"].ToString(), "AppUser", new { id = id }) :
                    RedirectToAction(TempData["Action"].ToString(), "AppUser");
            }
            TempData["Success"] = "Şifre Sıfırlama Maili Gönderilmiştir!";
            return TempData["Action"] != null && TempData["Action"] == "Update" ?
                    RedirectToAction(TempData["Action"].ToString(), "AppUser", new { id = id }) :
                    RedirectToAction(TempData["Action"].ToString(), "AppUser");
        }
        private async Task<List<GetAppUserComboBoxDTO>> AppUserSelectList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("Account/GetAllComboBox");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetAppUserComboBoxDTO>>>(response);
            return resultSuccess.Data;
        }

        private async Task<List<GetAppUserRoleDTO>> AppUserRoleSelectList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("appUserRole/GetAll");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetAppUserRoleDTO>>>(response);
            return resultSuccess.Data;
        }
        private async Task<HttpResponseMessage> GetById(Guid id) => await _webApiService.httpClient.GetAsync($"account/getbyid/{id}");
    }
}
