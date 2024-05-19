using Krop.Business.Features.AppUsers.ExceptionHelpers;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Krop.Business.Features.AppUsers.Rules
{
    public class AppUserBusinessRules
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppUserExceptionHelper _appUserExceptionHelper;

        public async Task<AppUser> CheckByAppUserId(Guid id)
        {
            var result = await _userManager.FindByIdAsync(id.ToString());
            if (result is null)
                _appUserExceptionHelper.ThrowAppUserNotFound();

            return result;
        }
        public async Task<AppUser> CheckByAppUserName(string userName)
        {
            var result = await _userManager.FindByNameAsync(userName);
            if (result is null)
                _appUserExceptionHelper.ThrowAppUserNotFound();

            return result;
        }
        public AppUserBusinessRules(UserManager<AppUser> userManager,AppUserExceptionHelper appUserExceptionHelper)
        {
            _userManager = userManager;
            _appUserExceptionHelper = appUserExceptionHelper;
        }

        public async Task AppUserNameCannotBeDuplicatedWhenInserted(string userName)
        {
            AppUser appUser = await _userManager.FindByNameAsync(userName);
            if(appUser is null)
                _appUserExceptionHelper.ThrowAppUserNameExists();

        }
        public async Task AppUserEmailCannotBeDuplicatedWhenInserted(string email)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(email);
            if (appUser is null)
                _appUserExceptionHelper.ThrowAppUserEmailExists();
        }
        public async Task AppUserEmailCannotBeDuplicatedWhenUpdated(string oldEmail,string newEmail)
        {
            if(oldEmail != newEmail)
            {
                AppUser appUser = await _userManager.FindByEmailAsync(newEmail);
                if (appUser is null)
                    _appUserExceptionHelper.ThrowAppUserEmailExists();
            }
        }
        public async Task AppUserPhoneNumberCannotBeDuplicatedWhenInserted(string phoneNumber)
        {
            bool result = await _userManager.Users.AnyAsync(u => u.PhoneNumber == phoneNumber);

            if(result)
                _appUserExceptionHelper.ThrowAppUserPhoneNumberExists();
        }
        public async Task AppUserPhoneNumberCannotBeDuplicatedWhenUpdated(string oldPhoneNmber, string newPhoneNumber)
        {
            if(oldPhoneNmber != newPhoneNumber)
            {
                bool result = await _userManager.Users.AnyAsync(u => u.PhoneNumber == newPhoneNumber);
                if (result)
                    _appUserExceptionHelper.ThrowAppUserPhoneNumberExists();
            }
        }
        public async Task AppUserNationalNumberCannotBeDuplicatedWhenInserted(string phoneNumber)
        {
            bool result = await _userManager.Users.AnyAsync(u => u.Person.NationalNumber == phoneNumber);

            if (result)
                _appUserExceptionHelper.ThrowAppUserNationalNumberExists();
        }
        public async Task AppUserNationalNumberCannotBeDuplicatedWhenUpdated(string oldPhoneNumber, string newPhoneNumber)
        {
            if(oldPhoneNumber != newPhoneNumber)
            {
                bool result = await _userManager.Users.AnyAsync(u => u.Person.NationalNumber == newPhoneNumber);

                if (result)
                    _appUserExceptionHelper.ThrowAppUserNationalNumberExists();
            }
        }
    }
}
