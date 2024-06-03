using Krop.Common.Utilits.Result;
using Krop.DTO.Dtos.ProductionStockExit;

namespace Krop.Business.Services.ProductionStockExits
{
    public interface IProductionStockExitService
    {
        Task<IDataResult<GetProductionStockExitDTO>> GetByIdAsync(Guid Id);
        Task<IDataResult<IEnumerable<GetProductionStockExitDTO>>> GetByProductionIdAllAsync(Guid id);  
        Task<IResult> AddRangeAsync(List<CreateProductionStockExitDTO> createProductionStockExitDTOs);
        Task<IResult> UpdateRangeAsync(List<UpdateProductionStockExitDTO> updateProductionStockExitDTOs);
        Task<IResult> DeleteAsync(Guid productionId);
    }
}
