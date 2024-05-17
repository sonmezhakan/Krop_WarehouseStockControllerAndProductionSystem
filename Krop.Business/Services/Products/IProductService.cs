using Krop.Business.Features.Products.Dtos;

namespace Krop.Business.Services.Products
{
    public interface IProductService
    {
        Task<bool> AddAsync(CreateProductDTO createProductDTO);
        Task<bool> AddRangeAsync(List<CreateProductDTO> createProductDTOs);

        Task<bool> UpdateAsync(UpdateProductDTO updateProductDTO);
        Task<bool> UpdateRangeAsync(List<UpdateProductDTO> updateProductDTOs);

        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteRangeAsync(List<Guid> ids);

        Task<IEnumerable<GetProductDTO>> GetAllAsync();

        Task<GetProductDTO> GetByIdAsync(Guid id);

     } 
}
