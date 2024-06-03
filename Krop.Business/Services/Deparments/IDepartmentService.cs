﻿using Krop.Common.Utilits.Result;
using Krop.DTO.Dtos.Departments;

namespace Krop.Business.Services.Deparments
{
    public interface IDepartmentService
    {
        Task<IResult> AddAsync(CreateDepartmentDTO createDepartmentDTO);
        Task<IResult> AddRangeAsync(List<CreateDepartmentDTO> createDepartmentDTOs);

        Task<IResult> UpdateAsync(UpdateDepartmentDTO updateDepartmentDTO);
        Task<IResult> UpdateRangeAsync(List<UpdateDepartmentDTO> updateDepartmentDTOs);

        Task<IResult> DeleteAsync(Guid id);
        Task<IResult> DeleteRangeAsync(List<Guid> ids);

        Task<IDataResult<IEnumerable<GetDepartmentDTO>>> GetAllAsync();
        Task<IDataResult<GetDepartmentDTO>> GetById(Guid id);
        Task<IDataResult<GetDepartmentDTO>> GetByDepartmentName(string departmentName);

        Task<IDataResult<IEnumerable<GetDepartmentComboBoxDTO>>> GetAllComboBoxAsync();
    }
}
