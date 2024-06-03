using AutoMapper;
using Krop.DTO.Dtos.Customers;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Customers.Profiles
{
    public class CustomerProfiles:Profile
    {
        public CustomerProfiles()
        {
            CreateMap<Customer, CreateCustomerDTO>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName))
                .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.Company.ContactName))
                .ForMember(dest => dest.ContactTitle, opt => opt.MapFrom(src => src.Company.ContactTitle))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Contact.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Contact.Email))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Addres, opt => opt.MapFrom(src => src.Address.Addres))
                .ForMember(dest=> dest.Invoice, opt=>opt.MapFrom(src=>src.Invoice))
                .ReverseMap();
            CreateMap<Customer, UpdateCustomerDTO>()
                 .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName))
                .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.Company.ContactName))
                .ForMember(dest => dest.ContactTitle, opt => opt.MapFrom(src => src.Company.ContactTitle))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Contact.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Contact.Email))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Addres, opt => opt.MapFrom(src => src.Address.Addres))
                .ForMember(dest => dest.Invoice, opt => opt.MapFrom(src => src.Invoice))
                .ReverseMap();
            CreateMap<Customer, GetCustomerDTO>()
                 .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName))
                .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.Company.ContactName))
                .ForMember(dest => dest.ContactTitle, opt => opt.MapFrom(src => src.Company.ContactTitle))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Contact.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Contact.Email))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Addres, opt => opt.MapFrom(src => src.Address.Addres))
                .ForMember(dest => dest.Invoice, opt => opt.MapFrom(src => src.Invoice))
                .ReverseMap();

            CreateMap<Customer, GetCustomerComboBoxDTO>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName))
                .ReverseMap();
        }
    }
}
