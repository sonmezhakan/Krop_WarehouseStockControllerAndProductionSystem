using Krop.Business.Features.Products.Dtos;
using Krop.Common.Utilits.Result;

namespace Krop.Business.Services.Products
{
    public interface IProductService
    {
        Task<IResult> AddAsync(CreateProductDTO createProductDTO);
        Task<IResult> AddRangeAsync(List<CreateProductDTO> createProductDTOs);

        Task<IResult> UpdateAsync(UpdateProductDTO updateProductDTO);
        Task<IResult> UpdateRangeAsync(List<UpdateProductDTO> updateProductDTOs);

        Task<IResult> DeleteAsync(Guid id);
        Task<IResult> DeleteRangeAsync(List<Guid> ids);

        Task<IDataResult<IEnumerable<GetProductDTO>>> GetAllAsync();

        Task<IDataResult<GetProductDTO>> GetByIdAsync(Guid id);

     } 
}
