using Krop.Business.Features.Employees.Dtos;

namespace Krop.Business.Services.Employees
{
    public interface IEmployeeService
    {
        Task<bool> AddAsync(CreateEmployeeDTO createEmployeeDTO);
        Task<bool> UpdateAsync(UpdateEmployeeDTO updateEmployeeDTO);
        Task<IEnumerable<GetEmployeeDTO>> GetAllAsync();
        Task<GetEmployeeDTO> GetByIdAsync(Guid id);
    }
}
