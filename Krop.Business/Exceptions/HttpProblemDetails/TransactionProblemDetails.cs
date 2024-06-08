using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Krop.Business.Exceptions.HttpProblemDetails
{
    public class TransactionProblemDetails:ProblemDetails
    {
        public TransactionProblemDetails(string detail)
        {
            Title = "Transaction error(s)";
            Detail = detail;
            Status = StatusCodes.Status400BadRequest;
        }
    }
}
