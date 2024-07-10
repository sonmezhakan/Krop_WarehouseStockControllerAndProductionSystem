using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.DTO.Dtos.Branches;
using Krop.DTO.Dtos.Productions;
using Krop.DTO.Dtos.ProductReceipts;
using Krop.DTO.Dtos.Products;
using Krop.ViewModel.ViewModels.Productions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Krop.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Route("Uretim")]
    public class ProductionController : Controller
    {
        private readonly IWebApiService _webApiService;

        public ProductionController(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        [HttpGet("Listesi")]
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"production/getall/{User.FindFirstValue(ClaimTypes.NameIdentifier)}");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View();
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetProductionListDTO>>>(response);
            return View(resultSuccess.Data);
        }
        [HttpGet("Ekle/{productId?}")]
        public async Task<IActionResult> Create(Guid? productId)
        {
            if (productId != null && productId != Guid.Empty)
            {
                return View(new CreateProductionVM
                {
                    GetBranchComboBoxDTOs = await BranchSelectList(),
                    GetProductComboBoxDTOs = await ProductSelectList(),
                    GetProductReceiptListDTOs = await ProductReceiptList((Guid)productId),
                    ProduceProductId = productId
                });
            }
            return View(new CreateProductionVM
            {
                GetBranchComboBoxDTOs = await BranchSelectList(),
                GetProductComboBoxDTOs = await ProductSelectList()
            });
        }
        [HttpPost("Ekle/{productId?}")]
        public async Task<IActionResult> Create(CreateProductionVM createProductionVM)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("production/add", createProductionVM.CreateProductionDTO);
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
            }
            else
            {
                TempData["Success"] = "Üretim Ekleme İşlemi Başarılı!";
            }
            return View(new CreateProductionVM
            {
                GetBranchComboBoxDTOs = await BranchSelectList(),
                GetProductComboBoxDTOs = await ProductSelectList(),
                GetProductReceiptListDTOs = await ProductReceiptList((Guid)createProductionVM.CreateProductionDTO.ProductId),
                CreateProductionDTO = createProductionVM.CreateProductionDTO,
                ProduceProductId = createProductionVM.CreateProductionDTO.ProductId  
            });
        }
        [HttpGet("Guncelle/{id}")]
        public async Task<IActionResult> Update(Guid id)
        {
            if (id != null && id != Guid.Empty)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"production/GetById/{id}/{User.FindFirstValue(ClaimTypes.NameIdentifier)}");
                if (!response.IsSuccessStatusCode)
                {
                    var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                    TempData["Error"] = resultError.Detail;
                    return View(new UpdateProductionVM
                    {
                        GetBranchComboBoxDTOs = await BranchSelectList(),
                        GetProductComboBoxDTOs = await ProductSelectList()
                    });
                }
                var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<UpdateProductionDTO>>(response);
                return View(new UpdateProductionVM
                {
                    GetBranchComboBoxDTOs = await BranchSelectList(),
                    GetProductComboBoxDTOs = await ProductSelectList(),
                    UpdateProductionDTO = resultSuccess.Data,
                    GetProductReceiptListDTOs = await ProductReceiptList(resultSuccess.Data.ProductId)
                });
            }
            return View(new UpdateProductionVM
            {
                GetBranchComboBoxDTOs = await BranchSelectList(),
                GetProductComboBoxDTOs = await ProductSelectList()
            });
        }
        [HttpPost("Guncelle/{id}")]
        public async Task<IActionResult> Update(UpdateProductionVM updateProductionVM)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("production/update", updateProductionVM.UpdateProductionDTO);
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View(new UpdateProductionVM
                {
                    GetBranchComboBoxDTOs = await BranchSelectList(),
                    GetProductComboBoxDTOs = await ProductSelectList(),
                    UpdateProductionDTO = updateProductionVM.UpdateProductionDTO,
                    GetProductReceiptListDTOs = await ProductReceiptList(updateProductionVM.UpdateProductionDTO.ProductId),
                });
            }
            TempData["Success"] = "Üretim Güncelleme İşlemi Başarılı!";
            return RedirectToAction("Update", "Production", new { id = updateProductionVM.UpdateProductionDTO.Id });
        }
        [HttpGet("Sil/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"production/delete/{id}/{User.FindFirstValue(ClaimTypes.NameIdentifier)}");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
            }
            else
            {
                TempData["Success"] = "Üretim Silme İşlemi Başarılı!";
            }
            return RedirectToAction("Index", "Production");
        }
        private async Task<List<GetBranchComboBoxDTO>> BranchSelectList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("branch/getallcombobox");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetBranchComboBoxDTO>>>(response);
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
        private async Task<List<GetProductReceiptListDTO>> ProductReceiptList(Guid productId)
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"productReceipt/getall/{productId}");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetProductReceiptListDTO>>>(response);
            return resultSuccess.Data;

        }
    }
}
