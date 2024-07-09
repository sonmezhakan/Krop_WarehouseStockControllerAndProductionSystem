using Krop.Business.Features.StockTransfers.Constants;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
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
        public async Task<IResult> SenderBranchAndSentBranchExists(Guid senderBranchId, Guid sentBranchId)
        {
            return senderBranchId == sentBranchId ?
                new ErrorResult(StatusCodes.Status400BadRequest, StockTransferMessages.SenderAndSentBranchExists) :
                new SuccessResult();
        }

    }
}
