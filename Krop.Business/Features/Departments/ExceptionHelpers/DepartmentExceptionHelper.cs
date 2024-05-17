using Krop.Business.Exceptions.Types;
using Krop.Business.Features.Departments.Constants;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Departments.ExceptionHelpers
{
    public class DepartmentExceptionHelper
    {
        public void ThrowDepartmentNotFound() => throw new NotFoundException(DepartmentMessages.DepartmentNotFound);
        public void ThrowDepartmentNameExists() => throw new BusinessException(DepartmentMessages.DepartmentNameExists);
    }
}
