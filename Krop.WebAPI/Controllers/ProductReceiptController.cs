using Krop.Business.Services.ProductReceipts;
using Krop.DTO.Dtos.ProductReceipts;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductReceiptController : ControllerBase
    {
        private readonly IProductReceiptService _productReceiptService;

        public ProductReceiptController(IProductReceiptService productReceiptService)
        {
            _productReceiptService = productReceiptService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductReceiptDTO createProductReceiptDTO, CancellationToken cancellationToken)
        {
            var result = await _productReceiptService.AddAsync(createProductReceiptDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductReceiptDTO updateProductReceiptDTO ,CancellationToken cancellationToken)
        {
            var result = await _productReceiptService.UpdateAsync(updateProductReceiptDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{produceProductId}/{productId}")]
        public async Task<IActionResult> Delete(Guid produceProductId,Guid productId, CancellationToken cancellationToken)
        {
            var result = await _productReceiptService.DeleteAsync(produceProductId,productId);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{produceProductId}")]
        public async Task<IActionResult> GetAll(Guid produceProductId,CancellationToken cancellationToken)
        {
            var result = await _productReceiptService.GetByProduceIdAsync(produceProductId);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{produceProductId}/{productId}")]
        public async Task<IActionResult> GetByProduceProductIdAndProductId(Guid produceProductId, Guid productId,CancellationToken cancellationToken)
        {
            var result = await _productReceiptService.GetByProduceProductIdAndProductIdAsync(produceProductId, productId);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
