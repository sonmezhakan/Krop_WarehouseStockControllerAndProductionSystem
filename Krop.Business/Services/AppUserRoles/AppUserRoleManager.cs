using AutoMapper;
using Krop.Business.Features.AppUserRoles.Dtos;
using Krop.Business.Features.AppUserRoles.ExceptionHelpers;
using Krop.Business.Features.AppUserRoles.Rules;
using Krop.Business.Features.AppUserRoles.Validations;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Utilits.Result;
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

        public AppUserRoleManager(RoleManager<AppUserRole> roleManager, IMapper mapper, AppUserRoleBusinessRules appUserRoleBusinessRules)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _appUserRoleBusinessRules = appUserRoleBusinessRules;
        }

        #region Add
        [ValidationAspect(typeof(CreateAppUserRoleValidator))]
        public async Task<IResult> AddAsync(CreateAppUserRoleDTO createAppUserRoleDTO)
        {
            await _appUserRoleBusinessRules.AppUserRoleNameCannotBeDuplicatedWhenInserted(createAppUserRoleDTO.Name);//RoleName rule

            AppUserRole appUserRole = _mapper.Map<AppUserRole>(createAppUserRoleDTO);
            await _roleManager.CreateAsync(appUserRole);

            return new SuccessResult();
        }

        #endregion
        #region Update
        [ValidationAspect(typeof(UpdateAppUserRoleValidator))]
        public async Task<IResult> UpdateAsync(UpdateAppUserRoleDTO updateAppUserRoleDTO)
        {
            var appUserRole = await _appUserRoleBusinessRules.CheckByAppUserRoleId(updateAppUserRoleDTO.Id);

            appUserRole = _mapper.Map(updateAppUserRoleDTO, appUserRole);
             await _roleManager.UpdateAsync(appUserRole);

            return new SuccessResult();
        }

        #endregion 
        #region Delete
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var appUserRole = await _appUserRoleBusinessRules.CheckByAppUserRoleId(id);

            await _roleManager.DeleteAsync(appUserRole);

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
            var appUserRole = await _appUserRoleBusinessRules.CheckByAppUserRoleId(id);

            return new SuccessDataResult<GetAppUserRoleDTO>(
                _mapper.Map<GetAppUserRoleDTO>(appUserRole));
        }

        public async Task<IDataResult<GetAppUserRoleDTO>> GetByRoleNameAsync(string roleName)
        {
            var appUserRole = await _appUserRoleBusinessRules.CheckByAppUserRoleName(roleName);

            return new SuccessDataResult<GetAppUserRoleDTO>(
                _mapper.Map<GetAppUserRoleDTO>(appUserRole));
        }
        #endregion
    }
}
