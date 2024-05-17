using AutoMapper;
using Krop.Business.Features.Departments.Dtos;
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
        }
    }
}
