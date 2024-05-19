namespace Krop.Common.Utilits.Result
{
    public class SuccessResult : Result
    {
        public SuccessResult(bool success,int statusCode, string message) : base(true,200, message)
        {
        }
        public SuccessResult(int statusCode,string message):base(true,200)
        {
            
        }
        public SuccessResult():base(true,200)
        {
            
        }
    }
}
