using AutoMapper;
using Krop.Business.Features.Customers.Dtos;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Customers.Profiles
{
    public class CustomerProfiles:Profile
    {
        public CustomerProfiles()
        {
            CreateMap<Customer, CreateCustomerDTO>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDTO>().ReverseMap();
            CreateMap<Customer, GetCustomerDTO>().ReverseMap();
        }
    }
}
