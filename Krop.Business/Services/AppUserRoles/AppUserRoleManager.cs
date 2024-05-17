using AutoMapper;
using Krop.Business.Features.AppUserRoles.Dtos;
using Krop.Business.Features.AppUserRoles.ExceptionHelpers;
using Krop.Business.Features.AppUserRoles.Rules;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Krop.Business.Services.AppUserRoles
{
    public class AppUserRoleManager : IAppUserRoleService
    {
        private readonly RoleManager<AppUserRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly AppUserRoleBusinessRules _appUserRoleBusinessRules;
        private readonly AppUserRoleExceptionHelper _appUserRoleExceptionHelper;

        public AppUserRoleManager(RoleManager<AppUserRole> roleManager, IMapper mapper, AppUserRoleBusinessRules appUserRoleBusinessRules, AppUserRoleExceptionHelper appUserRoleExceptionHelper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _appUserRoleBusinessRules = appUserRoleBusinessRules;
            _appUserRoleExceptionHelper = appUserRoleExceptionHelper;
        }

        #region Add
        public async Task<bool> AddAsync(CreateAppUserRoleDTO createAppUserRoleDTO)
        {
            await _appUserRoleBusinessRules.AppUserRoleNameCannotBeDuplicatedWhenInserted(createAppUserRoleDTO.RoleName);//RoleName rule

            AppUserRole appUserRole = _mapper.Map<AppUserRole>(createAppUserRoleDTO);

            var result = await _roleManager.CreateAsync(appUserRole);

            if (result.Succeeded)
                return true;

            return false;
        }

        #endregion
        #region Update
        public async Task<bool> UpdateAsync(UpdateAppUserRoleDTO updateAppUserRoleDTO)
        {
            AppUserRole appUserRole = await _roleManager.FindByIdAsync(updateAppUserRoleDTO.Id.ToString());
            if(appUserRole is null)
                _appUserRoleExceptionHelper.ThrowAppUserRoleNotFound();

            appUserRole = _mapper.Map(updateAppUserRoleDTO, appUserRole);

            var result = await _roleManager.UpdateAsync(appUserRole);

            if (result.Succeeded)
                return true;

            return false;
        }

        #endregion 
        #region Delete
        public async Task<bool> DeleteAsync(Guid id)
        {
            AppUserRole appUserRole = await _roleManager.FindByIdAsync(id.ToString());
            if (appUserRole is null)
                _appUserRoleExceptionHelper.ThrowAppUserRoleNotFound();

            var result = await _roleManager.DeleteAsync(appUserRole);

            if (result.Succeeded)
                return true;

            return false;
        }

        public Task<bool> DeleteRangeAsync(List<Guid> ids)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Listed
        public async Task<IEnumerable<GetAppUserRoleDTO>> GetAllAsync()
        {
            var result = await _roleManager.Roles.ToListAsync();

            return _mapper.Map<List<GetAppUserRoleDTO>>(result);
        }
        #endregion
        #region Search
        public async Task<GetAppUserRoleDTO> GetByIdAsync(Guid id)
        {
            AppUserRole appUserRole = await _roleManager.FindByIdAsync(id.ToString());
            if (appUserRole is null)
                _appUserRoleExceptionHelper.ThrowAppUserRoleNotFound();

            return _mapper.Map<GetAppUserRoleDTO>(appUserRole);
        }

        public async Task<bool> GetByRoleNameAsync(string roleName)
        {
            AppUserRole appUserRole = await _roleManager.FindByNameAsync(roleName);

            if (appUserRole is null)
                _appUserRoleExceptionHelper.ThrowAppUserRoleNotFound();

            return true;
        }
        #endregion
    }
}
