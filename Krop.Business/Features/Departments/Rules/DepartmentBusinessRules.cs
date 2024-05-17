using Krop.Business.Features.Departments.ExceptionHelpers;
using Krop.DataAccess.Repositories.Abstracts;

namespace Krop.Business.Features.Departments.Rules
{
    public class DepartmentBusinessRules
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly DepartmentExceptionHelper _departmentExceptionHelper;

        public DepartmentBusinessRules(IDepartmentRepository departmentRepository,DepartmentExceptionHelper departmentExceptionHelper)
        {
            _departmentRepository = departmentRepository;
            _departmentExceptionHelper = departmentExceptionHelper;
        }

        public async Task DepartmentNameCannotBeDuplicatedWhenInserted(string departmentName)
        {
            bool result = await _departmentRepository.AnyAsync(d=>d.DepartmentName == departmentName);

            if (result)
                _departmentExceptionHelper.ThrowDepartmentNameExists();
        }
        public async Task DepartmentNameCannotBeDuplicateWhenUpdated(string oldDepartmentName,string newDepartmentName)
        {
            if(oldDepartmentName != newDepartmentName)
            {
                bool result = await _departmentRepository.AnyAsync(d => d.DepartmentName == newDepartmentName);

                if (result)
                    _departmentExceptionHelper.ThrowDepartmentNameExists();
            }
        }
    }
}
