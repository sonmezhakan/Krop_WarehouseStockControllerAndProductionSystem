using Krop.Business.Exceptions.Types;

namespace Krop.Business.Exceptions.Handlers
{
    public abstract class ExceptionHandler
    {
        public Task HandleExceptionAsync(Exception exception) =>
            exception switch
            {
                
                BusinessException businessException => HandleException(businessException),//Hata tipi BusinessException ise HandleExceptiona parametre olarak gönder.
                NotFoundException notFoundException => HandleException(notFoundException),
                ValidationException validationException => HandleException(validationException),//Hata tipi ValidationException ise HandleExceptiona parametre olarak gönder.
                _ => HandleException(exception)//Belirtilen hata tipleri yok ise HandleExceptiona parametre olarak exception ver.
            };

        //HandleException metotunun imzaları oluşturuluyor.
        protected abstract Task HandleException(BusinessException businessException);
        protected abstract Task HandleValidationException(NotFoundException notFoundException);

        protected abstract Task HandleException(ValidationException validationException);

        protected abstract Task HandleException(Exception exception);
    }
}
