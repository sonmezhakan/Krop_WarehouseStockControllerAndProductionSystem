using Krop.Business.Features.Stocks.ExceptionHelpers;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Stocks.Rules
{
    public class StockBusinessRules
    {
        private readonly IStockRepository _stockRepository;
        private readonly StockExceptionHelper _stockExceptionHelper;

        public StockBusinessRules(IStockRepository stockRepository,StockExceptionHelper stockExceptionHelper)
        {
            _stockRepository = stockRepository;
            _stockExceptionHelper = stockExceptionHelper;
        }
        
        public async Task<Stock> CheckStockBranchAndProductId(Guid branchId,Guid productId)
        {
            var result = await _stockRepository.GetAsync(x => x.ProductId == productId && x.BranchId == branchId);

            if (result is null)
                _stockExceptionHelper.ThrowStockNotFound();

            return result;
        }
    }
}
