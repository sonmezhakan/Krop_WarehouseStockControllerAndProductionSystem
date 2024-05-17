using Krop.Entities.Entities;

namespace Krop.Business.Services.Stocks
{
    public interface IStockService
    {
        Task<List<Stock>> NewBranchAddedProductAsync(Guid branchId);//Yeni Eklenen Şubeye tüm ürünlerin eklenilmesi eklenmesi
        Task<List<Stock>> NewProductAddedBranchAsync(Guid productId);//Yeni eklenen ürünün tüm şubelere eklenmesi


        Task<bool> StockUpdateAsync();
        Task<bool> StockUpdateRangeAsync();

        Task<bool> BranchDeletedProductAsync(Guid branchId);
        Task<bool> BranchDeletedRangeProductAsync(List<Guid> branchIds);
        Task<bool> ProductDeletedBranchAsync(Guid productId);
        Task<bool> ProductDeletedRangeBranchAsync(List<Guid> productIds);

    }
}
