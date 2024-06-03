using Krop.Business.Exceptions.Types;
using Krop.Business.Features.Productions.Constants;

namespace Krop.Business.Features.Productions.ExceptionHelpers
{
    public class ProductionExceptionHelper
    {
        public void ThrowProductionNotFound() => throw new NotFoundException(ProductionMessages.ProductionNotFound);
    }
}
