using AutoMapper;
using Krop.DTO.Dtos.Departments;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Departments.Profiles
{
    public class DepartmentProfiles:Profile
    {
        public DepartmentProfiles()
        {
            CreateMap<Department, CreateDepartmentDTO>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDTO>().ReverseMap();
            CreateMap<Department, GetDepartmentDTO>().ReverseMap();
            CreateMap<Department, GetDepartmentComboBoxDTO>().ReverseMap();
        }
    }
}
