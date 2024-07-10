using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.DTO.Dtos.Brands;
using Krop.DTO.Dtos.Categroies;
using Krop.DTO.Dtos.Products;
using Krop.ViewModel.ViewModel.Products;
using Microsoft.AspNetCore.Mvc;

namespace Krop.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Route("Urun")]
    public class ProductController : Controller
    {
        private readonly IWebApiService _webApiService;

        public ProductController(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        
       [HttpGet("Listele")]
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("product/getall");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View();
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetProductListDTO>>>(response);
            return View(resultSuccess.Data);
        }
        //[HttpGet("Ekle")]
        public async Task<IActionResult> Create()
        {
            return View(new CreateProductVM
            {
                GetBrandComboBoxDTO = await BrandSelectList(),
                GetCategoryDTO = await CategorySelectList()
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM createProductVM)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("product/add", createProductVM.CreateProductDTO);
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View(new CreateProductVM
                {
                    GetBrandComboBoxDTO = await BrandSelectList(),
                    GetCategoryDTO = await CategorySelectList()
                });
            }
            TempData["Success"] = "Ürün Ekleme İşlemi Başarılı!";
            return View(new CreateProductVM
            {
                GetBrandComboBoxDTO = await BrandSelectList(),
                GetCategoryDTO = await CategorySelectList(),
                CreateProductDTO = createProductVM.CreateProductDTO
            });
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
                    return View(new UpdateProductVM
                    {
                        GetBrandComboBoxDTO = await BrandSelectList(),
                        GetCategoryDTO = await CategorySelectList(),
                        GetProductComboBoxDTO = await ProductSelectList()
                    });
                }
                var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<UpdateProductDTO>>(response);
                return View(new UpdateProductVM
                {
                    GetBrandComboBoxDTO = await BrandSelectList(),
                    GetCategoryDTO = await CategorySelectList(),
                    GetProductComboBoxDTO = await ProductSelectList(),
                    UpdateProductDTO = resultSuccess.Data
                });
            }
            return View(new UpdateProductVM
            {
                GetBrandComboBoxDTO = await BrandSelectList(),
                GetCategoryDTO = await CategorySelectList(),
                GetProductComboBoxDTO = await ProductSelectList()
            });
        }
        [HttpPost("Guncelle/{id?}")]
        public async Task<IActionResult> Update(UpdateProductVM updateProductVM)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("product/update", updateProductVM.UpdateProductDTO);
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View(new UpdateProductVM
                {
                    GetBrandComboBoxDTO = await BrandSelectList(),
                    GetCategoryDTO = await CategorySelectList(),
                    GetProductComboBoxDTO = await ProductSelectList(),
                    UpdateProductDTO = updateProductVM.UpdateProductDTO
                });
            }
            TempData["Success"] = "Ürün Güncelleme İşlemi Başarılı!";
            return RedirectToAction("Update", "Product", new {id=updateProductVM.UpdateProductDTO.Id});
        }
        [HttpGet("Sil/{id?}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            return View(new DeleteProductVM
            {
                GetProductComboBoxDTO = await ProductSelectList(),
                Id = id ?? null
            });
        }
        [HttpPost("Sil/{id?}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"product/delete/{id}");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
            }
            else
            {
                TempData["Success"] = "Ürün Silme İşlemi Başarılı!";
            }
            return RedirectToAction("Delete", "Product", new { id = id });
        }
        private async Task<List<GetCategoryDTO>> CategorySelectList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("category/getallcombobox");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetCategoryDTO>>>(response);
            return resultSuccess.Data;
        }
        private async Task<List<GetBrandComboBoxDTO>> BrandSelectList()
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
        private async Task<List<GetProductComboBoxDTO>> ProductSelectList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("product/getallcombobox");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetProductComboBoxDTO>>>(response);
            return resultSuccess.Data;
        }
        private async Task<HttpResponseMessage> GetById(Guid id) => await _webApiService.httpClient.GetAsync($"product/getbyId/{id}");
        
        
    }
}
