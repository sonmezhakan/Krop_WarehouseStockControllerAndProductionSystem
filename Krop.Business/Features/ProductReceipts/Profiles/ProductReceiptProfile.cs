using AutoMapper;
using Krop.Business.Features.ProductReceipts.Dtos;
using Krop.Entities.Entities;

namespace Krop.Business.Features.ProductReceipts.Profiles
{
    public class ProductReceiptProfile:Profile
    {
        public ProductReceiptProfile()
        {
            CreateMap<ProductReceipt, CreateProductReceiptDTO>().ReverseMap();
            CreateMap<ProductReceipt, UpdateProductReceiptDTO>().ReverseMap();
            CreateMap<ProductReceipt, GetProductReceiptDTO>().ReverseMap();
            CreateMap<ProductReceipt, GetProductReceiptListDTO>()
                .ForMember(dest=>dest.ProductId, opt=>opt.MapFrom(src=>src.ProductId))
                .ForMember(dest=>dest.ProductName, opt=>opt.MapFrom(src=>src.Product.ProductName))
                .ForMember(dest=>dest.ProductCode, opt=>opt.MapFrom(src=>src.Product.ProductCode))
                .ReverseMap();

        }
    }
}
