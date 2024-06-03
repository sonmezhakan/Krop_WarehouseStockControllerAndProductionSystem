using AutoMapper;
using Krop.DTO.Dtos.Branches;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Branches.Profiles
{
    public class BranchProfiles:Profile
    {
        public BranchProfiles()
        {
            CreateMap<Branch, CreateBranchDTO>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Contact.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Contact.Email))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Addres, opt => opt.MapFrom(src => src.Address.Addres))
                .ReverseMap();
            CreateMap<Branch, UpdateBranchDTO>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Contact.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Contact.Email))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Addres, opt => opt.MapFrom(src => src.Address.Addres))
                .ReverseMap();
            CreateMap<Branch, GetBranchDTO>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Contact.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Contact.Email))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Addres, opt => opt.MapFrom(src => src.Address.Addres))
                .ReverseMap();
            CreateMap<Branch, GetBranchComboBoxDTO>().ReverseMap();
        }
    }
}
