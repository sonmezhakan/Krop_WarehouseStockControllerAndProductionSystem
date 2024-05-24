using AutoMapper;
using Krop.Business.Features.Products.Dtos;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Products.Profiles
{
    public class ProductProfiles : Profile
    {
        public ProductProfiles()
        {
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, GetProductDTO>().ReverseMap();
            CreateMap<Product, GetProductListDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.BrandName))
                .ReverseMap();

            CreateMap<Product, GetProductComboBoxDTO>().ReverseMap();
        }
    }
}
