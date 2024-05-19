using Krop.Business.Features.Departments.ExceptionHelpers;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;

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

        public async Task<Department> CheckByDepartmentId(Guid id)
        {
            var result = await _departmentRepository.GetAsync(d => d.Id == id);
            if (result is null)
                _departmentExceptionHelper.ThrowDepartmentNotFound();

            return result;
        }
        public async Task<Department> CheckByDepartmentName(string departmentName)
        {
            var result = await _departmentRepository.GetAsync(d => d.DepartmentName == departmentName);
            if(result is null)
                _departmentExceptionHelper.ThrowDepartmentNotFound();

            return result;
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
