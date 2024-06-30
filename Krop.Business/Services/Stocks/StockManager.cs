using AutoMapper;
using Krop.Business.Features.Employees.Constants;
using Krop.Business.Features.Employees.Rules;
using Krop.Business.Features.Stocks.Constants;
using Krop.Business.Features.Stocks.Rules;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DTO.Dtos.Stocks;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Krop.Business.Services.Stocks
{
    public class StockManager:IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly StockBusinessRules _stockBusinessRules;
        private readonly EmployeeBusinessRules _employeeBusinessRules;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public StockManager(IStockRepository stockRepository,IProductRepository productRepository,IBranchRepository branchRepository,StockBusinessRules stockBusinessRules, EmployeeBusinessRules employeeBusinessRules,IMapper mapper,IEmployeeRepository employeeRepository)
        {
            _stockRepository = stockRepository;
            _productRepository = productRepository;
            _branchRepository = branchRepository;
            _stockBusinessRules = stockBusinessRules;
            _employeeBusinessRules = employeeBusinessRules;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        #region New Branch Added Product

        public async Task NewBranchAddedProductAsync(Guid branchId)
        {
            var productGuids = await _productRepository.GetAllProductIdAsync();//Tüm ürünlerin idlerini getir

            if (productGuids.Count() <= 0)
                return;//Eğer ürün yok ise işlemi bitir

            List<Stock> stocks = new();
            for (int i = 0; i < productGuids.Count(); i++)//Tüm ürünlerin idlerini dönerek stocks listesine ekler.
            {
                stocks.Add(new Stock
                {
                    BranchId = branchId,
                    ProductId = productGuids[i]
                });
            }
            await _stockRepository.AddRangeAsync(stocks);
        }

        #endregion
        #region New Product Added Branch
        public async Task NewProductAddedBranchAsync(Guid productId)
        {
            var branchIds = await _branchRepository.GetAllBranchIdAsync();//Tüm şubelerin idlerini getiriyoruz.

            if(branchIds is null)
                return;//şube yok ise işlemi bitir.

            List<Stock> stocks = new();
            for (int i = 0; i < branchIds.Count(); i++)//tüm şubelerde dönerek yeni ürünü stocks listesine ekliyor.
            {
                stocks.Add(new Stock
                {
                    BranchId = branchIds[i],
                    ProductId = productId
                });
            }

            await _stockRepository.AddRangeAsync(stocks);
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
        public async Task<IResult> StockAddedAsync(Guid branchId,Guid productId,int quantity)//Stok Girişi Yapılıp, Stok Güncelleniyor.
        {
            var result = await _stockRepository.GetAsync(x => x.ProductId == productId && x.BranchId == branchId);
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, StockMessages.StockNotFound);

            result.UnitsInStock += quantity;

            await _stockRepository.UpdateAsync(result);

            return new SuccessResult();
        }
        public async Task<IResult> StockUpdateAsync(Guid branchId, Guid productId, int oldQuantity,int newQuantity)//Stok Güncellenmesi
        {
            var result = await _stockRepository.GetAsync(x => x.ProductId == productId && x.BranchId == branchId);
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, StockMessages.StockNotFound);

            result.UnitsInStock -= oldQuantity;
            result.UnitsInStock += newQuantity;

            await _stockRepository.UpdateAsync(result);

            return new SuccessResult();
        }

        public async Task<IResult> StockDeleteAsync(Guid branchId, Guid productId, int quantity)//Stok Silinmesi
        {
            var result = await _stockRepository.GetAsync(x => x.ProductId == productId && x.BranchId == branchId);
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, StockMessages.StockNotFound);

            result.UnitsInStock -= quantity;

            await _stockRepository.UpdateAsync(result);

            return new SuccessResult();
        }

        #endregion

        #region Stock Listed
        public async Task<IDataResult<IEnumerable<GetStockListDTO>>> GetAllFilteredAppUserAsync(Guid appUserId)
        {
            var getEmployee = await _employeeRepository.GetAsync(x=>x.Id == appUserId);
            if (getEmployee is null)
                return new ErrorDataResult<IEnumerable<GetStockListDTO>>(StatusCodes.Status404NotFound,EmployeeMessages.EmployeeNotFound);

            var businessRule = await _employeeBusinessRules.CheckEmployeeWorkingAsync(appUserId);
            if (!businessRule.Success)
                return new ErrorDataResult<IEnumerable<GetStockListDTO>>(businessRule.Status, businessRule.Detail);

            var result = await _stockRepository.GetAllAsync(predicate: x => x.BranchId == getEmployee.BranchId,
            includeProperties: new Expression<Func<Stock, object>>[]
            {
                p=>p.Product,
                b=>b.Branch
            }
            );

            return new SuccessDataResult<IEnumerable<GetStockListDTO>> (
                _mapper.Map<IEnumerable<GetStockListDTO>>(result));
        }
        #endregion
    }
}
