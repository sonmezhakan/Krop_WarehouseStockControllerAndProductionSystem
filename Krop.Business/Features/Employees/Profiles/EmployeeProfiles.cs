using AutoMapper;
using Krop.DTO.Dtos.Employees;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Employees.Profiles
{
    public class EmployeeProfiles : Profile
    {
        public EmployeeProfiles()
        {
            CreateMap<Employee, CreateEmployeeDTO>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDTO>().ReverseMap();
            CreateMap<Employee, GetEmployeeDTO>().ReverseMap();
            CreateMap<Employee, GetEmployeeComboBoxDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AppUser.UserName))
                .ReverseMap();

            CreateMap<Employee, GetEmployeeCartDTO>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName))
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName))
                .ReverseMap();

            CreateMap<Employee, GetEmployeeListDTO>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.AppUser.UserName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.AppUser.Person.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.AppUser.Person.LastName))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName))
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName))
                .ForMember(dest => dest.NationalNumber, opt => opt.MapFrom(src => src.AppUser.Person.NationalNumber))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.AppUser.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.AppUser.Email))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.AppUser.Address.Country))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.AppUser.Address.City))
                .ForMember(dest => dest.Adress, opt => opt.MapFrom(src => src.AppUser.Address.Addres))
                .ReverseMap();
        }
    }
}
