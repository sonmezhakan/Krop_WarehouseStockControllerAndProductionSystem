using Krop.Business.Features.Departments.Dtos;

namespace Krop.Business.Services.Deparments
{
    public interface IDepartmentService
    {
        Task<bool> AddAsync(CreateDepartmentDTO createDepartmentDTO);
        Task<bool> AddRangeAsync(List<CreateDepartmentDTO> createDepartmentDTOs);

        Task<bool> UpdateAsync(UpdateDepartmentDTO updateDepartmentDTO);
        Task<bool> UpdateRangeAsync(List<UpdateDepartmentDTO> updateDepartmentDTOs);

        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteRangeAsync(List<Guid> ids);

        Task<IEnumerable<GetDepartmentDTO>> GetAllAsync();
        Task<GetDepartmentDTO> GetById(Guid id);
        Task<GetDepartmentDTO> GetByDepartmentName(string departmentName);
    }
}
