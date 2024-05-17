using Krop.Business.Exceptions.Types;
using Krop.Business.Features.Customers.Constants;

namespace Krop.Business.Features.Customers.ExceptionHelpers
{
    public class CustomerExceptionHelper
    {
        public void ThrowCustomerNotFound() => throw new NotFoundException(CustomerMessages.CustomerNotFound);
    }
}
