using Krop.Business.Exceptions.Types;
using Krop.Business.Features.StockInputs.Constants;

namespace Krop.Business.Features.StockInputs.ExceptionHelpers
{
    public class StockInputExceptionHelper
    {
        public void ThrowStockInputNotFound() => throw new NotFoundException(StockInputMessages.StockInputNotFound);
    }
}
