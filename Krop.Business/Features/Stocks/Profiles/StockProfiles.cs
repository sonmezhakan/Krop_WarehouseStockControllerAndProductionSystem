using AutoMapper;
using Krop.DTO.Dtos.Stocks;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Stocks.Profiles
{
    public class StockProfiles:Profile
    {
        public StockProfiles()
        {
            CreateMap<Stock, GetStockListDTO>()
                .ForMember(dest=>dest.BranchName, opt=>opt.MapFrom(src=>src.Branch.BranchName))
                .ForMember(dest=>dest.ProductName, opt=>opt.MapFrom(src=>src.Product.ProductName))
                .ForMember(dest=>dest.ProductCode, opt=>opt.MapFrom(src=>src.Product.ProductCode))
                .ForMember(dest=>dest.CriticalStock, opt=>opt.MapFrom(src=>src.Product.CriticalStock))
                .ReverseMap();
        }
    }
}
