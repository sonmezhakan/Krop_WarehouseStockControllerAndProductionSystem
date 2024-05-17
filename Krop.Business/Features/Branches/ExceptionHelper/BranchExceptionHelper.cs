using Krop.Business.Exceptions.Types;
using Krop.Business.Features.Branches.Constants;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Branches.ExceptionHelper
{
    public class BranchExceptionHelper
    {
        public void ThrowBranchNotFound() => throw new NotFoundException(BranchMessages.BranchNotFound);

        public void ThrowBranchNameExists() => throw new BusinessException(BranchMessages.BranchNameExists);
    }
}
