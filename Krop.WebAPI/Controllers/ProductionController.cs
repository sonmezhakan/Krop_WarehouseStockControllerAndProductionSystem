using Krop.Business.Services.Productions;
using Krop.DTO.Dtos.Productions;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductionController : ControllerBase
    {
        private readonly IProductionService _productionService;

        public ProductionController(IProductionService productionService)
        {
            _productionService = productionService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductionDTO createProductionDTO)
        {
            var result = await _productionService.AddAsync(createProductionDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductionDTO updateProductionDTO)
        {
            var result = await _productionService.UpdateAsync(updateProductionDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}/{appUserId}")]
        public async Task<IActionResult> Delete(Guid id, Guid appUserId)
        {
            var result = await _productionService.DeleteAsync(id, appUserId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{appUserId}")]
        public async Task<IActionResult> GetAll(Guid appUserId)
        {
            var result = await _productionService.GetAllAsync(appUserId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
