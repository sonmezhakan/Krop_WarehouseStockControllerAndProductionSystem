using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.DTO.Dtos.Branches;
using Krop.DTO.Dtos.Products;
using Krop.DTO.Dtos.StockTransfers;
using Krop.ViewModel.ViewModels.StockTransfers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Krop.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Route("Stok-Transfer")]
    public class StockTransferController : Controller
    {
        private readonly IWebApiService _webApiService;

        public StockTransferController(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        [HttpGet("Listesi")]
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("stockTransfer/getall");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetStockTransferListDTO>>>(response);
            return View(resultSuccess.Data);
        }
        [HttpGet("Ekle")]
        public async Task<IActionResult> Create()
        {
            return View(new CreateStockTransferVM
            {
                GetBranchComboBoxDTOs = await BranchSelectList(),
                GetProductComboBoxDTOs = await ProductSelectList()
            });
        }
        [HttpPost("Ekle")]
        public async Task<IActionResult> Create(CreateStockTransferVM createStockTransferVM)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("stockTransfer/add", createStockTransferVM.CreateStockTransferDTO);
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail; 
            }
            else
            {
                TempData["Success"] = "Stok Transfer İşlemi Başarılı!";
            }

            return View(new CreateStockTransferVM
            {
                GetBranchComboBoxDTOs = await BranchSelectList(),
                GetProductComboBoxDTOs = await ProductSelectList(),
                CreateStockTransferDTO = createStockTransferVM.CreateStockTransferDTO
            });
        }
        [HttpGet("Guncelle/{id}")]
        public async Task<IActionResult> Update(Guid id)
        {
            if(id != null && id != Guid.Empty)
            {
                HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"stockTransfer/GetById/{id}/{User.FindFirstValue(ClaimTypes.NameIdentifier)}");
                if(!response.IsSuccessStatusCode)
                {
                    var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                    TempData["Error"] = resultError.Detail;
                    return View(new UpdateStockTransferVM
                    {
                        GetBranchComboBoxDTOs = await BranchSelectList(),
                        GetProductComboBoxDTOs = await ProductSelectList()
                    });
                }
                var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<UpdateStockTransferDTO>>(response);
                return View(new UpdateStockTransferVM
                {
                    GetBranchComboBoxDTOs = await BranchSelectList(),
                    GetProductComboBoxDTOs = await ProductSelectList(),
                    UpdateStockTransferDTO = resultSuccess.Data
                });
            }
            return RedirectToAction("Index", "StockInput");
        }
        [HttpPost("Guncelle/{id}")]
        public async Task<IActionResult> Update(UpdateStockTransferVM updateStockTransferVM)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("stockTransfer/Update", updateStockTransferVM.UpdateStockTransferDTO);
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View(new UpdateStockTransferVM
                {
                    GetBranchComboBoxDTOs = await BranchSelectList(),
                    GetProductComboBoxDTOs = await ProductSelectList(),
                    UpdateStockTransferDTO = updateStockTransferVM.UpdateStockTransferDTO
                });
            }
            TempData["Success"] = "Stok Transfer Güncelleme İşlemi Başarılı!";
            return RedirectToAction("Update", "StockTransfer", new { id = updateStockTransferVM.UpdateStockTransferDTO.Id });
        }
        [HttpGet("Sil/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"StockTransfer/Delete/{id}/{User.FindFirstValue(ClaimTypes.NameIdentifier)}");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;   
            }
            else
            {
                TempData["Success"] = "Stok Girişi Silme İşlemi Başarılı!";
            }
            return RedirectToAction("Index", "StockTransfer");
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
    }
}
