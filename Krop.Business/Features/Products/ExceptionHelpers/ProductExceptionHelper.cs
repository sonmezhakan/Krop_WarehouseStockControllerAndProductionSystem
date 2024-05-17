using Krop.Business.Exceptions.Types;
using Krop.Business.Features.Products.Constants;

namespace Krop.Business.Features.Products.ExceptionHelpers
{
    public class ProductExceptionHelper
    {
        public void ThrowProductNotFound() => throw new NotFoundException(ProductMessages.ProductNotFound);
        public void ThrowProductNameExists() => throw new BusinessException(ProductMessages.ProductNameExists);
        public void ThrowProductCodeExists() => throw new BusinessException(ProductMessages.ProductNameExists);
    }
}
