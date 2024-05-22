using AutoMapper;
using Krop.Business.Features.Categories.Dtos;
using Krop.Entities.Entities;

namespace Krop.Business.Features.Categories.Profiles
{
    public class CategoryProfiles : Profile
    {
        public CategoryProfiles()
        {
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, GetCategoryDTO>().ReverseMap();

            CreateMap<Category, GetCategoryComboBoxDTO>().ReverseMap();
        }
    }
}
