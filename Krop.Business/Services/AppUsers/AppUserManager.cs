using AutoMapper;
using Krop.Business.Exceptions.Middlewares.Transaction;
using Krop.Business.Features.AppUsers.Constants;
using Krop.Business.Features.AppUsers.Rules;
using Krop.Business.Features.AppUsers.Validations;
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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Web;

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
            await _cacheHelper.RemoveAsync(new string[] { AppUserCacheKeys.AppUserGetAllComboBoxAsync });
            return new SuccessResult();
        }
        #endregion
        #region Update     
        [TransactionScope]
        [ValidationAspect(typeof(UpdateAppUserValidator))]
        //Şifre güncelleme işlemi burada yapılmıyor!
        public async Task<IResult> UpdateAsync(UpdateAppUserDTO updateAppUserDTO)
        {
            var result = await _appUserBusinessRules.CheckByIdAsync(updateAppUserDTO.Id);
            if (!result.Success)
                return result;

            AppUser appUser = result.Data;

            var resultBusinessRules = BusinessRules.Run(
                await _appUserBusinessRules.AppUserEmailCannotBeDuplicatedWhenUpdated(appUser.Email, updateAppUserDTO.Email),
                await _appUserBusinessRules.AppUserPhoneNumberCannotBeDuplicatedWhenUpdated(appUser.PhoneNumber, updateAppUserDTO.PhoneNumber),
                await _appUserBusinessRules.AppUserNationalNumberCannotBeDuplicatedWhenUpdated(appUser.Person.NationalNumber, updateAppUserDTO.NationalNumber));//BusinessRule
            if (!resultBusinessRules.Success)
                return result;

            appUser = _mapper.Map(updateAppUserDTO,appUser);
            await _userManager.UpdateAsync(appUser);//Kullanıcı bilgileri güncelleniyor

            var currentRoles = await _userManager.GetRolesAsync(appUser);//Kullanıcıya ait yetkiler getiriliyor.
            if (currentRoles.Count() > 0)
            {
                await _userManager.RemoveFromRolesAsync(appUser, currentRoles);//Kullanıcıya ait yetkiler siliniyor
            }
            if (updateAppUserDTO.Roles != null)
            {
                await _userManager.AddToRolesAsync(appUser, updateAppUserDTO.Roles);//Yetkileri Ekliyor
            }

            await _cacheHelper.RemoveAsync(new string[] { AppUserCacheKeys.AppUserGetAllComboBoxAsync });
            return new SuccessResult();
        }

        //Sadece şifre güncelleme işlemi yapılıyor.
        
        public async Task<IResult> UpdatePasswordAsync(UpdateAppUserPasswordDTO updateAppUserPasswordDTO)
        {
            var result = await _appUserBusinessRules.CheckByIdAsync(updateAppUserPasswordDTO.Id);
            if (!result.Success)
                return result;

            await _userManager.RemovePasswordAsync(result.Data);//Şifre ilk önce siliniyor.
            await _userManager.AddPasswordAsync(result.Data, updateAppUserPasswordDTO.Password);//Yeni şifre oluşturuluyor.

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
            var result = await _appUserBusinessRules.CheckByIdAsync(id);
            if (!result.Success)
                return new ErrorDataResult<GetAppUserDTO>(result.Status, result.Detail);

            return new SuccessDataResult<GetAppUserDTO>(
                _mapper.Map<GetAppUserDTO>(result.Data));
        }

        public async Task<IDataResult<GetAppUserDTO>> GetByUserNameAsync(string userName)
        {
            var result = await _appUserBusinessRules.CheckByUserNameAsync(userName);
            if (!result.Success)
                return new ErrorDataResult<GetAppUserDTO>(result.Status,result.Detail);

            return new SuccessDataResult<GetAppUserDTO>(
                _mapper.Map<GetAppUserDTO>(result.Data));
        }

        public async Task<IResult> AnyByIdAsync(Guid id)
        {
            var result = await _userManager.Users.AnyAsync(x => x.Id == id);
            if (!result)
                new ErrorResult(StatusCodes.Status404NotFound, AppUserMessages.AppUserNotFound);

            return new SuccessResult();
        }
        #endregion
        #region Activation
        public async Task<IResult> ConfirmationAsync(Guid Id, string token)
        {
            var result = await _appUserBusinessRules.CheckByIdAsync(Id);
            if (!result.Success)
                return result;

            var decodeToken = HttpUtility.UrlDecode(token);
            var resultActivation = await _userManager.ConfirmEmailAsync(result.Data, decodeToken);

            if (!resultActivation.Succeeded)
                return new ErrorResult(StatusCodes.Status400BadRequest, "Aktivasyon Başarısız!");

            return new SuccessResult("Aktivasyon Başarılı!");
        }
        public async Task<IResult> ConfirmationMailSenderAsync(Guid Id)
        {
            var result = await _appUserBusinessRules.CheckByIdAsync(Id);
            if (!result.Success)
                return result;

            await _appUserBusinessRules.CheckEmailConfirmed(result.Data);

            await ActivationMailSenderAsync(result.Data);

            return new SuccessResult();
        }
        #endregion
        #region ResetPasswordMailSender
        public async Task<IResult> ResetPasswordMailSenderAsync(Guid Id)
        {
            var result = await _appUserBusinessRules.CheckByIdAsync(Id);
            if (!result.Success)
                return result;

            string token = await _userManager.GeneratePasswordResetTokenAsync(result.Data);
            ResetPasswordMailSenderAsync(token, result.Data);
            
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
            string encodeToken = HttpUtility.UrlEncode(token);

            var request = _httpContextAccessor.HttpContext.Request;
            var actionContext = _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IActionContextAccessor>().ActionContext;
            var urlHelper = _urlHelperFactory.GetUrlHelper(actionContext);

            string confirmationUrl = urlHelper.Action("Confirmation", "Account", new { Id = appUser.Id, token = encodeToken }, request.Scheme);

            EmailViewModel emailViewModel = new EmailViewModel
            {
                toEmail = appUser.Email,
                subject = "Kullanıcı Aktivasyonu!",
                htmlBody = $@"<b><h2>{appUser.UserName} Hoşgeldin!</h2></b>
                            <br>
                            <h4>Aktivasyonu Tamamlamak İçin Aşağıdaki Linke Tıklayınız!</h4>
                            <br>
                            {confirmationUrl}"
            };

            await _emailService.SendMailAsync(emailViewModel);
        }
        private async Task ResetPasswordMailSenderAsync(string token, AppUser appUser)
        {
            string encodeToken = HttpUtility.UrlEncode(token);

            var request = _httpContextAccessor.HttpContext.Request;
            var actionContext = _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IActionContextAccessor>().ActionContext;
            var urlHelper = _urlHelperFactory.GetUrlHelper(actionContext);

            string resetPasswordUrl = urlHelper.Action("ResetPassword", "Account", new { Id = appUser.Id, token = encodeToken }, request.Scheme);

            EmailViewModel emailViewModel = new EmailViewModel
            {
                toEmail = appUser.Email,
                subject = "Şifre Sıfırlama!",
                htmlBody = $@"<b><h2>{appUser.UserName} Şifre Sıfırlama!</h2></b>
                            <br>
                            <h4>Şifreyi Sıfırlamak İçin Aşağıdaki Linke Tıklayınız!</h4>
                            <br>
                            {resetPasswordUrl}"
            };

            await _emailService.SendMailAsync(emailViewModel);
        }
    }
    #endregion
}
