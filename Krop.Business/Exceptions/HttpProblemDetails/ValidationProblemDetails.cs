using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Krop.Business.Exceptions.HttpProblemDetails
{
    public class ValidationProblemDetails:ProblemDetails
    {
        public ValidationProblemDetails(string detail)
        {
            Title = "Validation error(s)";
            Detail = detail;
            Status = StatusCodes.Status400BadRequest;
        }
    }
}
