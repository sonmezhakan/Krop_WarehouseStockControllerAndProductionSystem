using Krop.Business.Features.StockTransfers.Dtos;
using Krop.Business.Services.StockTransfers;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StockTransferController : ControllerBase
    {
        private readonly IStockTransferService _stockTransferService;

        public StockTransferController(IStockTransferService stockTransferService)
        {
            _stockTransferService = stockTransferService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateStockTransferDTO createStockTransferDTO)
        {
            var result = await _stockTransferService.AddAsync(createStockTransferDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStockTransferDTO updateStockTransferDTO)
        {
            var result = await _stockTransferService.UpdateAsync(updateStockTransferDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{Id}/{appUserId}")]
        public async Task<IActionResult> Delete(Guid Id, Guid appUserId)
        {
            var result = await _stockTransferService.DeleteAsync(Id,appUserId);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _stockTransferService.GetAllAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{appUserId}")]
        public async Task<IActionResult> AppUserBranchGetAll(Guid appUserId)
        {
            var result = await _stockTransferService.AppUserBranchGetAllAsync(appUserId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{Id}/{appUserId}")]
        public async Task<IActionResult> GetById(Guid Id,Guid appUserId)
        {
            var result = await _stockTransferService.GetByIdAsync(Id,appUserId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
