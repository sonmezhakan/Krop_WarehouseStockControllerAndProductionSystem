using Krop.Business.Features.AppUserRoles.Constants;
using Krop.Common.Utilits.Result;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Krop.Business.Features.AppUserRoles.Rules
{
    public class AppUserRoleBusinessRules
    {
        private readonly RoleManager<AppUserRole> _roleManager;

        public AppUserRoleBusinessRules(RoleManager<AppUserRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IDataResult<AppUserRole>> CheckByIdAsync(Guid id)
        {
            var result = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
                return new ErrorDataResult<AppUserRole>(StatusCodes.Status404NotFound, AppUserRoleMessages.AppUserRoleNotFound);

            return new SuccessDataResult<AppUserRole>(result);
        }
        public async Task<IDataResult<AppUserRole>> CheckByNameAsync(string name)
        {
            var result = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Name == name);
            if (result == null)
                return new ErrorDataResult<AppUserRole>(StatusCodes.Status404NotFound, AppUserRoleMessages.AppUserRoleNotFound);

            return new SuccessDataResult<AppUserRole>(result);
        }
        public async Task<IResult> AppUserRoleNameCannotBeDuplicatedWhenInserted(string roleName)
        {
            var result = await _roleManager.Roles.AnyAsync(x=>x.Name.Contains(roleName));
            if (result)
               return  new ErrorResult(StatusCodes.Status400BadRequest,AppUserRoleMessages.AppUserRoleNameExists);

            return new SuccessResult();

        }
        public async Task<IResult> AppUserRoleNameCannotBeDuplicatedWhenUpdated(string oldRoleName, string newRoleName)
        {
            if(oldRoleName != newRoleName)
            {
                bool result  = await _roleManager.Roles.AnyAsync(x=>x.Name.Contains(newRoleName));
                if (result)
                    return new ErrorResult(StatusCodes.Status400BadRequest, AppUserRoleMessages.AppUserRoleNameExists);   
            }

            return new SuccessResult();
        }
    }
}
