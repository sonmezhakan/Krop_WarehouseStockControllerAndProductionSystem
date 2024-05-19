namespace Krop.Common.Utilits.Result
{
    public class Result:IResult
    {
        public Result(bool success,int statusCode, string message):this(success,statusCode)
        {
            Message = message;
        }
        public Result(bool success, int statusCode)
        {
            Success = success;
            StatusCode = statusCode;
        }

        public Result(int statusCode)
        {
            StatusCode = statusCode;
        }
        public Result(bool success)
        {
            Success= success;
        }

        public bool Success{ get; }

        public string Message { get; }
        public int StatusCode { get; }
    }
}
