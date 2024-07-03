using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.DTO.Dtos.Departments;
using Krop.ViewModel.ViewModel.Departments;
using Microsoft.AspNetCore.Mvc;

namespace Krop.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Route("Departman")]
    public class DepartmentController : Controller
    {
        private readonly IWebApiService _webApiService;

        public DepartmentController(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        [HttpGet("Listele")]
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("department/getall");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View();
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetDepartmentDTO>>>(response);
            return View(resultSuccess.Data);
        }
        [HttpGet("Ekle")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost("Ekle")]
        public async Task<IActionResult> Create(CreateDepartmentDTO createDepartmentDTO)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("department/add", createDepartmentDTO);
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View(createDepartmentDTO);
            }
            TempData["Success"] = "Departman Ekleme İşlemi Başarılı!";
            return View();
        }
        [HttpGet("Guncelle/{id?}")]
        public async Task<IActionResult> Update(Guid? id)
        {
            if(id != null && id != Guid.Empty)
            {
                HttpResponseMessage response = await GetById((Guid)id);
                if (!response.IsSuccessStatusCode)
                {
                    var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                    TempData["Error"] = resultError.Detail;
                    return View(new UpdateDepartmentVM
                    {
                        GetDepartmentComboBoxDTO = await GetSelectList()
                });
                }
                var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<UpdateDepartmentDTO>>(response);
                return View(new UpdateDepartmentVM
                {
                    GetDepartmentComboBoxDTO = await GetSelectList(),
                    UpdateDepartmentDTO = resultSuccess.Data
                });
            }
            return View(new UpdateDepartmentVM
            {
                GetDepartmentComboBoxDTO = await GetSelectList()
            });
        }
        [HttpPost("Guncelle/{id?}")]
        public async Task<IActionResult> Update(UpdateDepartmentVM updateDepartmentVM)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("department/update", updateDepartmentVM.UpdateDepartmentDTO);
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View(new UpdateDepartmentVM
                {
                    GetDepartmentComboBoxDTO = await GetSelectList(),
                    UpdateDepartmentDTO = updateDepartmentVM.UpdateDepartmentDTO
                });
            }
            TempData["Success"] = "Departman Güncelleme İşlemi Başarılı!";
            return RedirectToAction("Update", "Department", new { id = updateDepartmentVM.UpdateDepartmentDTO.Id });
        }
        [HttpGet("Sil/{id?}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            return View(new DeleteDepartmentVM
            {
                GetDepartmentComboBoxDTO = await GetSelectList(),
                Id = id?? null
            });
        }
        [HttpPost("Sil/{id?}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"department/delete/{id}");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
            }
            else
            {
                TempData["Success"] = "Departman Silme İşlemi Başarılı!";
            }

            return RedirectToAction("Delete","Department", new {id = id});
        }
        private async Task<HttpResponseMessage> GetById(Guid id) => await _webApiService.httpClient.GetAsync($"department/getbyId/{id}");
        private async Task<List<GetDepartmentComboBoxDTO>> GetSelectList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("department/getallcombobox");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetDepartmentComboBoxDTO>>>(response);
            return resultSuccess.Data;
        }
    }
}
