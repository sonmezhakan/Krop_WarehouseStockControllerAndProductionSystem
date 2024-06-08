namespace Krop.Common.Utilits.Result
{
    public class ErrorResult : Result
    {
        public ErrorResult(bool success,int status, string detail) : base(false, status, detail)
        {
        }
        public ErrorResult(int status,string detail) : base(false,status, detail)
        {

        }
        public ErrorResult():base(false)
        {

        }

    }
}
