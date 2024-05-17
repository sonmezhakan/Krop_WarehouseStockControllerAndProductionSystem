using AutoMapper;
using Krop.Business.Features.AppUsers.Dtos;
using Krop.Entities.Entities;

namespace Krop.Business.Features.AppUsers.Profiles
{
    public class AppUserProfiles:Profile
    {
        public AppUserProfiles()
        {
            CreateMap<AppUser, CreateAppUserDTO>().ReverseMap();
            CreateMap<AppUser, UpdateAppUserDTO>().ReverseMap();
            CreateMap<AppUser, UpdateAppUserPasswordDTO>().ReverseMap();
            CreateMap<AppUser, GetAppUserDTO>().ReverseMap();
        }
    }
}
