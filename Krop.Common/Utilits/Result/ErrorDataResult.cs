namespace Krop.Common.Utilits.Result
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, bool success, int statusCode, string message) : base(data, false, statusCode, message)
        {
        }
        public ErrorDataResult(int statusCode, string message) :base(default,false,statusCode, message)
        {
            
        }
        public ErrorDataResult(T data, bool success, int statusCode) : base(data, false, statusCode)
        {
        }
        public ErrorDataResult(T data,int statusCode) :base(data,false,statusCode)
        {
            
        }
        public ErrorDataResult(int statusCode) : base(default, false, statusCode)
        {
            
        }
    }
}
