using FluentValidation;
using Krop.Business.Exceptions.Extensions;
using Krop.Business.Exceptions.HttpProblemDetails;
using Krop.Business.Exceptions.Types;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Exceptions.Handlers
{
    public class HttpExceptionHandler : ExceptionHandler
    {
        private HttpResponse? _response;

        public HttpResponse Response
        {
            get => _response ?? throw new ArgumentException(nameof(_response));
            set => _response = value;
        }
        protected override Task HandleException(BusinessException businessException)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            string details = new BusinessProblemDetails(businessException.Message).AsJson();

            return Response.WriteAsync(details);
        }
        protected override Task HandleException(NotFoundException notFoundException)
        {
            Response.StatusCode = StatusCodes.Status404NotFound;
            string details = new NotFoundProblemDetails(notFoundException.Message).AsJson();

            return Response.WriteAsync(details);
        }
        protected override Task HandleException(TransactionException transactionException)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            string details = new TransactionProblemDetails(transactionException.Message).AsJson();

            return Response.WriteAsync(details);
        }

        protected override Task HandleException(Exception exception)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            string details = new BusinessProblemDetails(exception.Message).AsJson();
            return Response.WriteAsync(details);
        }

        protected override Task HandleException(ValidationException validationException)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            string details = new FluentValidationProblemDetails(validationException.Message).AsJson();

            return Response.WriteAsync(details);
        }
        protected override Task HandleException(AuthorizationException authorizationException)
        {
            Response.StatusCode = StatusCodes.Status401Unauthorized;
            string details = new FluentValidationProblemDetails(authorizationException.Message).AsJson();

            return Response.WriteAsync(details);
        }

    }
}
