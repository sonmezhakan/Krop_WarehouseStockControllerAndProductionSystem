using Krop.Business.Features.Employees.Constants;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Features.Employees.Rules
{
    public class EmployeeBusinessRules
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeBusinessRules(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IDataResult<Employee>> CheckByEmployeeId(Guid id)
        {
            var result = await _employeeRepository.GetAsync(e => e.AppUserId == id);
            if (result is null)
                return new ErrorDataResult<Employee>(StatusCodes.Status404NotFound, EmployeeMessages.EmployeeNotFound);

            return new SuccessDataResult<Employee>(result);
        }
        public async Task<IResult> EmployeeCannotBeDuplicatedWhenInserted(Guid Id)
        {
            bool result = await _employeeRepository.AnyAsync(x=>x.AppUserId == Id);
            if (result)
                return new ErrorResult(StatusCodes.Status400BadRequest, EmployeeMessages.EmployeeExists);

            return new SuccessResult();
        }
        public async Task<IResult> CheckEmployeeBranch(Guid Id,Guid branchId)
        {
            bool result = await _employeeRepository.AnyAsync(
                predicate:x=>x.AppUserId == Id && x.BranchId == branchId && x.WorkingStatu == true);

            if (!result)
                return new ErrorResult(StatusCodes.Status401Unauthorized, EmployeeMessages.EmployeeNotBranchAuthority);

            return new SuccessResult();

        }
        public async Task<IResult> CheckEmployeeSenderAndSentBranch(Guid Id, Guid senderBranchId,Guid sentBranchId)
        {
            bool result = await _employeeRepository.AnyAsync(predicate: x => x.AppUserId == Id && (x.BranchId == senderBranchId || x.BranchId == sentBranchId));

            if (!result)
                return new ErrorResult(StatusCodes.Status401Unauthorized, EmployeeMessages.EmployeeNotBranchAuthority);

            return new SuccessResult();
        }
        public async Task<IResult> CheckAppUserIfEmployee(Guid appUserId)
        {
            bool result = await _employeeRepository.AnyAsync(x => x.AppUserId == appUserId && x.WorkingStatu == true);
            if (!result)
                return new ErrorResult(StatusCodes.Status403Forbidden, EmployeeMessages.EmployeeNotFound);

            return new SuccessResult();
        }


    }
}
