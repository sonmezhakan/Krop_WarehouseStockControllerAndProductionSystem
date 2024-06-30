using Krop.Common.Utilits.Result;
using Krop.DTO.Dtos.Products;

namespace Krop.Business.Services.Products
{
    public interface IProductService
    {
        Task<IResult> AddAsync(CreateProductDTO createProductDTO);
        Task<IResult> UpdateAsync(UpdateProductDTO updateProductDTO);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<IEnumerable<GetProductListDTO>>> GetAllAsync();
        Task<IDataResult<GetProductDTO>> GetByIdAsync(Guid id);
        Task<IDataResult<IEnumerable<GetProductComboBoxDTO>>> GetAllComboBoxAsync();
        Task<IDataResult<GetProductCartDTO>> GetByIdCartAsync(Guid Id);

     } 
}
