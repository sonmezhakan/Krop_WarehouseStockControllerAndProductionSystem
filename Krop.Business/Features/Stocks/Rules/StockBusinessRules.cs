using Krop.Business.Features.Stocks.Constants;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Features.Stocks.Rules
{
    public class StockBusinessRules
    {
        private readonly IStockRepository _stockRepository;

        public StockBusinessRules(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        
        public async Task<IDataResult<Stock>> CheckStockBranchAndProductId(Guid branchId,Guid productId)
        {
            var result = await _stockRepository.GetAsync(x => x.ProductId == productId && x.BranchId == branchId);

            if (result is null)
                return new ErrorDataResult<Stock>(StatusCodes.Status404NotFound, StockMessages.StockNotFound);

            return new SuccessDataResult<Stock>(result);
        }
    }
}
