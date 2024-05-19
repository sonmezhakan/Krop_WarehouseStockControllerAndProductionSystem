namespace Krop.Common.Utilits.Result
{
    public class ErrorResult : Result
    {
        public ErrorResult(bool success,int statusCode, string message) : base(false,statusCode, message)
        {
        }
        public ErrorResult(int statusCode,string message) : base(false,statusCode)
        {

        }
        public ErrorResult():base(false)
        {

        }

    }
}
