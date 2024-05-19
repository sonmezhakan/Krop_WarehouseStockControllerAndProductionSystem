using Krop.Common.Utilits.Result;
using Krop.Entities.Entities;

namespace Krop.Business.Services.Stocks
{
    public interface IStockService
    {
        Task<List<Stock>> NewBranchAddedProductAsync(Guid branchId);//Yeni Eklenen Şubeye tüm ürünlerin eklenilmesi eklenmesi
        Task<List<Stock>> NewProductAddedBranchAsync(Guid productId);//Yeni eklenen ürünün tüm şubelere eklenmesi


        Task<IResult> StockUpdateAsync();
        Task<IResult> StockUpdateRangeAsync();

        Task<IResult> BranchDeletedProductAsync(Guid branchId);
        Task<IResult> BranchDeletedRangeProductAsync(List<Guid> branchIds);
        Task<IResult> ProductDeletedBranchAsync(Guid productId);
        Task<IResult> ProductDeletedRangeBranchAsync(List<Guid> productIds);

    }
}
