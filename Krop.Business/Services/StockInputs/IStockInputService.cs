using Krop.Common.Utilits.Result;
using Krop.DTO.Dtos.StockInputs;

namespace Krop.Business.Services.StockInputs
{
    public interface IStockInputService
    {
        Task<IDataResult<IEnumerable<GetStockInputListDTO>>> GetByAppUserBranchIdAsync(Guid appUserId);
        Task<IDataResult<GetStockInputDTO>> GetByIdAsync(Guid id);
        Task<IResult> AddAsync(CreateStockInputDTO createStockInputDTO);
        Task<IResult> UpdateAsync(UpdateStockInputDTO updateStockInputDTO,bool productionUpdated = false);
        Task<IResult> DeleteAsync(Guid id,Guid appUserId,bool productionDeleted = false);
    }
}
