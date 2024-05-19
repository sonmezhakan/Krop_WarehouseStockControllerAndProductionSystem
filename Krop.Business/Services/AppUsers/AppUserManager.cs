using AutoMapper;
using Krop.Business.Features.AppUsers.Dtos;
using Krop.Business.Features.AppUsers.ExceptionHelpers;
using Krop.Business.Features.AppUsers.Rules;
using Krop.Business.Features.AppUsers.Validations;
using Krop.Business.Features.Branches.Validations;
using Krop.Business.Services.AppUserRoles;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Utilits.Result;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Krop.Business.Services.AppUsers
{
    public class AppUserManager:IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly AppUserBusinessRules _appUserBusinessRules;
        private readonly IAppUserRoleService _appUserRoleService;

        public AppUserManager(UserManager<AppUser> userManager,IMapper mapper,AppUserBusinessRules appUserBusinessRules,IAppUserRoleService appUserRoleService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appUserBusinessRules = appUserBusinessRules;
            _appUserRoleService = appUserRoleService;
        }

        #region Add
        [ValidationAspect(typeof(CreateBranchValidator))]
        public async Task<IResult> AddAsync(CreateAppUserDTO createAppUserDTO)
        {
            await _appUserBusinessRules.AppUserNameCannotBeDuplicatedWhenInserted(createAppUserDTO.UserName);//Username Rule
            await _appUserBusinessRules.AppUserEmailCannotBeDuplicatedWhenInserted(createAppUserDTO.Email);//Email Rule
            await _appUserBusinessRules.AppUserPhoneNumberCannotBeDuplicatedWhenInserted(createAppUserDTO.PhoneNumber);//PhoneNumber Rule
            await _appUserBusinessRules.AppUserNationalNumberCannotBeDuplicatedWhenInserted(createAppUserDTO.NationalNumber);//NationalNumber Rule

            AppUser appUser = _mapper.Map<AppUser>(createAppUserDTO);
            await _userManager.CreateAsync(appUser);

            //todo:kayıt başarılı olduğu durumda mail aktivasyon maili gönderilecek

            return new SuccessResult();
        }
        #endregion
        #region Update
        [ValidationAspect(typeof(UpdateAppUserValidator))]
        //Şifre güncelleme işlemi burada yapılmıyor!
        public async Task<IResult> UpdateAsync(UpdateAppUserDTO updateAppUserDTO)
        {
            var appUser = await _appUserBusinessRules.CheckByAppUserId(updateAppUserDTO.Id);//AppUser Rule

            await _appUserBusinessRules.AppUserEmailCannotBeDuplicatedWhenUpdated(appUser.Email, updateAppUserDTO.Email);//Email Rule
            await _appUserBusinessRules.AppUserPhoneNumberCannotBeDuplicatedWhenUpdated(appUser.PhoneNumber, updateAppUserDTO.PhoneNumber);//PhoneNumber Rule
            await _appUserBusinessRules.AppUserNationalNumberCannotBeDuplicatedWhenUpdated(appUser.Person.NationalNumber, updateAppUserDTO.NationalNumber);//NationalNumber Rule

            //Yetkilerin olup olmadığı kontrol ediliyor.
            updateAppUserDTO.Roles.ForEach(async r =>
            {
                await _appUserRoleService.GetByRoleNameAsync(r);
            });

            appUser = _mapper.Map<AppUser>(updateAppUserDTO);
            await _userManager.UpdateAsync(appUser);//Kullanıcı bilgileri güncelleniyor

            var currentRoles = await _userManager.GetRolesAsync(appUser);//Kullanıcıya ait yetkiler getiriliyor.
            await _userManager.RemoveFromRolesAsync(appUser, currentRoles);//Kullanıcıya ait yetkiler siliniyor
            var result = await _userManager.AddToRolesAsync(appUser, updateAppUserDTO.Roles);//Yetkileri Ekliyor

            return new SuccessResult();
        }

        //Sadece şifre güncelleme işlemi yapılıyor.
        [ValidationAspect(typeof(UpdatePasswordAppUserValidator))]
        public async Task<IResult> UpdatePasswordAsync(UpdateAppUserPasswordDTO updateAppUserPasswordDTO)
        {
            var appUser = await _appUserBusinessRules.CheckByAppUserId(updateAppUserPasswordDTO.Id);

            await _userManager.RemovePasswordAsync(appUser);//Şifre ilk önce siliniyor.
            await _userManager.AddPasswordAsync(appUser, updateAppUserPasswordDTO.Password);//Yeni şifre oluşturuluyor.

            return new SuccessResult();
        }
        #endregion
        #region Listed
        public async Task<IDataResult<IEnumerable<GetAppUserDTO>>> GetAllAsync()
        {
            var result = await _userManager.Users.ToListAsync();

            return new SuccessDataResult<IEnumerable<GetAppUserDTO>>(
                _mapper.Map<IEnumerable<GetAppUserDTO>>(result));
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetAppUserDTO>> GetByIdAsync(Guid id)
        {
            var appUser = await _appUserBusinessRules.CheckByAppUserId(id);

            return new SuccessDataResult<GetAppUserDTO>(
                _mapper.Map<GetAppUserDTO>(appUser));
        }

        public async Task<IDataResult<GetAppUserDTO>> GetByUserNameAsync(string userName)
        {
            var appUser = await _appUserBusinessRules.CheckByAppUserName(userName);

            return new SuccessDataResult<GetAppUserDTO>(
                _mapper.Map<GetAppUserDTO>(appUser));
        }

        public async Task<IResult> AnyByIdAsync(Guid id)
        {
            await _appUserBusinessRules.CheckByAppUserId(id);

            return new SuccessResult();
        }
        #endregion


    }
}
