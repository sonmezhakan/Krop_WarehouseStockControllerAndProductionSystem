
using Krop.Business.Features.Stocks.Rules;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.Business.Services.Stocks
{
    public class StockManager:IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly StockBusinessRules _stockBusinessRules;

        public StockManager(IStockRepository stockRepository,IProductRepository productRepository,IBranchRepository branchRepository,StockBusinessRules stockBusinessRules)
        {
            _stockRepository = stockRepository;
            _productRepository = productRepository;
            _branchRepository = branchRepository;
            _stockBusinessRules = stockBusinessRules;
        }

        #region New Branch Added Product
        public async Task<List<Stock>> NewBranchAddedProductAsync(Guid branchId)
        {
            var productGuids = await _productRepository.GetAllProductIdAsync();//Tüm ürünlerin idlerini getir

            if (productGuids.Count() <= 0)
                return null;//Eğer ürün yok ise null dön.

            List<Stock> stocks = new();
            for (int i = 0; i < productGuids.Count(); i++)//Tüm ürünlerin idlerini dönerek stocks listesine ekler.
            {
                stocks.Add(new Stock
                {
                    BranchId = branchId,
                    ProductId = productGuids[i]
                }); ;
            }

            return stocks;//Stocks listesini geri döndürür.
        }

        #endregion
        #region New Product Added Branch
        public async Task<List<Stock>> NewProductAddedBranchAsync(Guid productId)
        {
            var branchIds = await _branchRepository.GetAllBranchIdAsync();//Tüm şubelerin idlerini getiriyoruz.

            if(branchIds is null)
                return null;//şube yok ise null dön.

            List<Stock> stocks = new();
            for (int i = 0; i < branchIds.Count(); i++)//tüm şubelerde dönerek yeni ürünü stocks listesine ekliyor.
            {
                stocks.Add(new Stock
                {
                    BranchId = branchIds[i],
                    ProductId = productId
                });
            }

            return stocks;//stocks listesini geri döndürüyor.
        }

        #endregion
        #region Branch Deleted Product
        public async Task<IResult> BranchDeletedProductAsync(Guid branchId)
        {
            var stocks = await _stockRepository.GetAllStockAsync(b => b.BranchId == branchId);//Gelen parametre branchId'sine ait tüm stocks verileri getirilir.

            if (stocks is null)
                return new SuccessResult();//Eğer herhangi bir veri yoksa silenecek veri olmadığından true döndürülür.

            await _stockRepository.DeleteRangeAsync(stocks.ToList());//Silme işlemi gerçekleştirilir.
            return new SuccessResult();
        }

        public async Task<IResult> BranchDeletedRangeProductAsync(List<Guid> branchIds)
        {
            List<Stock> stocks = new();
            //Parametre olarak gelen branchIdlerini döngüye sokarak her bir branchdeki ürünler stockdan silinir.
            branchIds.ForEach(async b =>
            {
                var getBranchStocks = await _stockRepository.GetAllAsync(b => b.BranchId == b.BranchId);//Şubeye ait tüm stock listesi getirilir.

                //Eğer getBranchStocks boş değil ise getBranchStocks listesinde dönerek stocks listesine ekleme yapılır.
                if (getBranchStocks is not null)
                {
                    getBranchStocks.ToList().ForEach(bs =>
                    {
                        stocks.Add(bs);
                    });
                }
            });
            await _stockRepository.DeleteRangeAsync(stocks);//Stocks listesi toplu bir şekilde silinir.
            return new SuccessResult();
        }
        #endregion
        #region Product Deleted Branch
        public async Task<IResult> ProductDeletedBranchAsync(Guid productId)
        {
            var stocks = await _stockRepository.GetAllAsync(b => b.ProductId == productId);//Gelen parametre productId'sine ait tüm stocks verileri getirilir.

            if (stocks is null)
                return new SuccessResult();//Eğer herhangi bir veri yoksa silenecek veri olmadığından true döndürülür.

            await _stockRepository.DeleteRangeAsync(stocks.ToList());//Silme işlemi gerçekleştirilir.
            return new SuccessResult();
        }

        public async Task<IResult> ProductDeletedRangeBranchAsync(List<Guid> productIds)
        {
            List<Stock> stocks = new();
            //Parametre olarak gelen productIdlerini döngüye sokarak her bir ürün şubelerden silinir.
            productIds.ForEach(async p =>
            {
                var getProductStocks = await _stockRepository.GetAllAsync(b => b.ProductId == b.ProductId);//Ürünlere ait tüm stock listesi getirilir.

                //Eğer getProductStocks boş değil ise getProductStocks listesinde dönerek stocks listesine ekleme yapılır.
                if (getProductStocks is not null)
                {
                    getProductStocks.ToList().ForEach(ps =>
                    {
                        stocks.Add(ps);
                    });
                }
            });
            await _stockRepository.DeleteRangeAsync(stocks);//Stocks listesi toplu bir şekilde silinir.
            return new SuccessResult();
        }
        #endregion
        #region Stock Update
        public async Task<IResult> StockInputUpdateAsync(Guid branchId,Guid productId,int quantity)//Stok Girişi Yapılıp, Stok Güncelleniyor.
        {
            var result = await _stockBusinessRules.CheckStockBranchAndProductId(branchId, productId);

            result.UnitsInStock += quantity;

            await _stockRepository.UpdateAsync(result);

            return new SuccessResult();
        }
        public async Task<IResult> StockUpdateAsync(Guid branchId, Guid productId, int oldQuantity,int newQuantity)//Stok Güncellenmesi
        {
            var result = await _stockBusinessRules.CheckStockBranchAndProductId(branchId, productId);

            result.UnitsInStock -= oldQuantity;
            result.UnitsInStock += newQuantity;

            await _stockRepository.UpdateAsync(result);

            return new SuccessResult();
        }

        public async Task<IResult> StockDeleteAsync(Guid branchId, Guid productId, int quantity)//Stok Silinmesi
        {
            var result = await _stockBusinessRules.CheckStockBranchAndProductId(branchId, productId);

            result.UnitsInStock -= quantity;

            await _stockRepository.UpdateAsync(result);

            return new SuccessResult();
        }
        #endregion
    }
}
