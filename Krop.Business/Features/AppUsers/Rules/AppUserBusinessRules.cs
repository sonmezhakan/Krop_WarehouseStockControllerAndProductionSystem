﻿using Krop.Business.Features.AppUsers.Constants;
using Krop.Common.Utilits.Result;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Krop.Business.Features.AppUsers.Rules
{
    public class AppUserBusinessRules
    {
        private readonly UserManager<AppUser> _userManager;
        public AppUserBusinessRules(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IResult> CheckByEmailAsync(string email)
        {
            var result = await _userManager.Users.AnyAsync(x => x.Email == email);
            if (!result)
                return new ErrorResult(StatusCodes.Status404NotFound, AppUserMessages.AppUserNotFound);

            return new SuccessResult();
        }
        public async Task<IResult> CheckEmailConfirmed(string email)
        {
            bool result = await _userManager.Users.AnyAsync(x => x.Email == email && x.EmailConfirmed == true);

            if (!result)
                return new ErrorResult(StatusCodes.Status400BadRequest, AppUserMessages.AppUserEmailNotConfirm);

            return new SuccessResult(AppUserMessages.EmailConfirmed);
        }
        public async Task<IResult> AppUserNameCannotBeDuplicatedWhenInserted(string userName)
        {
            bool result = await _userManager.Users.AnyAsync(x => x.UserName == userName);
            if (result)
                return new ErrorResult(StatusCodes.Status400BadRequest, AppUserMessages.AppUserNameExists);

            return new SuccessResult();
        }
        public async Task<IResult> AppUserEmailCannotBeDuplicatedWhenInserted(string email)
        {
            bool result = await _userManager.Users.AnyAsync(x => x.Email == email);
            if (result)
                return new ErrorResult(StatusCodes.Status400BadRequest, AppUserMessages.AppUserEmailExists);

            return new SuccessResult();
        }
        public async Task<IResult> AppUserEmailCannotBeDuplicatedWhenUpdated(string oldEmail, string newEmail)
        {
            if (oldEmail != newEmail)
            {
                bool result = await _userManager.Users.AnyAsync(x => x.Email == newEmail);
                if (result)
                    return new ErrorResult(StatusCodes.Status400BadRequest, AppUserMessages.AppUserEmailExists);
            }
            return new SuccessResult();
        }
        public async Task<IResult> AppUserPhoneNumberCannotBeDuplicatedWhenInserted(string phoneNumber)
        {
            bool result = await _userManager.Users.AnyAsync(u => u.PhoneNumber == phoneNumber);
            if (result)
                return new ErrorResult(StatusCodes.Status400BadRequest, AppUserMessages.AppUserPhoneNumberExists);

            return new SuccessResult();
        }
        public async Task<IResult> AppUserPhoneNumberCannotBeDuplicatedWhenUpdated(string oldPhoneNmber, string newPhoneNumber)
        {
            if (oldPhoneNmber != newPhoneNumber)
            {
                bool result = await _userManager.Users.AnyAsync(u => u.PhoneNumber == newPhoneNumber);
                if (result)
                    return new ErrorResult(StatusCodes.Status400BadRequest, AppUserMessages.AppUserPhoneNumberExists);
            }
            return new SuccessResult();
        }
        public async Task<IResult> AppUserNationalNumberCannotBeDuplicatedWhenInserted(string nationalNumber)
        {
            if (string.IsNullOrWhiteSpace(nationalNumber))
                return new SuccessResult();

            bool result = await _userManager.Users.AnyAsync(u => u.Person.NationalNumber == nationalNumber);

            if (result)
                return new ErrorResult(StatusCodes.Status400BadRequest, AppUserMessages.AppUserNationalNumberExists);

            return new SuccessResult();
        }
        public async Task<IResult> AppUserNationalNumberCannotBeDuplicatedWhenUpdated(string oldNationalNumber, string newNationalNumber)
        {
            if (string.IsNullOrWhiteSpace(newNationalNumber))
                return new SuccessResult();

            if (oldNationalNumber != newNationalNumber)
            {
                bool result = await _userManager.Users.AnyAsync(u => u.Person.NationalNumber == newNationalNumber);

                if (result)
                    return new ErrorResult(StatusCodes.Status400BadRequest, AppUserMessages.AppUserNationalNumberExists);
            }
            return new SuccessResult();
        }
    }
}
