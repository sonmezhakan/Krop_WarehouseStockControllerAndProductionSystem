using Krop.Business.Features.StockTransfers.ExceptionHelpers;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.Business.Features.StockTransfers.Rules
{
    public class StockTransferBusinessRules
    {
        private readonly IStockTransferRepository _stockTransferRepository;
        private readonly StockTransferExceptionHelper _stockTransferExceptionHelper;

        public StockTransferBusinessRules(IStockTransferRepository stockTransferRepository,StockTransferExceptionHelper stockTransferExceptionHelper)
        {
            _stockTransferRepository = stockTransferRepository;
            _stockTransferExceptionHelper = stockTransferExceptionHelper;
        }

        public async Task<StockTransfer> CheckByStockTransferId(Guid id)
        {
            var result = await _stockTransferRepository.GetAsync(x => x.Id == id);
            if (result == null)
                _stockTransferExceptionHelper.ThrowStockTransferNotFound();

            return result;
        }
        public async Task CheckSenderAndSentBranchId(Guid senderBranchId,Guid sentBranchId)
        {
            if(senderBranchId == sentBranchId)
                _stockTransferExceptionHelper.ThrowStockTransferSenderAndSentBranchExists();

        }
    }
}
