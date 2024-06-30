using Krop.DataAccess.Repositories.Abstracts;

namespace Krop.Business.Features.StockTransfers.Rules
{
    public class StockTransferBusinessRules
    {
        private readonly IStockTransferRepository _stockTransferRepository;

        public StockTransferBusinessRules(IStockTransferRepository stockTransferRepository)
        {
            _stockTransferRepository = stockTransferRepository;
        }

    }
}
