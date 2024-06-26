﻿using Krop.Business.Features.Branches.Constants;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Features.Branches.Rules
{
    public class BranchBusinessRules
    {
        private readonly IBranchRepository _branchRepository;

        public BranchBusinessRules(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }
        public async Task<IResult> BranchNameCannotBeDuplicatedWhenInserted(string branchName)
        {
            bool result = await _branchRepository.AnyAsync(b=>b.BranchName == branchName);

            if (result)
                return new ErrorResult(StatusCodes.Status400BadRequest, BranchMessages.BranchNameExists);

            return new SuccessResult();
        }

        public async Task<IResult> BranchNameCannotBeDuplicatedWhenUpdated(string oldBranchName, string newBranchName)
        {
            if(oldBranchName != newBranchName)
            {
                bool result = await _branchRepository.AnyAsync(b => b.BranchName == newBranchName);

                if (result)
                    return new ErrorResult(StatusCodes.Status400BadRequest, BranchMessages.BranchNameExists);
            }
            return new SuccessResult();
        }
    }
}
