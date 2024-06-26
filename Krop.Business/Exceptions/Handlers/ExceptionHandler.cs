﻿using FluentValidation;
using Krop.Business.Exceptions.Types;


namespace Krop.Business.Exceptions.Handlers
{
    public abstract class ExceptionHandler
    {
        public Task HandleExceptionAsync(Exception exception) =>
            exception switch
            {
                
                AuthorizationException authorizationException => HandleException(authorizationException),
                BusinessException businessException => HandleException(businessException),//Hata tipi BusinessException ise HandleExceptiona parametre olarak gönder.
                NotFoundException notFoundException => HandleException(notFoundException),
                TransactionException transactionException => HandleException(transactionException),
                ValidationException ValidationException => HandleException(ValidationException),//Hata tipi ValidationException(FluentValidation) ise HandleExceptiona parametre olarak gönder.
                _ => HandleException(exception)//Belirtilen hata tipleri yok ise HandleExceptiona parametre olarak exception ver.
            };

        //HandleException metotunun imzaları oluşturuluyor.
        protected abstract Task HandleException(BusinessException businessException);
        protected abstract Task HandleException(NotFoundException notFoundException);

        protected abstract Task HandleException(ValidationException validationException);//ValidationException(FluentValidation)
        protected abstract Task HandleException(TransactionException transactionException);
        protected abstract Task HandleException(Exception exception);
        protected abstract Task HandleException(AuthorizationException authorizationException);
    }
}
