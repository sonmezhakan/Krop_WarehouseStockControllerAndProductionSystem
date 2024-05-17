using AutoMapper;
using Krop.Business.Features.AppUsers.Dtos;
using Krop.Entities.Entities;

namespace Krop.Business.Features.AppUserRoles.Profiles
{
    public class AppUserRoleProfiles:Profile
    {
        public AppUserRoleProfiles()
        {
            CreateMap<AppUserRole, CreateAppUserDTO>().ReverseMap();
            CreateMap<AppUserRole, UpdateAppUserDTO>().ReverseMap();
            CreateMap<AppUserRole, GetAppUserDTO>().ReverseMap();
        }
    }
}
