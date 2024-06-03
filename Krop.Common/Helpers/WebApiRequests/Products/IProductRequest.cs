using Krop.DTO.Dtos.Products;

namespace Krop.Common.Helpers.WebApiRequests.Products
{
    public interface IProductRequest
    {
        Task<HttpResponseMessage> GetAllAsync();
        Task<HttpResponseMessage> GetAllComboBoxAsync();
        Task<HttpResponseMessage> GetByIdAsync(Guid id);
        Task<HttpResponseMessage> GetByIdCartAsync(Guid id);
        Task<HttpResponseMessage> AddAsync(CreateProductDTO createProductDTO);
        Task<HttpResponseMessage> UpdateAsync(UpdateProductDTO updateProductDTO);
        Task<HttpResponseMessage> DeleteAsync(Guid id);
    }
}
