using AutoMapper;
using Krop.DTO.Dtos.StockInputs;
using Krop.Entities.Entities;

namespace Krop.Business.Features.StockInputs.Profiles
{
    public class StockInputProfile:Profile
    {
        public StockInputProfile()
        {
            CreateMap<StockInput, CreateStockInputDTO>().ReverseMap();
            CreateMap<StockInput, UpdateStockInputDTO>().ReverseMap();
            CreateMap<StockInput, GetStockInputDTO>().ReverseMap();
            CreateMap<StockInput, GetStockInputListDTO>()
                .ForMember(dest=>dest.ProductName,opt=>opt.MapFrom(src=>src.Product.ProductName))
                .ForMember(dest=>dest.ProductCode,opt=>opt.MapFrom(src=>src.Product.ProductCode))
                .ForMember(dest=>dest.BranchName,opt=>opt.MapFrom(src=>src.Branch.BranchName))
                .ForMember(dest=>dest.CompanyName,opt=>opt.MapFrom(src=>src.Supplier.Company.CompanyName))
                .ForMember(dest=>dest.UserName,opt=>opt.MapFrom(src=>src.AppUser.UserName))
                .ReverseMap();
        }
    }
}
