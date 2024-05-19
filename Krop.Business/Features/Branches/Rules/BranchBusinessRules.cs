using Krop.Business.Features.Branches.ExceptionHelper;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Branches.Rules
{
    public class BranchBusinessRules
    {
        private readonly IBranchRepository _branchRepository;
        private readonly BranchExceptionHelper _branchExceptionHelper;

        public BranchBusinessRules(IBranchRepository branchRepository,BranchExceptionHelper branchExceptionHelper)
        {
            _branchRepository = branchRepository;
            _branchExceptionHelper = branchExceptionHelper;
        }

        public async Task<Branch> CheckByBranchId(Guid id)
        {
            var result = await _branchRepository.GetAsync(b => b.Id == id);
            if (result is null)
                _branchExceptionHelper.ThrowBranchNotFound();

            return result;
        }
        public async Task BranchNameCannotBeDuplicatedWhenInserted(string branchName)
        {
            bool result = await _branchRepository.AnyAsync(b=>b.BranchName == branchName);

            if (result)
                _branchExceptionHelper.ThrowBranchNameExists();
        }

        public async Task BranchNameCannotBeDuplicatedWhenInserted(string oldBranchName, string newBranchName)
        {
            if(oldBranchName != newBranchName)
            {
                bool result = await _branchRepository.AnyAsync(b => b.BranchName == newBranchName);

                if (result)
                    _branchExceptionHelper.ThrowBranchNameExists();
            }
        }
    }
}
