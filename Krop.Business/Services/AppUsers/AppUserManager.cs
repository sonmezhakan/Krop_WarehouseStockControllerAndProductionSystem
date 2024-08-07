﻿using AutoMapper;
using Krop.Business.Exceptions.Middlewares.Transaction;
using Krop.Business.Features.AppUsers.Constants;
using Krop.Business.Features.AppUsers.Rules;
using Krop.Business.Features.AppUsers.Validations;
using Krop.Business.Features.Employees.Constants;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Helpers.CacheHelpers;
using Krop.Common.Helpers.EmailService;
using Krop.Common.Models;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DTO.Dtos.AppUsers;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace Krop.Business.Services.AppUsers
{
    public partial class AppUserManager:IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly AppUserBusinessRules _appUserBusinessRules;
        private readonly IEmailService _emailService;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICacheHelper _cacheHelper;

        public AppUserManager(UserManager<AppUser> userManager,IMapper mapper,AppUserBusinessRules appUserBusinessRules,IEmailService emailService,
            IUrlHelperFactory urlHelperFactory, IHttpContextAccessor httpContextAccessor,ICacheHelper cacheHelper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appUserBusinessRules = appUserBusinessRules;
            _emailService = emailService;
            _urlHelperFactory = urlHelperFactory;
            _httpContextAccessor = httpContextAccessor;
            _cacheHelper = cacheHelper;
        }

        #region Add  
        [TransactionScope]
        [ValidationAspect(typeof(CreateAppUserValidator))]
        public async Task<IResult> AddAsync(CreateAppUserDTO createAppUserDTO)
        {
            var result = BusinessRules.Run(
                await _appUserBusinessRules.AppUserNameCannotBeDuplicatedWhenInserted(createAppUserDTO.UserName), 
                await _appUserBusinessRules.AppUserEmailCannotBeDuplicatedWhenInserted(createAppUserDTO.Email),
                 await _appUserBusinessRules.AppUserPhoneNumberCannotBeDuplicatedWhenInserted(createAppUserDTO.PhoneNumber),
                 await _appUserBusinessRules.AppUserNationalNumberCannotBeDuplicatedWhenInserted(createAppUserDTO.NationalNumber));
            if(!result.Success)
                return result;


            AppUser appUser = _mapper.Map<AppUser>(createAppUserDTO);
            await _userManager.CreateAsync(appUser,createAppUserDTO.Password);

            await ActivationMailSenderAsync(appUser);
            await _cacheHelper.RemoveAsync(new string[] 
            { 
                AppUserCacheKeys.AppUserGetAllComboBoxAsync,
                EmployeeCacheKeys.GetAllAsync,
                EmployeeCacheKeys.GetAllComboBoxAsync
            });
            return new SuccessResult();
        }
        #endregion
        #region Update     
        [TransactionScope]
        [ValidationAspect(typeof(UpdateAppUserValidator))]
        //Şifre güncelleme işlemi burada yapılmıyor!
        public async Task<IResult> UpdateAsync(UpdateAppUserDTO updateAppUserDTO)
        {
            var appUser = await _userManager.FindByIdAsync(updateAppUserDTO.Id.ToString());
            if (appUser is null)
                return new ErrorResult(StatusCodes.Status404NotFound,AppUserMessages.AppUserNotFound);
 
            var resultBusinessRules = BusinessRules.Run(
                await _appUserBusinessRules.AppUserEmailCannotBeDuplicatedWhenUpdated(appUser.Email, updateAppUserDTO.Email),
                await _appUserBusinessRules.AppUserPhoneNumberCannotBeDuplicatedWhenUpdated(appUser.PhoneNumber, updateAppUserDTO.PhoneNumber),
                await _appUserBusinessRules.AppUserNationalNumberCannotBeDuplicatedWhenUpdated(appUser.Person.NationalNumber, updateAppUserDTO.NationalNumber));//BusinessRule
            if (!resultBusinessRules.Success)
                return resultBusinessRules;

            appUser = _mapper.Map(updateAppUserDTO,appUser);
            await _userManager.UpdateAsync(appUser);//Kullanıcı bilgileri güncelleniyor

            var currentRoles = await _userManager.GetRolesAsync(appUser);//Kullanıcıya ait yetkiler getiriliyor.
            if (currentRoles.Count() > 0)
                await _userManager.RemoveFromRolesAsync(appUser, currentRoles);//Kullanıcıya ait yetkiler siliniyor
            if (updateAppUserDTO.Roles != null)
                await _userManager.AddToRolesAsync(appUser, updateAppUserDTO.Roles);//Yetkileri Ekliyor


            await _cacheHelper.RemoveAsync(new string[]
            {
                AppUserCacheKeys.AppUserGetAllComboBoxAsync,
                EmployeeCacheKeys.GetAllAsync,
                EmployeeCacheKeys.GetAllComboBoxAsync,
               $"{EmployeeCacheKeys.GetByIdAsync}{updateAppUserDTO.Id}",
               $"{EmployeeCacheKeys.GetByIdCartAsync}{updateAppUserDTO.Id}"
            });
            return new SuccessResult();
        }

        //Sadece şifre güncelleme işlemi yapılıyor.
        [ValidationAspect(typeof(UpdatePasswordAppUserValidator))]
        public async Task<IResult> UpdatePasswordAsync(UpdateAppUserPasswordDTO updateAppUserPasswordDTO)
        {
            var result = await _userManager.FindByIdAsync(updateAppUserPasswordDTO.Id.ToString());
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, AppUserMessages.AppUserNotFound);

            await _userManager.RemovePasswordAsync(result);//Şifre ilk önce siliniyor.
            await _userManager.AddPasswordAsync(result, updateAppUserPasswordDTO.Password);//Yeni şifre oluşturuluyor.

            return new SuccessResult();
        }
        [ValidationAspect(typeof(UpdateAppUserRoleValidatior))]
        public async Task<IResult> UpdateAppUserRoleAsync(UpdateAppUserUpdateRoleDTO updateAppUserUpdateRoleDTO)
        {
            var appUser = await _userManager.FindByIdAsync(updateAppUserUpdateRoleDTO.AppUserId.ToString());
            if (appUser is null)
                return new ErrorResult(StatusCodes.Status404NotFound, AppUserMessages.AppUserNotFound);
            var currentRoles = await _userManager.GetRolesAsync(appUser);
            if (currentRoles.Count() > 0)
                await _userManager.RemoveFromRolesAsync(appUser, currentRoles);
            if (updateAppUserUpdateRoleDTO.Roles.Count() > 0)
                await _userManager.AddToRolesAsync(appUser, updateAppUserUpdateRoleDTO.Roles);

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
        public async Task<IDataResult<IEnumerable<GetAppUserComboBoxDTO>>> GetAllComboBoxAsync()
        {
            IEnumerable<GetAppUserComboBoxDTO> getAppUserComboBoxDTOs = await _cacheHelper.GetOrAddListAsync(
                AppUserCacheKeys.AppUserGetAllComboBoxAsync,
                async () =>
                {
                    var result = await _userManager.Users.Select(x => new AppUser
                    {
                        Id = x.Id,
                        UserName = x.UserName
                    }).ToListAsync();
                    return _mapper.Map<IEnumerable<GetAppUserComboBoxDTO>>(result);
                },
                60
                );
            return new SuccessDataResult<IEnumerable<GetAppUserComboBoxDTO>>(getAppUserComboBoxDTOs);
        }
        #endregion
        #region Search
        public async Task<IDataResult<GetAppUserDTO>> GetByIdAsync(Guid id)
        {
            var result = await _userManager.FindByIdAsync(id.ToString());
            if (result is null)
                return new ErrorDataResult<GetAppUserDTO>(StatusCodes.Status404NotFound, AppUserMessages.AppUserNotFound);

            var getDto = _mapper.Map<GetAppUserDTO>(result);
            getDto.Roles = (List<string>)await _userManager.GetRolesAsync(result);
            return new SuccessDataResult<GetAppUserDTO>(getDto);
        }

        public async Task<IDataResult<GetAppUserDTO>> GetByUserNameAsync(string userName)
        {
            var result = await _userManager.FindByNameAsync(userName);
            if (result is null)
                return new ErrorDataResult<GetAppUserDTO>(StatusCodes.Status404NotFound, AppUserMessages.AppUserNotFound);

            return new SuccessDataResult<GetAppUserDTO>(
                _mapper.Map<GetAppUserDTO>(result));
        }

        public async Task<IResult> AnyByIdAsync(Guid id)
        {
            var result = await _userManager.Users.AnyAsync(x => x.Id == id);
            return result ?
                new ErrorResult(StatusCodes.Status404NotFound, AppUserMessages.AppUserNotFound):
                new SuccessResult();
        }
        #endregion
        #region Activation
        
        public async Task<IResult> ConfirmationMailSenderAsync(Guid Id)
        {
            var result = await _userManager.FindByIdAsync(Id.ToString());
            if (result is null)
                return new ErrorResult(StatusCodes.Status404NotFound, AppUserMessages.AppUserNotFound);

            var businessRule = BusinessRules.Run(await _appUserBusinessRules.CheckEmailConfirmed(result.Email));
            if (businessRule.Success)
                return new ErrorResult(StatusCodes.Status400BadRequest, AppUserMessages.EmailConfirmed);

            await ActivationMailSenderAsync(result);

            return new SuccessResult();
        }
        #endregion
    }

    #region Custom Metot
    public partial class AppUserManager
    {
        private async Task ActivationMailSenderAsync(AppUser appUser)
        {
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            string encodeToken = Uri.EscapeDataString(token);

            string url = $"https://localhost:7037/auth/Aktivasyon/{appUser.Id}/{encodeToken}";

            EmailViewModel emailViewModel = new EmailViewModel
            {
                toEmail = appUser.Email,
                subject = "Kullanıcı Aktivasyonu!",
                htmlBody = $@"<b><h2>{appUser.UserName} Hoşgeldin!</h2></b>
                            <br>
                            <h4>Aktivasyonu Tamamlamak İçin Aşağıdaki Linke Tıklayınız!</h4>
                            <br>
                            {url}"
            };

            await _emailService.SendMailAsync(emailViewModel);
        }
    }
    #endregion
}
