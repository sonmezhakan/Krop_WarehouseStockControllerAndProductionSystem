using AutoMapper;
using Krop.DTO.Dtos.ProductionStockExit;
using Krop.Entities.Entities;

namespace Krop.Business.Features.ProductionStockExits.Profiles
{
    public class ProductionStockExitProfiles:Profile
    {
        public ProductionStockExitProfiles()
        {
            CreateMap<ProductionStockExit, CreateProductionStockExitDTO>().ReverseMap();
            CreateMap<ProductionStockExit, UpdateProductionStockExitDTO>().ReverseMap();
            CreateMap<ProductionStockExit, GetProductionStockExitDTO>().ReverseMap();

        }
    }
}
