namespace Krop.Common.Utilits.Result
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, bool success, int status, string detail) : base(data, true,200, detail)
        {
        }
        public SuccessDataResult(T data, bool success, int status) : base(data,true, 200)
        {
        }
        public SuccessDataResult(T data):base(data,true,200)
        {
            
        }
        public SuccessDataResult():base(default,true,200)
        {
            
        }
    }
}
