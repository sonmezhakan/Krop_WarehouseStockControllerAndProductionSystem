using AutoMapper;
using Krop.Business.Features.AppUserRoles.Dtos;
using Krop.Business.Features.AppUsers.Dtos;
using Krop.Entities.Entities;

namespace Krop.Business.Features.AppUserRoles.Profiles
{
    public class AppUserRoleProfiles:Profile
    {
        public AppUserRoleProfiles()
        {
            CreateMap<AppUserRole, CreateAppUserRoleDTO>().ReverseMap();
            CreateMap<AppUserRole, UpdateAppUserRoleDTO>().ReverseMap();
            CreateMap<AppUserRole, GetAppUserRoleDTO>().ReverseMap();
        }
    }
}
