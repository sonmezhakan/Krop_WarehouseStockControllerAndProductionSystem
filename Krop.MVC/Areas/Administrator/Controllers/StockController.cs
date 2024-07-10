using Krop.Common.Helpers.JsonHelpers;
using Krop.Common.Helpers.WebApiService;
using Krop.Common.Models;
using Krop.DTO.Dtos.Stocks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Krop.MVC.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Route("Stok")]
    public class StockController : Controller
    {
        private readonly IWebApiService _webApiService;

        public StockController(IWebApiService webApiService)
        {
           _webApiService = webApiService;
        }
        [HttpGet("Listesi")]
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _webApiService.httpClient.GetAsync($"Stock/GetAllFilteredAppUser/{User.FindFirstValue(ClaimTypes.NameIdentifier)}");
            if(!response.IsSuccessStatusCode)
            {
                var resultError = await JsonHelper.DeserializeAsync<ErrorResponseViewModel>(response);
                TempData["Error"] = resultError.Detail;
                return View();
            }
            var resultSuccess = await JsonHelper.DeserializeAsync<SuccessDataResponseViewModel<List<GetStockListDTO>>>(response);
            return View(resultSuccess.Data);
        }
    }
}
