﻿using AutoMapper;
using Krop.Business.Features.AppUserRoles.Constants;
using Krop.Business.Features.AppUserRoles.Rules;
using Krop.Business.Features.AppUserRoles.Validations;
using Krop.Business.Features.Brands.Constants;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Helpers.CacheHelpers;
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
        private readonly ICacheHelper _cacheHelper;

        public AppUserRoleManager(RoleManager<AppUserRole> roleManager, IMapper mapper, AppUserRoleBusinessRules appUserRoleBusinessRules, ICacheHelper cacheHelper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _appUserRoleBusinessRules = appUserRoleBusinessRules;
            _cacheHelper = cacheHelper;
        }

        #region Add      
        [ValidationAspect(typeof(CreateAppUserRoleValidator))]
        public async Task<IResult> AddAsync(CreateAppUserRoleDTO createAppUserRoleDTO)
        {
            var result = BusinessRules.Run(await _appUserRoleBusinessRules.AppUserRoleNameCannotBeDuplicatedWhenInserted(createAppUserRoleDTO.Name));
            if (!result.Success)
                return result;

            AppUserRole appUserRole = _mapper.Map<AppUserRole>(createAppUserRoleDTO);
            await _roleManager.CreateAsync(appUserRole);

            await _cacheHelper.RemoveAsync(new string[]
            {
                AppUserRoleCacheKeys.GetAllAsync,
                AppUserRoleCacheKeys.GetAllComboBoxAsync
            });
            return new SuccessResult();
        }

        #endregion
        #region Update
        [ValidationAspect(typeof(UpdateAppUserRoleValidator))]
        public async Task<IResult> UpdateAsync(UpdateAppUserRoleDTO updateAppUserRoleDTO)
        {
            var result = await _roleManager.FindByIdAsync(updateAppUserRoleDTO.Id.ToString());
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, AppUserRoleMessages.AppUserRoleNotFound);

            AppUserRole appUserRole = result;

            appUserRole = _mapper.Map(updateAppUserRoleDTO, appUserRole);
            await _roleManager.UpdateAsync(appUserRole);

            await _cacheHelper.RemoveAsync(new string[]
            {
                AppUserRoleCacheKeys.GetAllAsync,
                AppUserRoleCacheKeys.GetAllComboBoxAsync,
                $"{AppUserRoleCacheKeys.GetByIdAsync}{updateAppUserRoleDTO.Id}"
            });
            return new SuccessResult();
        }

        #endregion 
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var result = await _roleManager.FindByIdAsync(id.ToString());
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, AppUserRoleMessages.AppUserRoleNotFound);

            await _roleManager.DeleteAsync(result);

            await _cacheHelper.RemoveAsync(new string[]
            {
                AppUserRoleCacheKeys.GetAllAsync,
                AppUserRoleCacheKeys.GetAllComboBoxAsync,
                $"{AppUserRoleCacheKeys.GetByIdAsync}{id}"
            });
            return new SuccessResult();
        }

        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetAppUserRoleDTO>>> GetAllAsync()
        {
            IEnumerable<GetAppUserRoleDTO>? getAppUserRoleDTOs = await _cacheHelper.GetOrAddListAsync(
                AppUserRoleCacheKeys.GetAllAsync,
                async () =>
                {
                    var result = await _roleManager.Roles.ToListAsync();
                    return result is null ? null : _mapper.Map<IEnumerable<GetAppUserRoleDTO>>(result);
                },
                60
                );

            return new SuccessDataResult<IEnumerable<GetAppUserRoleDTO>>(getAppUserRoleDTOs);
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetAppUserRoleDTO>> GetByIdAsync(Guid id)
        {
            GetAppUserRoleDTO? getAppUserRoleDTO = await _cacheHelper.GetOrAddAsync(
                $"{AppUserRoleCacheKeys.GetByIdAsync}{id}",
                async () =>
                {
                    var result = await _roleManager.FindByIdAsync(id.ToString());
                    return result is null ? null : _mapper.Map<GetAppUserRoleDTO>(result);
                },
                60
                );

                return getAppUserRoleDTO is null ? 
                new ErrorDataResult<GetAppUserRoleDTO>(StatusCodes.Status404NotFound, AppUserRoleMessages.AppUserRoleNotFound):
                new SuccessDataResult<GetAppUserRoleDTO>(getAppUserRoleDTO);
        }

        public async Task<IDataResult<GetAppUserRoleDTO>> GetByRoleNameAsync(string roleName)
        {
            GetAppUserRoleDTO? getAppUserRoleDTO = await _cacheHelper.GetOrAddAsync(
                $"{AppUserRoleCacheKeys.GetByNameAsync}{roleName}",
                async () =>
                {
                    var result = await _roleManager.FindByNameAsync(roleName);
                    return result is null ? null : _mapper.Map<GetAppUserRoleDTO>(result);
                },
                60                
                ); 
            return getAppUserRoleDTO is null ?
                new ErrorDataResult<GetAppUserRoleDTO>(StatusCodes.Status404NotFound, AppUserRoleMessages.AppUserRoleNotFound) :
                new SuccessDataResult<GetAppUserRoleDTO>(getAppUserRoleDTO);
        }
        #endregion
    }
}
