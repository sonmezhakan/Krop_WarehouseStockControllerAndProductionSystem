using Krop.DTO.Dtos.Departments;

namespace Krop.Common.Helpers.WebApiRequests.Departments
{
    public interface IDepartmentRequest
    {
        Task<HttpResponseMessage> GetAllAsync();
        Task<HttpResponseMessage> GetAllComboBoxAsync();
        Task<HttpResponseMessage> GetByIdAsync(Guid id);
        Task<HttpResponseMessage> AddAsync(CreateDepartmentDTO createDepartmentDTO);
        Task<HttpResponseMessage> UpdateAsync(UpdateDepartmentDTO updateDepartmentDTO);
        Task<HttpResponseMessage> DeleteAsync(Guid id);
    }
}
