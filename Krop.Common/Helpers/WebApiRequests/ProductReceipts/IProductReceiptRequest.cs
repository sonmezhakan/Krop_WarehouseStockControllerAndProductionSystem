using Krop.DTO.Dtos.ProductReceipts;

namespace Krop.Common.Helpers.WebApiRequests.ProductReceipts
{
    public interface IProductReceiptRequest
    {
        Task<HttpResponseMessage> GetAllAsync(Guid produceProductId);
        Task<HttpResponseMessage> GetByIdAsync(Guid id);
        Task<HttpResponseMessage> AddAsync(CreateProductReceiptDTO createProductReceiptDTO);
        Task<HttpResponseMessage> UpdateAsync(UpdateProductReceiptDTO updateProductReceiptDTO);
        Task<HttpResponseMessage> DeleteAsync(Guid produceProductId,Guid productId);
    }
}
