using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.DTO.Dtos.Categroies;
using Krop.MVC.Models;
using Krop.ViewModel.ViewModel.Category;
using Microsoft.AspNetCore.Mvc;

namespace Krop.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CategoryController : Controller
    {
        private readonly IWebApiService _webApiService;

        public CategoryController(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("category/getall");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View();
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetCategoryDTO>>>(response);
            return View(resultSuccess.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDTO createCategoryDTO)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("category/add", createCategoryDTO);
            if(!response.IsSuccessStatusCode)
            {
                var result = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);

                TempData["Error"] = result.Detail;
                return View(createCategoryDTO);
            }
            TempData["Success"] = "Eklme İşlemi Başarılı!";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid? id)
        {
            var getallComboBox = await CategorySelectList();
            if (id != Guid.Empty && id != null)
            {
                var result = await GetById((Guid)id);
                if (!result.IsSuccessStatusCode)
                {
                    var getCategoryError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(result);

                    TempData["Error"] = getCategoryError.Detail;
                    return View(new UpdateCategoryVM
                    {
                        GetCategoryDTO = getallComboBox
                    });
                }
                var getCategory = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<UpdateCategoryDTO>>(result);
                return View(new UpdateCategoryVM
                {
                    GetCategoryDTO = getallComboBox,
                    UpdateCategoryDTO = getCategory.Data
                });
            }
            return View(new UpdateCategoryVM
            {
                GetCategoryDTO = getallComboBox
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryVM updateCategoryVM)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("category/update", updateCategoryVM.UpdateCategoryDTO);
            if(!response.IsSuccessStatusCode)
            {
                var result = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = result.Detail;

                return View(new UpdateCategoryVM
                {
                    GetCategoryDTO = await CategorySelectList(),
                    UpdateCategoryDTO = updateCategoryVM.UpdateCategoryDTO
            });
            }
            TempData["Success"] = "Güncelleme İşlemi Başarılı!";
            return RedirectToAction("Update","Category", new {id =updateCategoryVM.UpdateCategoryDTO.Id});
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var getallComboBox = await CategorySelectList();

            return View(new DeleteCategoryVM
            {
                GetCategoryDTO = getallComboBox,
                Id = id ?? null
            });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"category/Delete/{id}");
            if(!response.IsSuccessStatusCode)
            {
                var result = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = result.Detail;
            }
            else
            {
                TempData["Success"] = "Silme İşlemi Başarılı!";
            }
            return RedirectToAction("Delete", "Category", new { id = id });
        }

        private async Task<List<GetCategoryDTO>> CategorySelectList()
        {
            HttpResponseMessage responseGetAllComboBox = await _webApiService.httpClient.GetAsync("category/getallcombobox");
            if (!responseGetAllComboBox.IsSuccessStatusCode)
            {
                var result = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(responseGetAllComboBox);
                TempData["error"] = result.Detail;
                return null;
            }
            var getallComboBox = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetCategoryDTO>>>(responseGetAllComboBox);
            return getallComboBox.Data;
        }
        private async Task<HttpResponseMessage> GetById(Guid id)
        {
            
            HttpResponseMessage responseGetCategory = await _webApiService.httpClient.GetAsync($"category/GetById/{id}"); 
            return responseGetCategory;
        }
    }
}
