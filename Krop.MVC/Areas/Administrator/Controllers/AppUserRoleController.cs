using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.DTO.Dtos.AppUserRoles;
using Krop.ViewModel.ViewModels.AppUserRoles;
using Microsoft.AspNetCore.Mvc;

namespace Krop.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Route("Yetki")]
    public class AppUserRoleController : Controller
    {
        private readonly IWebApiService _webApiService;

        public AppUserRoleController(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        [HttpGet("Listele")]
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("AppUserRole/GetAll");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View();
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetAppUserRoleDTO>>>(response);
            return View(resultSuccess.Data);
        }
        [HttpGet("Ekle")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost("Ekle")]
        public async Task<IActionResult> Create(CreateAppUserRoleDTO createAppUserRoleDTO)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("AppUserRole/add", createAppUserRoleDTO);
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View();
            }
            TempData["Success"] = "Yetki Ekleme İşlemi Başarılı!";
            return View();
        }
        [HttpGet("Guncelle/{id?}")]
        public async Task<IActionResult> Update(Guid? id)
        {
            if(id != null && id != Guid.Empty)
            {
                HttpResponseMessage response = await GetById((Guid)id);
                if(!response.IsSuccessStatusCode)
                {
                    var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                    TempData["Error"] = resultError.Detail;
                    return View(new UpdateAppUserRoleVM
                    {
                        GetAppUserRoleDTOs = await AppUserRoleSelectList()
                    });
                }
                var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<UpdateAppUserRoleDTO>>(response);
                return View(new UpdateAppUserRoleVM
                {
                    GetAppUserRoleDTOs = await AppUserRoleSelectList(),
                    UpdateAppUserRoleDTO = resultSuccess.Data
                });
             }
            return View(new UpdateAppUserRoleVM
            {
                GetAppUserRoleDTOs = await AppUserRoleSelectList()
            });
        }
        [HttpPost("Guncelle/{id?}")]
        public async Task<IActionResult> Update(UpdateAppUserRoleVM updateAppUserRoleVM)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("AppUserRole/Update", updateAppUserRoleVM.UpdateAppUserRoleDTO);
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View(new UpdateAppUserRoleVM
                {
                    GetAppUserRoleDTOs = await AppUserRoleSelectList(),
                    UpdateAppUserRoleDTO = updateAppUserRoleVM.UpdateAppUserRoleDTO
                });
            }
            TempData["Success"] = "Yetki Güncelleme İşlemi Başarılı!";
            return RedirectToAction("Update", "AppUserRole", new {id=updateAppUserRoleVM.UpdateAppUserRoleDTO.Id});
        }
        [HttpGet("Sil/{id?}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return View(new DeleteAppUserRoleVM
            {
                GetAppUserRoleDTOs = await AppUserRoleSelectList(),
                Id = id
            });
        }
        [HttpPost("Sil/{id?}")]
        public async Task<IActionResult> Delete(DeleteAppUserRoleVM deleteAppUserRoleVM)
        {
            HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"AppUserRole/Delete/{deleteAppUserRoleVM.Id}");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
            }
            else {
                TempData["Success"] = "Yetki Silme İşlemi Başarılı!";
            }
            return RedirectToAction("Delete","AppUserRole",new { id=deleteAppUserRoleVM.Id});
        }
        private async Task<List<GetAppUserRoleDTO>> AppUserRoleSelectList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("AppUserRole/GetAll");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetAppUserRoleDTO>>>(response);
            return resultSuccess.Data;
        }
        private async Task<HttpResponseMessage> GetById(Guid id) => await _webApiService.httpClient.GetAsync($"AppUserRole/GetById/{id}");
    }
}
