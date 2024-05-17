using Krop.Business.Exceptions.Types;
using Krop.Business.Features.Brands.Constants;

namespace Krop.Business.Features.Brands.ExceptionHelpers
{
    public class BrandExceptionHelper
    {
        public void ThrowBrandNotFound() => throw new NotFoundException(BrandMessages.BrandNotFound);
        public void ThrowBrandNameExists() => throw new BusinessException(BrandMessages.BrandNameExists);
    }
}
