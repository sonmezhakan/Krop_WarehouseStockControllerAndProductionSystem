using AutoMapper;
using Krop.Business.Features.Employees.Dtos;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Employees.Profiles
{
    public class EmployeeProfiles:Profile
    {
        public EmployeeProfiles()
        {
            CreateMap<Employee, CreateEmployeeDTO>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDTO>().ReverseMap();
            CreateMap<Employee, GetEmployeeDTO>().ReverseMap();
        }
    }
}
