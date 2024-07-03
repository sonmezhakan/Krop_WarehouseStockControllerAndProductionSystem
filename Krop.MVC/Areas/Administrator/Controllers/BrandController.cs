using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.DTO.Dtos.Brands;
using Krop.ViewModel.ViewModel.Brands;
using Microsoft.AspNetCore.Mvc;

namespace Krop.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class BrandController : Controller
    {
        private readonly IWebApiService _webApiService;

        public BrandController(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        [HttpGet]
        [Route("Marka/Liste")]
        public async Task<IActionResult> Index()
        {
            return View(await BrandList());
        }
        [HttpGet]
        [Route("Marka/Ekle")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [Route("Marka/Ekle")]
        public async Task<IActionResult> Create(CreateBrandDTO createBrandDTO)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("brand/add", createBrandDTO);
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View(createBrandDTO);
            }
            TempData["Success"] = "Marka Ekleme İşlemi Başarılı!";
            return View();
        }
        [HttpGet]
        [Route("Marka/Guncelle/{id?}")]
        public async Task<IActionResult> Update(Guid? id)
        {
            var getBrandSelectList = await GetBrandSelectList();
            if (id != null && id != Guid.Empty)
            {
                var result = await GetById((Guid)id);
                if (!result.IsSuccessStatusCode)
                {
                    var getError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(result);
                    TempData["Error"] = getError.Detail;
                    return View(new UpdateBrandVM
                    {
                        GetBrandComboBoxDTO = getBrandSelectList
                    });
                }
                var getSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<UpdateBrandDTO>>(result);
                return View(new UpdateBrandVM
                {
                    GetBrandComboBoxDTO = getBrandSelectList,
                    UpdateBrandDTO = getSuccess.Data
                });
            }
            return View(new UpdateBrandVM
            {
                GetBrandComboBoxDTO = getBrandSelectList
            });
        }
        [HttpPost]
        [Route("Marka/Guncelle")]
        public async Task<IActionResult> Update(UpdateBrandVM updateBrandVM)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("brand/update", updateBrandVM.UpdateBrandDTO);
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View(new UpdateBrandVM
                {
                    GetBrandComboBoxDTO = await GetBrandSelectList(),
                    UpdateBrandDTO = updateBrandVM.UpdateBrandDTO
                });
            }
            TempData["Success"] = "Güncelleme İşlemi Başarılı!";
            return RedirectToAction("Update", "Brand", new { id = updateBrandVM.UpdateBrandDTO.Id });
        }
        [HttpGet("Marka/Sil/{id?}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            return View(new DeleteBrandVM
            {
                GetBrandComboBoxDTO = await GetBrandSelectList(),
                Id = id ?? null
            });
        }
        [HttpPost("Marka/Sil/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"brand/delete/{id}");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return RedirectToAction("Delete", "Brand", new { id = id });
            }

            TempData["Success"] = "Silme İşlemi Başarılı!";
            return RedirectToAction("Delete","Brand");
        }

        private async Task<List<GetBrandDTO>> BrandList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("brand/getall");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetBrandDTO>>>(response);
            return resultSuccess.Data;
        }
        private async Task<List<GetBrandComboBoxDTO>> GetBrandSelectList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("brand/getallcombobox");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetBrandComboBoxDTO>>>(response);
            return resultSuccess.Data;
        }
        private async Task<HttpResponseMessage> GetById(Guid id) => await _webApiService.httpClient.GetAsync($"brand/getById/{id}");
    }
}
