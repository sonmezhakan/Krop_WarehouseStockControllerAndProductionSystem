using Krop.Business.Exceptions.Types;
using Krop.Business.Features.Categories.Constants;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Categories.ExceptionHelpers
{
    public class CategoryExceptionHelper
    {
        public void ThrowCategoryNotFoundException() => throw new NotFoundException(CategoryMessages.CategoryNotFound);
        public void ThrowCategoryNameExistsdException() => throw new BusinessException(CategoryMessages.CategoryNameExists);
    }
}
