using Krop.Business.Exceptions.Types;
using Krop.Business.Features.StockTransfers.Constants;

namespace Krop.Business.Features.StockTransfers.ExceptionHelpers
{
    public class StockTransferExceptionHelper
    {
        public void ThrowStockTransferNotFound() => throw new NotFoundException(StockTransferMessages.StockTransferNotFound);
        public void ThrowStockTransferSenderAndSentBranchExists() => throw new BusinessException(StockTransferMessages.SenderAndSentBranchExists);
    }
}
