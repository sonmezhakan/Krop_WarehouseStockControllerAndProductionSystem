using Krop.Common.Helpers.WebApiService;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("{id?}")]
        public async Task<IActionResult> Index()
        {

            return View();
        }
    }
}
