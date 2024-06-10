using Krop.Business.Services.ProductNotifications;
using Krop.DTO.Dtos.ProductNotifications;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductNotificationController : ControllerBase
    {
        private readonly IProductNotificationService _productNotificationService;

        public ProductNotificationController(IProductNotificationService productNotificationService)
        {
            _productNotificationService = productNotificationService;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductNotificationDTO createProductNotificationDTO)
        {
            var result = await _productNotificationService.AddAsync(createProductNotificationDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductNotificationDTO updateProductNotificationDTO)
        {
            var result = await _productNotificationService.UpdateAsync(updateProductNotificationDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}/{appUserId}")]
        public async Task<IActionResult> Delete(Guid id,Guid appUserId)
        {
            var result = await _productNotificationService.DeleteAsync(id,appUserId);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{inEmployeId}")]
        public async Task<IActionResult> GetInAll(Guid inEmployeId)
        {
            var result = await _productNotificationService.GetInAllAsync(inEmployeId);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{sentEmployeId}")]
        public async Task<IActionResult> GetSentAll(Guid sentEmployeId)
        {
            var result = await _productNotificationService.GetSentAllAsync(sentEmployeId);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _productNotificationService.GetByIdAsync(id);

            return result.Success ? Ok(result):BadRequest(result);
        }
    }
}
