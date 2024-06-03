using AutoMapper;
using Krop.DTO.Dtos.Productions;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Productions.Profiles
{
    public class ProductionProfiles:Profile
    {
        public ProductionProfiles()
        {
            CreateMap<Production, CreateProductionDTO>().ReverseMap();
            CreateMap<Production, UpdateProductionDTO>().ReverseMap();
            CreateMap<Production, GetProductionDTO>().ReverseMap();
            CreateMap<Production, GetProductionListDTO>()
                .ForMember(dest=>dest.BranchName, opt=>opt.MapFrom(src=>src.Branch.BranchName))
                .ForMember(dest=>dest.ProductName, opt=>opt.MapFrom(src=>src.Product.ProductName))
                .ForMember(dest=>dest.ProductCode, opt=>opt.MapFrom(src=>src.Product.ProductCode))
                .ForMember(dest=>dest.UserName, opt=>opt.MapFrom(src=>src.AppUser.UserName))
                .ReverseMap();

            CreateMap<GetProductionDTO, CreateProductionDTO>().ReverseMap();
            CreateMap<GetProductionDTO, UpdateProductionDTO>().ReverseMap();
        }
    }
}
