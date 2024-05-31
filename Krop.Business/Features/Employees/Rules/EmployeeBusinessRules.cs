using Krop.Business.Features.Employees.ExceptionHelpers;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Employees.Rules
{
    public class EmployeeBusinessRules
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly EmployeeExceptionHelper _employeeExceptionHelper;

        public EmployeeBusinessRules(IEmployeeRepository employeeRepository,EmployeeExceptionHelper employeeExceptionHelper)
        {
            _employeeRepository = employeeRepository;
            _employeeExceptionHelper = employeeExceptionHelper;
        }

        public async Task<Employee> CheckByEmployeeId(Guid id)
        {
            var result = await _employeeRepository.GetAsync(e => e.AppUserId == id);
            if (result is null)
                _employeeExceptionHelper.ThrowEmployeeNotFound();

            return result;
        }
        public async Task EmployeeCannotBeDuplicatedWhenInserted(Guid Id)
        {
            bool result = await _employeeRepository.AnyAsync(x=>x.AppUserId == Id);
            if (result)
               _employeeExceptionHelper.ThrowEmployeeExists();
        }
        public async Task CheckEmployeeBranch(Guid Id,Guid branchId)
        {
            bool result = await _employeeRepository.AnyAsync(
                predicate:x=>x.AppUserId == Id && x.BranchId == branchId);

            if (!result)
                _employeeExceptionHelper.ThrowNotBranchAuthority();
        }
        public async Task CheckEmployeeSenderAndSentBranch(Guid Id, Guid senderBranchId,Guid sentBranchId)
        {
            bool result = await _employeeRepository.AnyAsync(predicate: x => x.AppUserId == Id && (x.BranchId == senderBranchId || x.BranchId == sentBranchId));

            if (!result)
                _employeeExceptionHelper.ThrowNotBranchAuthority();
        }
    }
}
