using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.DTO.Dtos.ProductReceipts;
using Krop.DTO.Dtos.Products;
using Krop.ViewModel.ViewModel.ProductReceipts;
using Microsoft.AspNetCore.Mvc;

namespace Krop.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Route("Urun-Recetesi")]
    public class ProductReceiptController : Controller
    {
        private readonly IWebApiService _webApiService;

        public ProductReceiptController(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        [HttpGet("Listesi")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Ekle/{produceProductId?}/{productId?}")]
        public async Task<IActionResult> Create(Guid? produceProductId, Guid? productId)
        {
            TempData["DeleteAction"] = "Create";
            if ((produceProductId != null && produceProductId != Guid.Empty) || (productId != null && productId != Guid.Empty))
            {
                return View(new CreateProductReceiptVM
                {
                    GetProductComboBoxDTOs = await ProductSelectList(),
                    GetProductReceiptListDTOs = await ProductReceiptList((Guid)produceProductId),
                    ProduceProductId = produceProductId,
                    ProductId = productId
                });
            }
            return View(new CreateProductReceiptVM
            {
                GetProductComboBoxDTOs = await ProductSelectList(),
                ProductId = productId
            });

        }
        [HttpPost("Ekle/{produceProductId?}/{productId?}")]
        public async Task<IActionResult> Create(CreateProductReceiptVM createProductReceiptVM)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PostAsJsonAsync("productReceipt/add", createProductReceiptVM.CreateProductReceiptDTO);
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View(new CreateProductReceiptVM
                {
                    GetProductComboBoxDTOs = await ProductSelectList(),
                    GetProductReceiptListDTOs = await ProductReceiptList(createProductReceiptVM.CreateProductReceiptDTO.ProduceProductId),
                    CreateProductReceiptDTO = createProductReceiptVM.CreateProductReceiptDTO,
                    ProduceProductId = createProductReceiptVM.CreateProductReceiptDTO.ProduceProductId,
                    ProductId = createProductReceiptVM.CreateProductReceiptDTO.ProductId
                });
            }
            TempData["Success"] = "Ürün Reçetesine Ürün Ekleme İşlemi Başarılı!";
            return RedirectToAction("Create", "ProductReceipt", new { produceProductId = createProductReceiptVM.CreateProductReceiptDTO.ProduceProductId });
        }
        [HttpGet("Guncelle/{produceProductId?}/{productId?}")]
        public async Task<IActionResult> Update(Guid? produceProductId,Guid? productId)
       {
            TempData["DeleteAction"] = "Update";
            if ((produceProductId != null && produceProductId != Guid.Empty) && (productId != null && productId != Guid.Empty))
            {
                HttpResponseMessage response = await GetByProduceProductIdAndProductId((Guid)produceProductId, (Guid)productId);
                if(!response.IsSuccessStatusCode)
                {
                    var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                    TempData["Error"] = resultError.Detail;
                    return View(new UpdateProductReceiptVM
                    {
                        GetProductComboBoxDTOs = await ProductSelectList(),
                        GetProductReceiptListDTOs = await ProductReceiptList((Guid)produceProductId),
                        ProduceProductId = produceProductId,
                    });
                }
                var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<UpdateProductReceiptDTO>>(response);
                return View(new UpdateProductReceiptVM
                {
                    GetProductComboBoxDTOs = await ProductSelectList(),
                    GetProductReceiptListDTOs = await ProductReceiptList((Guid)produceProductId),
                    UpdateProductReceiptDTO = resultSuccess.Data,
                    ProduceProductId = produceProductId
                });
            }
            else if(produceProductId != null && produceProductId != Guid.Empty)
            {
                return View(new UpdateProductReceiptVM
                {
                    GetProductComboBoxDTOs = await ProductSelectList(),
                    GetProductReceiptListDTOs = await ProductReceiptList((Guid)produceProductId),
                    ProduceProductId = produceProductId
                });
            }
            
            return View(new UpdateProductReceiptVM
            {
                GetProductComboBoxDTOs = await ProductSelectList()
            });
        }
        [HttpPost("Guncelle/{produceProductId?}/{productId?}")]
        public async Task<IActionResult> Update(UpdateProductReceiptVM updateProductReceiptVM)
        {
            HttpResponseMessage response = await _webApiService.httpClient.PutAsJsonAsync("productreceipt/update", updateProductReceiptVM.UpdateProductReceiptDTO);
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View(new UpdateProductReceiptVM
                {
                    GetProductComboBoxDTOs = await ProductSelectList(),
                    GetProductReceiptListDTOs = await ProductReceiptList(updateProductReceiptVM.UpdateProductReceiptDTO.ProduceProductId),
                    UpdateProductReceiptDTO = updateProductReceiptVM.UpdateProductReceiptDTO,
                    ProduceProductId = updateProductReceiptVM.UpdateProductReceiptDTO.ProduceProductId
                });
            }
            TempData["Success"] = "Ürün Reteçesi Güncellendi!";
            return RedirectToAction("Update", "ProductReceipt", new {
                produceProductId=updateProductReceiptVM.UpdateProductReceiptDTO.ProduceProductId,
                productId= updateProductReceiptVM.UpdateProductReceiptDTO.ProductId
            });
        }
        [HttpPost("Sil/{produceProductId}/{productId}")]
        public async Task<IActionResult> Delete(Guid produceProductId,Guid productId)
        {
            HttpResponseMessage response = await _webApiService.httpClient.DeleteAsync($"productReceipt/delete/{produceProductId}/{productId}");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return RedirectToAction(TempData["DeleteAction"].ToString(), "ProductReceipt");
            }
            TempData["Success"] = "Ürün Reçetesinden Silme İşlemi Başarılı!";
            return RedirectToAction(TempData["DeleteAction"].ToString(), "ProductReceipt", new { produceProductId = produceProductId });
        }

        private async Task<List<GetProductComboBoxDTO>> ProductSelectList()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"product/getallcombobox");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetProductComboBoxDTO>>>(response);
            return resultSuccess.Data;
        }
        private async Task<List<GetProductReceiptListDTO>> ProductReceiptList(Guid produceProductId)
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"productReceipt/getall/{produceProductId}");
            if (!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return null;
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetProductReceiptListDTO>>>(response);
            return resultSuccess.Data;
        }
        private async Task<HttpResponseMessage> GetByProduceProductIdAndProductId(Guid produceProductId,Guid productId) => await _webApiService.httpClient.GetAsync($"productReceipt/GetByProduceProductIdAndProductId/{produceProductId}/{productId}");
    }
}
