using Krop.Common.Utilits.Result;
using Krop.DTO.Dtos.Stocks;
using Krop.Entities.Entities;

namespace Krop.Business.Services.Stocks
{
    public interface IStockService
    {
        Task NewBranchAddedProductAsync(Guid branchId);//Yeni Eklenen Şubeye tüm ürünlerin eklenilmesi eklenmesi
        Task NewProductAddedBranchAsync(Guid productId);//Yeni eklenen ürünün tüm şubelere eklenmesi

        Task<IResult> StockAddedAsync(Guid branchId, Guid productId, int quantity);
        //Task<IResult> StockUpdateAsync(Guid branchId, int oldQuantity, int newQuantity);
        Task<IResult> StockDeleteAsync(Guid branchId, Guid productId, int quantity);

        Task<IResult> BranchDeletedProductAsync(Guid branchId);
        Task<IResult> BranchDeletedRangeProductAsync(List<Guid> branchIds);
        Task<IResult> ProductDeletedBranchAsync(Guid productId);
        Task<IResult> ProductDeletedRangeBranchAsync(List<Guid> productIds);
        Task<IDataResult<IEnumerable<GetStockListDTO>>> GetAllFilteredAppUserAsync(Guid appUserId);


    }
}
