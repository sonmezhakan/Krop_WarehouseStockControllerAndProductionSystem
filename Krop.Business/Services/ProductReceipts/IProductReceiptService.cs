using Krop.Common.Utilits.Result;
using Krop.DTO.Dtos.ProductReceipts;

namespace Krop.Business.Services.ProductReceipts
{
    public interface IProductReceiptService
    {
        Task<IDataResult<IEnumerable<GetProductReceiptListDTO>>> GetAllAsync(Guid produceProductId);
        /*Task<IDataResult<IEnumerable<GetProductReceiptDTO>>> GetByProduceProductId(Guid produceProductId,Guid branchId);*/
        Task<IResult> AddAsync(CreateProductReceiptDTO createProductReceiptDTO);
        Task<IResult> UpdateAsync(UpdateProductReceiptDTO updateProductReceiptDTO);
        Task<IResult> DeleteAsync(Guid produceProductId,Guid productId);
    }
}
