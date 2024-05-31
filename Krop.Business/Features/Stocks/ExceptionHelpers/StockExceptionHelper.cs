using Krop.Business.Exceptions.Types;
using Krop.Business.Features.Stocks.Constants;

namespace Krop.Business.Features.Stocks.ExceptionHelpers
{
    public class StockExceptionHelper
    {
        public void ThrowStockNotFound() => throw new NotFoundException(StockMessages.StockNotFound);
    }
}
