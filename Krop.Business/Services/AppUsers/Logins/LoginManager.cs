using AutoMapper;
using Krop.Business.Features.AppUsers.Constants;
using Krop.Business.Features.AppUsers.Rules;
using Krop.Business.Features.Employees.Rules;
using Krop.Common.Utilits.Business;
using Krop.Common.Utilits.Result;
using Krop.DTO.Dtos.AppUsers;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Krop.Business.Services.AppUsers.Logins
{
    public class LoginManager : ILoginService
    {
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppUserBusinessRules _appUserBusinessRules;
        private readonly UserManager<AppUser> _userManager;
        private readonly EmployeeBusinessRules _employeeBusinessRules;

        public LoginManager(IMapper mapper,SignInManager<AppUser> signInManager,AppUserBusinessRules appUserBusinessRules,UserManager<AppUser> userManager,EmployeeBusinessRules employeeBusinessRules)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _appUserBusinessRules = appUserBusinessRules;
            _userManager = userManager;
            _employeeBusinessRules = employeeBusinessRules;
        }
        public async Task<IResult> LoginAsync(LoginDTO loginDTO)
        {
            var appUser = await _appUserBusinessRules.CheckByUserNameAsync(loginDTO.UserName);
            if (!appUser.Success)
                return appUser;

            var businessRulesResult = BusinessRules.Run(
                await _appUserBusinessRules.CheckEmailConfirmed(appUser.Data),
                await _employeeBusinessRules.CheckAppUserIfEmployee(appUser.Data.Id)
                );
            if(!businessRulesResult.Success) 
                return businessRulesResult;

            var result =  await _userManager.CheckPasswordAsync(appUser.Data, loginDTO.Password);
            if (!result)
                return new ErrorResult(StatusCodes.Status400BadRequest, AppUserMessages.AppUserLoginError);

            return new SuccessDataResult<Guid>(appUser.Data.Id);
        }
    }
}
