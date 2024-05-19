using Krop.Business.Features.Employees.Dtos;
using Krop.Common.Utilits.Result;

namespace Krop.Business.Services.Employees
{
    public interface IEmployeeService
    {
        Task<IResult> AddAsync(CreateEmployeeDTO createEmployeeDTO);
        Task<IResult> UpdateAsync(UpdateEmployeeDTO updateEmployeeDTO);
        Task<IDataResult<IEnumerable<GetEmployeeDTO>>> GetAllAsync();
        Task<IDataResult<GetEmployeeDTO>> GetByIdAsync(Guid id);
    }
}
