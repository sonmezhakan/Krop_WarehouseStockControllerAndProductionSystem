using Krop.DTO.Dtos.Employees;

namespace Krop.Common.Helpers.WebApiRequests.Employees
{
    public interface IEmployeeRequest
    {
        Task<HttpResponseMessage> GetAllAsync();
        Task<HttpResponseMessage> GetAllComboBoxAsync();
        Task<HttpResponseMessage> GetByIdAsync(Guid id);
        Task<HttpResponseMessage> GetByIdCartAsync(Guid id);
        Task<HttpResponseMessage> AddAsync(CreateEmployeeDTO createEmployeeDTO);
        Task<HttpResponseMessage> UpdateAsync(UpdateEmployeeDTO updateEmployeeDTO);
        Task<HttpResponseMessage> DeleteAsync(Guid id);
    }
}
