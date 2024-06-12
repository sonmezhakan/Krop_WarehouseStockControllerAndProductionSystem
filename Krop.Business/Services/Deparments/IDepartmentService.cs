using Krop.Common.Utilits.Result;
using Krop.DTO.Dtos.Departments;

namespace Krop.Business.Services.Deparments
{
    public interface IDepartmentService
    {
        Task<IResult> AddAsync(CreateDepartmentDTO createDepartmentDTO);
        Task<IResult> UpdateAsync(UpdateDepartmentDTO updateDepartmentDTO);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<IEnumerable<GetDepartmentDTO>>> GetAllAsync();
        Task<IDataResult<GetDepartmentDTO>> GetById(Guid id);

        Task<IDataResult<IEnumerable<GetDepartmentComboBoxDTO>>> GetAllComboBoxAsync();
    }
}
