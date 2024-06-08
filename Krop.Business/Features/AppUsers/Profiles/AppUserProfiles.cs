using AutoMapper;
using Krop.DTO.Dtos.AppUsers;
using Krop.Entities.Entities;

namespace Krop.Business.Features.AppUsers.Profiles
{
    public class AppUserProfiles : Profile
    {
        public AppUserProfiles()
        {
            CreateMap<AppUser, CreateAppUserDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Person.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Person.LastName))
                .ForMember(dest => dest.NationalNumber, opt => opt.MapFrom(src => src.Person.NationalNumber))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Addres, opt => opt.MapFrom(src => src.Address.Addres))
                .ReverseMap();
            CreateMap<AppUser, UpdateAppUserDTO>()
                 .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Person.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Person.LastName))
                .ForMember(dest=>dest.NationalNumber, opt=>opt.MapFrom(src=>src.Person.NationalNumber))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Addres, opt => opt.MapFrom(src => src.Address.Addres))
                .ReverseMap();
            CreateMap<AppUser, UpdateAppUserPasswordDTO>().ReverseMap();
            CreateMap<AppUser, GetAppUserDTO>()
                 .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Person.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Person.LastName))
                .ForMember(dest => dest.NationalNumber, opt => opt.MapFrom(src => src.Person.NationalNumber))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Addres, opt => opt.MapFrom(src => src.Address.Addres))
                .ReverseMap();

            CreateMap<AppUser, GetAppUserComboBoxDTO>().ReverseMap();

            CreateMap<LoginDTO, AppUser>().ReverseMap();
        }
    }
}
