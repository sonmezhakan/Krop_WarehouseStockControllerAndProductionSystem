using Krop.Business.Features.AppUsers.Constants;
using Krop.Business.Features.AppUsers.Rules;
using Krop.Business.Features.Auths.Validations;
using Krop.Business.Features.Employees.Rules;
using Krop.Common.Aspects.Autofac.Validation;
using Krop.Common.Helpers.EmailService;
using Krop.Common.Helpers.JwtService;
using Krop.Common.Models;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DTO.Dtos.Auths;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Krop.Business.Services.Auths
{
    public partial class AuthManager : IAuthService
    {
        private readonly AppUserBusinessRules _appUserBusinessRules;
        private readonly UserManager<AppUser> _userManager;
        private readonly EmployeeBusinessRules _employeeBusinessRules;
        private readonly IJwtService _jwtService;
        private readonly IEmailService _emailService;

        public AuthManager(AppUserBusinessRules appUserBusinessRules, UserManager<AppUser> userManager, EmployeeBusinessRules employeeBusinessRules, IJwtService jwtService, IEmailService emailService)
        {
            _appUserBusinessRules = appUserBusinessRules;
            _userManager = userManager;
            _employeeBusinessRules = employeeBusinessRules;
            _jwtService = jwtService;
            _emailService = emailService;
        }

        [ValidationAspect(typeof(LoginValidator))]
        public async Task<IDataResult<AppUser>> LoginAsync(LoginDTO loginDTO)
        {
            var appUser = await _userManager.FindByNameAsync(loginDTO.UserName);
            if (appUser is null)
                return new ErrorDataResult<AppUser>(StatusCodes.Status404NotFound, AppUserMessages.AppUserNotFound);

            var businessRulesResult = BusinessRules.Run(
                await _appUserBusinessRules.CheckEmailConfirmed(appUser.Email),
                await _employeeBusinessRules.CheckEmployeeWorkingAsync(appUser.Id)
                );
            if (!businessRulesResult.Success)
                return new ErrorDataResult<AppUser>(businessRulesResult.Status, businessRulesResult.Detail);

            var result = await _userManager.CheckPasswordAsync(appUser, loginDTO.Password);
            if (!result)
                return new ErrorDataResult<AppUser>(StatusCodes.Status400BadRequest, AppUserMessages.AppUserLoginError);

            return new SuccessDataResult<AppUser>(appUser);
        }
        public async Task<IDataResult<LoginResponseDTO>> CreateAccessToken(AppUser user)
        {
            var claims = await _userManager.GetRolesAsync(user);
            var accessToken = await _jwtService.CreateToken(user, claims.ToList());
            return new SuccessDataResult<LoginResponseDTO>(new LoginResponseDTO
            {
                Id = user.Id,
                Token = accessToken
            });
        }

        public async Task<IResult> ResetPasswordWinFormEmailSenderAsync(string email)
        {
            
            var businessRule = BusinessRules.Run(
                await _appUserBusinessRules.CheckByEmailAsync(email),
                await _appUserBusinessRules.CheckEmailConfirmed(email));
            if (!businessRule.Success)
                return businessRule;

            var result = await _userManager.FindByEmailAsync(email);
            string token = await _userManager.GeneratePasswordResetTokenAsync(result);
           await ResetPasswordTokenMailSender(result, token);

            return new SuccessResult();
        }

        public async Task<IResult> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO)
        {
            var businessRule = BusinessRules.Run(
               await _appUserBusinessRules.CheckByEmailAsync(resetPasswordDTO.Email),
               await _appUserBusinessRules.CheckEmailConfirmed(resetPasswordDTO.Email));
            if (!businessRule.Success)
                return businessRule;

            var appUser = await _userManager.FindByEmailAsync(resetPasswordDTO.Email);

            var result =  await _userManager.ResetPasswordAsync(appUser, resetPasswordDTO.Token, resetPasswordDTO.Password);
            if (!result.Succeeded)
                return new ErrorResult(StatusCodes.Status400BadRequest,AppUserMessages.PasswordResetFailed);

            return new SuccessResult();
        }
    }

    public partial class AuthManager
    {
        private async Task ResetPasswordTokenMailSender(AppUser appUser, string token)
        {
                EmailViewModel emailViewModel = new EmailViewModel
                {
                    toEmail = appUser.Email,
                    subject = "Şifre Sıfırlama!",
                    htmlBody = $@"<b><h2>{appUser.UserName} Şifre Sıfırlama!</h2></b>
                            <br>
                            <h4>Şifreyi Sıfırlamak Kodu</h4>
                            <br>
                            {token}"
                };

                await _emailService.SendMailAsync(emailViewModel);
        }
    }
}
