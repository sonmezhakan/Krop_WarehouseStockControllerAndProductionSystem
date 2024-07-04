using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.DTO.Dtos.Branches;
using Krop.ViewModel.ViewModel.Branches;
using Microsoft.AspNetCore.Mvc;

namespace Krop.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Route("Sube")]
    public class BranchController : Controller
    {
        private readonly IWebApiService _webApiService;

        public BranchController(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        [HttpGet("Listele")]
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("branch/getall");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View();
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetBranchDTO>>>(response);
            return View(resultSuccess.Data);
        }
        [HttpGet("Ekle")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost("Ekle")]
        public async Task<IActionResult> Create(CreateBranchDTO createBranchDTO)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("branch/add", createBranchDTO);
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View(createBranchDTO);
            }
            TempData["Success"] = "Şube Ekleme İşlemi Başarılı!";
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
                    return View(new UpdateBranchVM
                    {
                        GetBranchComboBoxDTO = await BranchSelectList()
                    });
                }
                var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<UpdateBranchDTO>>(response);
                return View(new UpdateBranchVM
                {
                    GetBranchComboBoxDTO = await BranchSelectList(),
                    UpdateBranchDTO = resultSuccess.Data
                });
            }
            return View(new UpdateBranchVM
            {
                GetBranchComboBoxDTO = await BranchSelectList()
            });
        }
        [HttpPost("Guncelle/{id?}")]
        public async Task<IActionResult> Update(UpdateBranchVM updateBranchVM)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("branch/update", updateBranchVM.UpdateBranchDTO);
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View(new UpdateBranchVM
                {
                    GetBranchComboBoxDTO = await BranchSelectList(),
                    UpdateBranchDTO = updateBranchVM.UpdateBranchDTO
                });
            }
            TempData["Success"] = "Güncelleme İşlemi Başarılı!";
            return RedirectToAction("Update","Branch",new {id=updateBranchVM.UpdateBranchDTO.Id});
        }
        [HttpGet("Sil/{id?}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            return View(new DeleteBranchVM
            {
                GetBranchComboBoxDTO = await BranchSelectList(),
                Id = id ?? null
            });
        }
        [HttpPost("Sil/{id?}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"branch/delete/{id}");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
            }
            else
            {
                TempData["Success"] = "Şube Silme İşlemi Başarılı!";
            }
            return RedirectToAction("Delete", "Branch", new {id =id});
        }
        private async Task<List<GetBranchComboBoxDTO>> BranchSelectList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("branch/getallcombobox");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetBranchComboBoxDTO>>>(response);
            return resultSuccess.Data;
        }
        private async Task<HttpResponseMessage> GetById(Guid id) => await _webApiService.httpClient.GetAsync($"branch/getbyId/{id}");
    }
}
