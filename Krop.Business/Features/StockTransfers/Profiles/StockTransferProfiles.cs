using AutoMapper;
using Krop.Business.Features.StockTransfers.Dtos;
using Krop.Entities.Entities;

namespace Krop.Business.Features.StockTransfers.Profiles
{
    public class StockTransferProfiles : Profile
    {
        public StockTransferProfiles()
        {
            CreateMap<StockTransfer, CreateStockTransferDTO>().ReverseMap();
            CreateMap<StockTransfer, UpdateStockTransferDTO>().ReverseMap();
            CreateMap<StockTransfer, GetStockTransferDTO>().ReverseMap();
            CreateMap<StockTransfer, GetStockTransferListDTO>()
                .ForMember(dest=>dest.SenderBranchName,opt=>opt.MapFrom(src=>src.SenderBranch.BranchName))
                .ForMember(dest=>dest.SentBranchName,opt=>opt.MapFrom(src=>src.SentBranch.BranchName))
                .ForMember(dest=>dest.ProductName, opt=>opt.MapFrom(src=>src.Product.ProductName))
                .ForMember(dest=>dest.ProductCode, opt=>opt.MapFrom(src=>src.Product.ProductCode))
                .ForMember(dest=>dest.SenderAppUserName, opt => opt.MapFrom(src => src.AppUser.UserName))
                .ReverseMap();
        }
    }
}
