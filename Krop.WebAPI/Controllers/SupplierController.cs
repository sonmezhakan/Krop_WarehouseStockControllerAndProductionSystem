using Krop.Business.Features.Suppliers.Dtos;
using Krop.Business.Services.Suppliers;
using Microsoft.AspNetCore.Mvc;

namespace Krop.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSupplierDTO createSupplierDTO, CancellationToken cancellationToken)
        {
            var result = await _supplierService.AddAsync(createSupplierDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSupplierDTO updateSupplierDTO, CancellationToken cancellationToken)
        {
            var result = await _supplierService.UpdateAsync(updateSupplierDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _supplierService.DeleteAsync(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _supplierService.GetAllAsync();

            return result.Success ? Ok(result): BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComboBox(CancellationToken cancellationToken)
        {
            var result = await _supplierService.GetAllComboBoxAsync();

            return result.Success ? Ok(result):BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _supplierService.GetByIdAsync(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
