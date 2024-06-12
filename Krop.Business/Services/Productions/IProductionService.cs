using Krop.Common.Utilits.Result;
using Krop.DTO.Dtos.Productions;

namespace Krop.Business.Services.Productions
{
    public interface IProductionService
    {
        Task<IDataResult<IEnumerable<GetProductionListDTO>>> GetByBranchIdAsync(Guid appUserId);
        Task<IDataResult<GetProductionDTO>> GetByIdAsync(Guid id, Guid appUserId);
        Task<IResult> AddAsync(CreateProductionDTO createProductionDTO);
        Task<IResult> UpdateAsync(UpdateProductionDTO updateProductionDTO);
        Task<IResult> DeleteAsync(Guid id,Guid appUserId);
    }
}
