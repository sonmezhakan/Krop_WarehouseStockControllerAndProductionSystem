using Krop.Business.Exceptions.Types;
using Krop.Business.Features.Employees.Constants;

namespace Krop.Business.Features.Employees.ExceptionHelpers
{
    public class EmployeeExceptionHelper
    {
        public void ThrowEmployeeNotFound() => throw new NotFoundException(EmployeeMessages.EmployeeNotFound);
        public void ThrowEmployeeExists() => throw new BusinessException(EmployeeMessages.EmployeeExists);
    }
}
