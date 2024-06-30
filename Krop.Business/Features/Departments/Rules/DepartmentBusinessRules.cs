using Krop.Business.Features.Departments.Constants;
using Krop.Common.Utilits.Result;
using Krop.DataAccess.Repositories.Abstracts;
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
