using Krop.Business.Features.ProductReceipts.Dtos;
using Krop.Common.Utilits.Result;

namespace Krop.Business.Services.ProductReceipts
{
    public interface IProductReceiptService
    {
        Task<IDataResult<IEnumerable<GetProductReceiptListDTO>>> GetAllAsync(Guid produceProductId);
       // Task<IDataResult<GetProductReceiptDTO>> GetByProduceProductId(Guid produceProductId);
        Task<IResult> AddAsync(CreateProductReceiptDTO createProductReceiptDTO);
        Task<IResult> UpdateAsync(UpdateProductReceiptDTO updateProductReceiptDTO);
        Task<IResult> DeleteAsync(Guid produceProductId,Guid productId);
    }
}
