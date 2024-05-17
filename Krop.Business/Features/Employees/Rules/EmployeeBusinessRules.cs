using Krop.Business.Features.Employees.ExceptionHelpers;
using Krop.DataAccess.Repositories.Abstracts;

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
        public async Task EmployeeCannotBeDuplicatedWhenInserted(Guid id)
        {
            bool result = await _employeeRepository.AnyAsync(x=>x.Id == id);
            if (result)
               _employeeExceptionHelper.ThrowEmployeeExists();
        }
    }
}
