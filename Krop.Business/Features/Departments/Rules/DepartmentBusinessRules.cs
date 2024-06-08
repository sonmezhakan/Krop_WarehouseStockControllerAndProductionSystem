using Krop.Business.Features.Departments.Constants;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Features.Departments.Rules
{
    public class DepartmentBusinessRules
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentBusinessRules(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IDataResult<Department>> CheckByDepartmentId(Guid id)
        {
            var result = await _departmentRepository.GetAsync(d => d.Id == id);
            if (result is null)
                return new ErrorDataResult<Department>(StatusCodes.Status404NotFound,DepartmentMessages.DepartmentNotFound);

            return new SuccessDataResult<Department>(result);
        }
        public async Task<IDataResult<Department>> CheckByDepartmentName(string departmentName)
        {
            var result = await _departmentRepository.GetAsync(d => d.DepartmentName == departmentName);
            if (result is null)
                return new ErrorDataResult<Department>(StatusCodes.Status404NotFound, DepartmentMessages.DepartmentNotFound);

            return new SuccessDataResult<Department>(result);
        }
        public async Task<IResult> DepartmentNameCannotBeDuplicatedWhenInserted(string departmentName)
        {
            bool result = await _departmentRepository.AnyAsync(d=>d.DepartmentName == departmentName);

            if (result)
                return new ErrorResult(StatusCodes.Status400BadRequest, DepartmentMessages.DepartmentNameExists);

            return new SuccessResult();
        }
        public async Task<IResult> DepartmentNameCannotBeDuplicateWhenUpdated(string oldDepartmentName,string newDepartmentName)
        {
            if(oldDepartmentName != newDepartmentName)
            {
                bool result = await _departmentRepository.AnyAsync(d => d.DepartmentName == newDepartmentName);

                if (result)
                    return new ErrorResult(StatusCodes.Status400BadRequest, DepartmentMessages.DepartmentNameExists);
            }
            return new SuccessResult();
        }
    }
}
