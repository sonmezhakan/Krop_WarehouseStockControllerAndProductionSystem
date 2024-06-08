using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Krop.Business.Exceptions.HttpProblemDetails
{
    public class AuthorizationProblemDetails:ProblemDetails
    {
        public AuthorizationProblemDetails(string detail)
        {
            Title = "Authorization errors";
            Detail = detail;
            Status = StatusCodes.Status401Unauthorized;
        }
    }
}
