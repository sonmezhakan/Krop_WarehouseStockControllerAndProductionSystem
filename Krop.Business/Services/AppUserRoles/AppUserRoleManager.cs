using AutoMapper;
using Krop.Business.Features.AppUserRoles.Constants;
using Krop.Business.Features.AppUserRoles.Rules;
using Krop.Business.Features.AppUserRoles.Validations;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DTO.Dtos.AppUserRoles;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Krop.Business.Services.AppUserRoles
{
    public class AppUserRoleManager : IAppUserRoleService
    {
        private readonly RoleManager<AppUserRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly AppUserRoleBusinessRules _appUserRoleBusinessRules;

        public AppUserRoleManager(RoleManager<AppUserRole> roleManager, IMapper mapper, AppUserRoleBusinessRules appUserRoleBusinessRules)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _appUserRoleBusinessRules = appUserRoleBusinessRules;
        }

        #region Add
        
        public async Task<IResult> AddAsync(CreateAppUserRoleDTO createAppUserRoleDTO)
        {
           var result = BusinessRules.Run(await _appUserRoleBusinessRules.AppUserRoleNameCannotBeDuplicatedWhenInserted(createAppUserRoleDTO.Name));
            if (!result.Success)
                return result;

            AppUserRole appUserRole = _mapper.Map<AppUserRole>(createAppUserRoleDTO);
            await _roleManager.CreateAsync(appUserRole);

            return new SuccessResult();
        }

        #endregion
        #region Update
        public async Task<IResult> UpdateAsync(UpdateAppUserRoleDTO updateAppUserRoleDTO)
        {
            var result = await _appUserRoleBusinessRules.CheckByIdAsync(updateAppUserRoleDTO.Id);
            if (!result.Success)
                return result;

            AppUserRole appUserRole = result.Data;

            appUserRole = _mapper.Map(updateAppUserRoleDTO, appUserRole);
            await _roleManager.UpdateAsync(appUserRole);

            return new SuccessResult();
        }

        #endregion 
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var result = await _appUserRoleBusinessRules.CheckByIdAsync(id);
            if (!result.Success)
                return result;

            await _roleManager.DeleteAsync(result.Data);

            return new SuccessResult();
        }

        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetAppUserRoleDTO>>> GetAllAsync()
        {
            var result = await _roleManager.Roles.ToListAsync();

            return new SuccessDataResult<IEnumerable<GetAppUserRoleDTO>>(
                _mapper.Map<IEnumerable<GetAppUserRoleDTO>>(result));
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetAppUserRoleDTO>> GetByIdAsync(Guid id)
        {
            var result = await _appUserRoleBusinessRules.CheckByIdAsync(id);
            if (result is null)
                return new ErrorDataResult<GetAppUserRoleDTO>(StatusCodes.Status400BadRequest,AppUserRoleMessages.AppUserRoleNotFound);

            return new SuccessDataResult<GetAppUserRoleDTO>(
                _mapper.Map<GetAppUserRoleDTO>(result.Data));
        }

        public async Task<IDataResult<GetAppUserRoleDTO>> GetByRoleNameAsync(string roleName)
        {
            var appUserRole = await _appUserRoleBusinessRules.CheckByNameAsync(roleName);
            if (appUserRole is null)
                new ErrorDataResult<GetAppUserRoleDTO>(StatusCodes.Status400BadRequest);

            return new SuccessDataResult<GetAppUserRoleDTO>(
                _mapper.Map<GetAppUserRoleDTO>(appUserRole));
        }
        #endregion
    }
}
