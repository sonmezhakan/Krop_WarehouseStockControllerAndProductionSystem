using AutoMapper;
using Krop.Business.Features.AppUsers.Dtos;
using Krop.Business.Features.AppUsers.ExceptionHelpers;
using Krop.Business.Features.AppUsers.Rules;
using Krop.Business.Services.AppUserRoles;
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
        private readonly AppUserExceptionHelper _appUserExceptionHelper;
        private readonly IAppUserRoleService _appUserRoleService;

        public AppUserManager(UserManager<AppUser> userManager,IMapper mapper,AppUserBusinessRules appUserBusinessRules,AppUserExceptionHelper appUserExceptionHelper,IAppUserRoleService appUserRoleService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appUserBusinessRules = appUserBusinessRules;
            _appUserExceptionHelper = appUserExceptionHelper;
            _appUserRoleService = appUserRoleService;
        }

        #region Add
        public async Task<bool> AddAsync(CreateAppUserDTO createAppUserDTO)
        {
            await _appUserBusinessRules.AppUserNameCannotBeDuplicatedWhenInserted(createAppUserDTO.UserName);//Username Rule
            await _appUserBusinessRules.AppUserEmailCannotBeDuplicatedWhenInserted(createAppUserDTO.Email);//Email Rule
            await _appUserBusinessRules.AppUserPhoneNumberCannotBeDuplicatedWhenInserted(createAppUserDTO.PhoneNumber);//PhoneNumber Rule
            await _appUserBusinessRules.AppUserNationalNumberCannotBeDuplicatedWhenInserted(createAppUserDTO.NationalNumber);//NationalNumber Rule

            AppUser appUser = _mapper.Map<AppUser>(createAppUserDTO);
            var result = await _userManager.CreateAsync(appUser);
            if (result.Succeeded)
            {
                //todo:kayıt başarılı olduğu durumda mail aktivasyon maili gönderilecek

                return true;
            }

            return false;
        }
        #endregion
        #region Update
        //Şifre güncelleme işlemi burada yapılmıyor!
        public async Task<bool> UpdateAsync(UpdateAppUserDTO updateAppUserDTO)
        {
            AppUser appUser = await _userManager.FindByIdAsync(updateAppUserDTO.Id.ToString());
            if (appUser is null)
                _appUserExceptionHelper.ThrowAppUserNotFound();

            await _appUserBusinessRules.AppUserEmailCannotBeDuplicatedWhenUpdated(appUser.Email, updateAppUserDTO.Email);//Email Rule
            await _appUserBusinessRules.AppUserPhoneNumberCannotBeDuplicatedWhenUpdated(appUser.PhoneNumber, updateAppUserDTO.PhoneNumber);//PhoneNumber Rule
            await _appUserBusinessRules.AppUserNationalNumberCannotBeDuplicatedWhenUpdated(appUser.Person.NationalNumber, updateAppUserDTO.NationalNumber);//NationalNumber Rule

            //Yetkilerin olup olmadığı kontrol ediliyor.
            updateAppUserDTO.Roles.ForEach(async r =>
            {
                await _appUserRoleService.GetByRoleNameAsync(r);
            });

            appUser = _mapper.Map<AppUser>(updateAppUserDTO);
            var resultUser = await _userManager.UpdateAsync(appUser);//Kullanıcı bilgileri güncelleniyor

            if (resultUser.Succeeded)
            {
                var currentRoles = await _userManager.GetRolesAsync(appUser);//Kullanıcıya ait yetkiler getiriliyor.
                await _userManager.RemoveFromRolesAsync(appUser, currentRoles);//Kullanıcıya ait yetkiler siliniyor
                var result = await _userManager.AddToRolesAsync(appUser, updateAppUserDTO.Roles);//Yetkileri Ekliyor

                if (result.Succeeded)
                    return true;
            }


            return false;
        }

        //Sadece şifre güncelleme işlemi yapılıyor.
        public async Task<bool> UpdatePasswordAsync(UpdateAppUserPasswordDTO updateAppUserPasswordDTO)
        {
            AppUser appUser = await _userManager.FindByIdAsync(updateAppUserPasswordDTO.Id.ToString());
            if (appUser is null)
                _appUserExceptionHelper.ThrowAppUserNotFound();

            var removeResult = await _userManager.RemovePasswordAsync(appUser);//Şifre ilk önce siliniyor.
            if (removeResult.Succeeded)
            {
                var result = await _userManager.AddPasswordAsync(appUser, updateAppUserPasswordDTO.Password);//Yeni şifre oluşturuluyor.
                if (result.Succeeded)
                    return true;
            }

            return false;
        }
        #endregion
        #region Listed
        public async Task<IEnumerable<GetAppUserDTO>> GetAllAsync()
        {
            var result = await _userManager.Users.ToListAsync();

            List<GetAppUserDTO> getAppUserDTOs = _mapper.Map<List<GetAppUserDTO>>(result);

            return getAppUserDTOs;
        }
        #endregion
        #region Search
        public async Task<GetAppUserDTO> GetByIdAsync(Guid id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id.ToString());
            if (appUser is null)
                _appUserExceptionHelper.ThrowAppUserNotFound();

            return _mapper.Map<GetAppUserDTO>(appUser);
        }

        public async Task<GetAppUserDTO> GetByUserNameAsync(string userName)
        {
            AppUser appUser = await _userManager.FindByNameAsync(userName);
            if(appUser is null)
                _appUserExceptionHelper.ThrowAppUserNotFound();

            return _mapper.Map<GetAppUserDTO>(appUser);
        }

        public async Task<bool> AnyByIdAsync(Guid id)
        {
           AppUser appUser =  await _userManager.FindByIdAsync(id.ToString());
            if (appUser is null)
                _appUserExceptionHelper.ThrowAppUserNotFound();
            return true;
        }
        #endregion


    }
}
