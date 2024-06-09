using Krop.Business.Services.Stocks;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
           _stockService = stockService;
        }
        [HttpGet("{appUserId}")]
        public async Task<IActionResult> GetAllFilteredAppUser(Guid appUserId, CancellationToken cancellationToken)
        {
            var result = await _stockService.GetAllFilteredAppUserAsync(appUserId);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
