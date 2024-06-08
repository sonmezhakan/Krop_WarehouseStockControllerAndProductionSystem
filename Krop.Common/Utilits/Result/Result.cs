namespace Krop.Common.Utilits.Result
{
    public class Result:IResult
    {
        public Result(bool success,int status, string detail) :this(success, status)
        {
            Detail = detail;
        }
        public Result(bool success, int status)
        {
            Success = success;
            Status = status;
        }

        public Result(int status)
        {
            Status = status;
        }
        public Result(bool success)
        {
            Success= success;
        }

        public bool Success{ get; }

        public string Detail { get; }
        public int Status { get; }
    }
}
