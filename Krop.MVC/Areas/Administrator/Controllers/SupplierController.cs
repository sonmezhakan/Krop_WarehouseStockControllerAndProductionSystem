using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.DTO.Dtos.Suppliers;
using Krop.ViewModel.ViewModel.Suppliers;
using Microsoft.AspNetCore.Mvc;

namespace Krop.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Route("Tedarikci")]
    public class SupplierController : Controller
    {
        private readonly IWebApiService _webApiService;

        public SupplierController(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        [HttpGet("Listele")]
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("supplier/GetAll");
            if(!response.IsSuccessStatusCode)
            {
                var errorResult = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = errorResult.Detail;
                return View();
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetSupplierDTO>>>(response);
            return View(resultSuccess.Data);
        }
        [HttpGet("Ekle")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost("Ekle")]
        public async Task<IActionResult> Create(CreateSupplierDTO createSupplierDTO)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("supplier/add", createSupplierDTO);
            if(!response.IsSuccessStatusCode)
            {
                var errorResult = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = errorResult.Detail;
                return View(createSupplierDTO);
            }
            TempData["Success"] = "Tedarikçi Ekleme İşlemi Başarılı!";
            return View(createSupplierDTO);
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
                    return View(new UpdateSupplierVM
                    {
                        GetSupplierComboBoxDTO = await SupplierSelectList()
                    });
                }
                var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<UpdateSupplierDTO>>(response);
                return View(new UpdateSupplierVM
                {
                    GetSupplierComboBoxDTO = await SupplierSelectList(),
                    UpdateSupplierDTO = resultSuccess.Data
                });
            }
            return View(new UpdateSupplierVM
            {
                GetSupplierComboBoxDTO = await SupplierSelectList()
            });
        }
        [HttpPost("Guncelle/{id?}")]
        public async Task<IActionResult> Update(UpdateSupplierVM updateSupplierVM)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("supplier/update", updateSupplierVM.UpdateSupplierDTO);
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View(new UpdateSupplierVM
                {
                    GetSupplierComboBoxDTO = await SupplierSelectList(),
                    UpdateSupplierDTO = updateSupplierVM.UpdateSupplierDTO
                });
            }
            TempData["Success"] = "Tedarikçi Güncelleme İşlemi Başarılı!";
            return RedirectToAction("Update","Supplier", new {id=updateSupplierVM.UpdateSupplierDTO.Id});
        }
        [HttpGet("Sil/{id?}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            return View(new DeleteSupplierVM
            {
                GetSupplierComboBoxDTO = await SupplierSelectList(),
                Id = id ?? null
            });
        }
        [HttpPost("Sil/{id?}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"supplier/delete/{id}");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
            }
            else
            {
                TempData["Success"] = "Tedarikçi Silme İşlemi Başarılı!";
            }
            return RedirectToAction("Delete", "Supplier", new {id = id});
        }
        private async Task<List<GetSupplierComboBoxDTO>> SupplierSelectList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync("supplier/getallcombobox");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetSupplierComboBoxDTO>>>(response);
            return resultSuccess.Data;
        }
        private async Task<HttpResponseMessage> GetById(Guid id) => await _webApiService.httpClient.GetAsync($"supplier/getById/{id}");
    }
}
