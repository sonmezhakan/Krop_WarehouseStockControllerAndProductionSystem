using Krop.Business.Exceptions.Types;
using Krop.Business.Features.Suppliers.Constants;

namespace Krop.Business.Features.Suppliers.ExceptionHelpers
{
    public class SupplierExceptionHelper
    {
        public void ThrowSupplierNotFound() => throw new NotFoundException(SupplierMessages.SupplierNotFound);
    }
}
