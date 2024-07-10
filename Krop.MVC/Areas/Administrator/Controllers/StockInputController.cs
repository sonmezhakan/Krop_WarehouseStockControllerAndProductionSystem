using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.DTO.Dtos.Branches;
using Krop.DTO.Dtos.Products;
using Krop.DTO.Dtos.StockInputs;
using Krop.DTO.Dtos.Suppliers;
using Krop.ViewModel.ViewModels.StockInputs;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Krop.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Route("Stok-Girisi")]
    public class StockInputController : Controller
    {
        private readonly IWebApiService _webApiService;

        public StockInputController(IWebApiService webApiService)
        {
            _webApiService = webApiService;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await StockInputList();
            return View(result);
        }
        [HttpGet("Ekle")]
        public async Task<IActionResult> Create()
        {
            return View(new CreateStockInputVM
            {
                GetBranchComboBoxDTOs = await BranchSelectList(),
                GetProductComboBoxDTOs = await ProductSelectList(),
                GetSupplierComboBoxDTOs = await SupplierSelectList()
            });
        }
        [HttpPost("Ekle")]
        public async Task<IActionResult> Create(CreateStockInputVM createStockInputVM)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("stockInput/add", createStockInputVM.CreateStockInputDTO);
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
            }
            else
            {
                TempData["Success"] = "Stok Giriş İşlemi Başarılı!";
            }

            return View(new CreateStockInputVM
            {
                GetBranchComboBoxDTOs = await BranchSelectList(),
                GetProductComboBoxDTOs = await ProductSelectList(),
                GetSupplierComboBoxDTOs = await SupplierSelectList(),
                CreateStockInputDTO = createStockInputVM.CreateStockInputDTO
            });
        }
        [HttpGet("Guncelle/{id}")]
        public async Task<IActionResult> Update(Guid id)
        {
            if (id != Guid.Empty)
            {
                HttpResponseMessage response = await GetById(id);
                if (!response.IsSuccessStatusCode)
                {
                    var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                    TempData["Error"] = resultError.Detail;
                    return View(new UpdateStockInputVM
                    {
                        GetBranchComboBoxDTOs = await BranchSelectList(),
                        GetProductComboBoxDTOs = await ProductSelectList(),
                        GetSupplierComboBoxDTOs = await SupplierSelectList()
                    });
                }
                var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<UpdateStockInputDTO>>(response);
                return View(new UpdateStockInputVM
                {
                    GetBranchComboBoxDTOs = await BranchSelectList(),
                    GetProductComboBoxDTOs = await ProductSelectList(),
                    GetSupplierComboBoxDTOs = await SupplierSelectList(),
                    UpdateStockInputDTO = resultSuccess.Data
                });
            }
            return View(new UpdateStockInputVM
            {
                GetBranchComboBoxDTOs = await BranchSelectList(),
                GetProductComboBoxDTOs = await ProductSelectList(),
                GetSupplierComboBoxDTOs = await SupplierSelectList()
            });
        }
        [HttpPost("Guncelle/{id}")]
        public async Task<IActionResult> Update(UpdateStockInputVM updateStockInputVM)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("stockInput/update", updateStockInputVM.UpdateStockInputDTO);
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View(new UpdateStockInputVM
                {
                    GetBranchComboBoxDTOs = await BranchSelectList(),
                    GetProductComboBoxDTOs = await ProductSelectList(),
                    GetSupplierComboBoxDTOs = await SupplierSelectList(),
                    UpdateStockInputDTO = updateStockInputVM.UpdateStockInputDTO
                });
            }
            TempData["Success"] = "Stok Giriş Güncelleme İşlemi Başarılı!";
            return RedirectToAction("Update","StockInput", new {id= updateStockInputVM.UpdateStockInputDTO.Id});
        }
        [HttpGet("Sil/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"stockInput/Delete/{id}/{User.FindFirstValue(ClaimTypes.NameIdentifier)}");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return RedirectToAction("Index","StockInput");
            }
            TempData["Success"] = "Stok Giriş İşlemi Silindi!";
            return RedirectToAction("Index", "StockInput");
        }

        private async Task<List<GetStockInputListDTO>> StockInputList()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"stockInput/Getall/{userId}");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetStockInputListDTO>>>(response);
            return resultSuccess.Data;
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
        private async Task<List<GetSupplierComboBoxDTO>> SupplierSelectList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("supplier/getallcombobox");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetSupplierComboBoxDTO>>>(response);
            return resultSuccess.Data;
        }
        private async Task<HttpResponseMessage> GetById(Guid id) => await _webApiService.httpClient.GetAsync($"stockInput/GetById/{id}");
    }
}
