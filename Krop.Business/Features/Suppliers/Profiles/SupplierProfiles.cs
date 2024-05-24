using AutoMapper;
using Krop.Business.Features.Suppliers.Dtos;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Suppliers.Profiles
{
    public class SupplierProfiles:Profile
    {
        public SupplierProfiles()
        {
            CreateMap<Supplier, CreateSupplierDTO>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName))
                .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.Company.ContactName))
                .ForMember(dest => dest.ContactTitle, opt => opt.MapFrom(src => src.Company.ContactTitle))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Contact.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Contact.Email))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Addres, opt => opt.MapFrom(src => src.Address.Addres))
                .ReverseMap();
            CreateMap<Supplier, UpdateSupplierDTO>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName))
                .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.Company.ContactName))
                .ForMember(dest => dest.ContactTitle, opt => opt.MapFrom(src => src.Company.ContactTitle))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Contact.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Contact.Email))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Addres, opt => opt.MapFrom(src => src.Address.Addres))
                .ReverseMap();
            CreateMap<Supplier, GetSupplierDTO>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName))
                .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.Company.ContactName))
                .ForMember(dest => dest.ContactTitle, opt => opt.MapFrom(src => src.Company.ContactTitle))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Contact.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Contact.Email))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest=>dest.Addres, opt=> opt.MapFrom(src=>src.Address.Addres))
                .ReverseMap();
            CreateMap<Supplier, GetSupplierComboBoxDTO>()
                .ForMember(dest=>dest.CompanyName, opt=>opt.MapFrom(src=>src.Company.CompanyName))
                .ReverseMap();
        }
    }
}
