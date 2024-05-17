using AutoMapper;
using Krop.Business.Features.Suppliers.Dtos;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Suppliers.Profiles
{
    public class SupplierProfiles:Profile
    {
        public SupplierProfiles()
        {
            CreateMap<Supplier, CreateSupplierDTO>().ReverseMap();
            CreateMap<Supplier, UpdateSupplierDTO>().ReverseMap();
            CreateMap<Supplier, GetSupplierDTO>().ReverseMap();
        }
    }
}
