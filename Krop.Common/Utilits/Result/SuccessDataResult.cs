namespace Krop.Common.Utilits.Result
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, bool success, int statusCode, string message) : base(data, true,200, message)
        {
        }
        public SuccessDataResult(T data, bool success, int statusCode) : base(data,true, 200)
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
