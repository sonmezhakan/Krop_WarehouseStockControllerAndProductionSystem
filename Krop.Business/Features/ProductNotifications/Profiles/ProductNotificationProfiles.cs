using AutoMapper;
using Krop.DTO.Dtos.ProductNotifications;
using Krop.Entities.Entities;

namespace Krop.Business.Features.ProductNotifications.Profiles
{
    public class ProductNotificationProfiles:Profile
    {
        public ProductNotificationProfiles()
        {
            CreateMap<ProductNotification, CreateProductNotificationDTO>().ReverseMap();
            CreateMap<ProductNotification, UpdateProductNotificationDTO>().ReverseMap();
            CreateMap<ProductNotification, GetProductNotificationDTO>().ReverseMap();
            CreateMap<ProductNotification, GetProductNotificationListDTO>()
                .ForMember(dest=>dest.ProductName, opt=>opt.MapFrom(src=>src.Product.ProductName))
                .ForMember(dest=>dest.ProductCode, opt=>opt.MapFrom(src=>src.Product.ProductCode))
                .ForMember(dest=>dest.BranchName, opt=>opt.MapFrom(src=>src.Branch.BranchName))
                .ForMember(dest=>dest.SenderUserName, opt=>opt.MapFrom(src=>src.SenderAppUser.UserName))
                .ForMember(dest=>dest.SentUserName, opt=>opt.MapFrom(src=>src.SentAppUser.UserName))
                .ForMember(dest=>dest.UnitsInStock, opt=>opt.MapFrom(src=>src.Product.Stocks))
                .ForMember(dest=>dest.CriticalStock, opt=>opt.MapFrom(src=>src.Product.CriticalStock))
                .ReverseMap();
        }
    }
}
