namespace Krop.Common.Utilits.Result
{
    public class SuccessResult : Result
    {
        public SuccessResult(bool success,int status, string detail) : base(true,200, detail)
        {
        }
        public SuccessResult(int status, string detail) :base(true,status,detail)
        {
            
        }
        public SuccessResult(string detail) :base(true,200,detail)
        {
            
        }
        public SuccessResult():base(true,200)
        {
            
        }
    }
}
