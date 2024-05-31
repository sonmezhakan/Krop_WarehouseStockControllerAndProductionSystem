using Krop.Business.Features.StockInputs.Dtos;
using Krop.Business.Services.StockInputs;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StockInputController : ControllerBase
    {
        private readonly IStockInputService _stockInputService;

        public StockInputController(IStockInputService stockInputService)
        {
            _stockInputService = stockInputService;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateStockInputDTO createStockInputDTO, CancellationToken cancellationToken)
        {
            var result = await _stockInputService.AddAsync(createStockInputDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateStockInputDTO updateStockInputDTO, CancellationToken cancellationToken)
        {
            var result = await _stockInputService.UpdateAsync(updateStockInputDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id,CancellationToken cancellationToken)
        {
            var result = await _stockInputService.DeleteAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _stockInputService.GetAllAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id,CancellationToken cancellationToken)
        {
            var result = await _stockInputService.GetByIdAsync(id);
            return result.Success ? Ok(result):BadRequest(result);
        }
    }
}
