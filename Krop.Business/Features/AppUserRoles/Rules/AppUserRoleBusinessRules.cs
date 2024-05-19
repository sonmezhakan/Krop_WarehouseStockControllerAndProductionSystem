using Krop.Business.Features.AppUserRoles.ExceptionHelpers;
using Krop.Business.Features.Categories.ExceptionHelpers;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Krop.Business.Features.AppUserRoles.Rules
{
    public class AppUserRoleBusinessRules
    {
        private readonly RoleManager<AppUserRole> _roleManager;
        private readonly AppUserRoleExceptionHelper _appUserRoleExceptionHelper;

        public AppUserRoleBusinessRules(RoleManager<AppUserRole> roleManager,AppUserRoleExceptionHelper appUserRoleExceptionHelper)
        {
            _roleManager = roleManager;
            _appUserRoleExceptionHelper = appUserRoleExceptionHelper;
        }


        public async Task<AppUserRole> CheckByAppUserRoleId(Guid id)
        {
            var result = await _roleManager.Roles.FirstOrDefaultAsync(c => c.Id == id);
            if (result is null)
                _appUserRoleExceptionHelper.ThrowAppUserRoleNotFound();

            return result;
        }
        public async Task<AppUserRole> CheckByAppUserRoleName(string appUserRoleName)
        {
            var result = await _roleManager.Roles.FirstOrDefaultAsync(c => c.Name == appUserRoleName);
            if (result is null)
                _appUserRoleExceptionHelper.ThrowAppUserRoleNotFound();

            return result;
        }
        public async Task AppUserRoleNameCannotBeDuplicatedWhenInserted(string roleName)
        {
            AppUserRole appUserRole = await _roleManager.FindByNameAsync(roleName);
            if (appUserRole is null)
                _appUserRoleExceptionHelper.ThrowAppUserRoleNameExists();
        }
        public async Task AppUserRoleNameCannotBeDuplicatedWhenUpdated(string oldRoleName, string newRoleName)
        {
            if(oldRoleName != newRoleName)
            {
                AppUserRole appUserRole = await _roleManager.FindByNameAsync(newRoleName);
                if (appUserRole is null)
                    _appUserRoleExceptionHelper.ThrowAppUserRoleNameExists();
            }
        }
    }
}
