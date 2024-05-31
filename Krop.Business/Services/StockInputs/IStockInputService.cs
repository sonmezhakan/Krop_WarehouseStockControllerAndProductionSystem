using Krop.Business.Features.StockInputs.Dtos;
using Krop.Common.Utilits.Result;

namespace Krop.Business.Services.StockInputs
{
    public interface IStockInputService
    {
        Task<IDataResult<IEnumerable<GetStockInputListDTO>>> GetAllAsync();
        Task<IDataResult<GetStockInputDTO>> GetByIdAsync(Guid id);
        Task<IResult> AddAsync(CreateStockInputDTO createStockInputDTO);
        Task<IResult> UpdateAsync(UpdateStockInputDTO updateStockInputDTO);
        Task<IResult> DeleteAsync(Guid Id);
    }
}
