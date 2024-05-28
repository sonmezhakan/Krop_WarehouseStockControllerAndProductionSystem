using AutoMapper;
using Krop.Business.Features.AppUsers.Dtos;
using Krop.Business.Features.AppUsers.Rules;
using Krop.Business.Features.AppUsers.Validations;
using Krop.Business.Services.AppUserRoles;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Helpers.EmailService;
using Krop.Common.Models;
using Krop.Common.Utilits.Result;
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
    public class AppUserManager:IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly AppUserBusinessRules _appUserBusinessRules;
        private readonly IAppUserRoleService _appUserRoleService;
        private readonly IEmailService _emailService;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppUserManager(UserManager<AppUser> userManager,IMapper mapper,AppUserBusinessRules appUserBusinessRules,IAppUserRoleService appUserRoleService,IEmailService emailService,
            IUrlHelperFactory urlHelperFactory, IHttpContextAccessor httpContextAccessor )
        {
            _userManager = userManager;
            _mapper = mapper;
            _appUserBusinessRules = appUserBusinessRules;
            _appUserRoleService = appUserRoleService;
            _emailService = emailService;
            _urlHelperFactory = urlHelperFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        #region Add
        [ValidationAspect(typeof(CreateAppUserValidator))]
        public async Task<IResult> AddAsync(CreateAppUserDTO createAppUserDTO)
        {
            await _appUserBusinessRules.AppUserNameCannotBeDuplicatedWhenInserted(createAppUserDTO.UserName);//Username Rule
            await _appUserBusinessRules.AppUserEmailCannotBeDuplicatedWhenInserted(createAppUserDTO.Email);//Email Rule
            await _appUserBusinessRules.AppUserPhoneNumberCannotBeDuplicatedWhenInserted(createAppUserDTO.PhoneNumber);//PhoneNumber Rule
            await _appUserBusinessRules.AppUserNationalNumberCannotBeDuplicatedWhenInserted(createAppUserDTO.NationalNumber);//NationalNumber Rule

            AppUser appUser = _mapper.Map<AppUser>(createAppUserDTO);
            await _userManager.CreateAsync(appUser);

            await ActivationMailSender(appUser);

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

        private async Task ActivationMailSender(AppUser appUser)
        {
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            string encodeToken = HttpUtility.UrlEncode(token);

            var request = _httpContextAccessor.HttpContext.Request;
            var actionContext = _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IActionContextAccessor>().ActionContext;
            var urlHelper = _urlHelperFactory.GetUrlHelper(actionContext);

            string confirmationUrl = urlHelper.Action("Confirmation","Account", new {Id = appUser.Id, token = encodeToken}, request.Scheme);

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

        public async Task<IResult> ConfirmationAsync(Guid Id, string token)
        {

            AppUser appUser = await _appUserBusinessRules.CheckByAppUserId(Id);

            var decodeToken = HttpUtility.UrlDecode(token);
            var result = await _userManager.ConfirmEmailAsync(appUser, decodeToken);

            if (!result.Succeeded)
                return new ErrorResult(400,"Aktivasyon Başarısız!");

            return new SuccessResult(200,"Kayıt Başarılı!");
        }

        public async Task<IDataResult<IEnumerable<GetAppUserComboBoxDTO>>> GetAllComboBoxAsync()
        {
            IEnumerable<AppUser> appUsers = await _userManager.Users.Select(x => new AppUser
            {
                Id = x.Id,
                UserName = x.UserName
            }).ToListAsync();

            return new SuccessDataResult<IEnumerable<GetAppUserComboBoxDTO>>(
                _mapper.Map<IEnumerable<GetAppUserComboBoxDTO>>(appUsers));
        }

        public async Task<IResult> ConfirmationMailSenderAsync(Guid Id)
        {
            AppUser appUser = await _appUserBusinessRules.CheckByAppUserId(Id);

            await _appUserBusinessRules.CheckEmailConfirmed(appUser);

            await ActivationMailSender(appUser);

            return new SuccessResult();
        }

        public async Task<IResult> ResetPasswordMailSenderAsync(Guid Id)
        {
            AppUser appUser = await _appUserBusinessRules.CheckByAppUserId(Id);

            string token = await _userManager.GeneratePasswordResetTokenAsync(appUser);

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

            return new SuccessResult();
        }
    }
}
