using AutoMapper;
using Krop.Business.Features.Brands.Dtos;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Brands.Profiles
{
    public class BrandProfiles:Profile
    {
        public BrandProfiles()
        {
            CreateMap<Brand, CreateBrandDTO>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Contact.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Contact.Email))
                .ReverseMap();
            CreateMap<Brand, UpdateBrandDTO>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Contact.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Contact.Email))
                .ReverseMap();
            CreateMap<Brand, GetBrandDTO>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Contact.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Contact.Email))
                .ReverseMap();
            CreateMap<Brand, GetBrandComboBoxDTO>().ReverseMap();
        }
    }
}
