using Krop.Business.Features.StockTransfers.Constants;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Features.StockTransfers.Rules
{
    public class StockTransferBusinessRules
    {
        private readonly IStockTransferRepository _stockTransferRepository;

        public StockTransferBusinessRules(IStockTransferRepository stockTransferRepository)
        {
            _stockTransferRepository = stockTransferRepository;
        }

        public async Task<IDataResult<StockTransfer>> CheckByStockTransferId(Guid id)
        {
            var result = await _stockTransferRepository.GetAsync(x => x.Id == id);
            if (result == null)
                return new ErrorDataResult<StockTransfer>(StatusCodes.Status404NotFound, StockTransferMessages.StockTransferNotFound);

            return new SuccessDataResult<StockTransfer>(result);
        }
        public async Task<IResult> CheckSenderAndSentBranchId(Guid senderBranchId,Guid sentBranchId)
        {
            if (senderBranchId == sentBranchId)
                return new ErrorResult(StatusCodes.Status400BadRequest, StockTransferMessages.SenderAndSentBranchExists);

            return new SuccessResult();
        }
    }
}
