namespace Krop.Common.Utilits.Result
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, bool success, int status, string detail) : base(data, false, status, detail)
        {
        }
        public ErrorDataResult(int status, string detail) :base(default,false, status, detail)
        {
            
        }
        public ErrorDataResult(T data, bool success, int Status) : base(data, false, Status)
        {
        }
        public ErrorDataResult(T data,int status) :base(data,false, status)
        {
            
        }
        public ErrorDataResult(int status) : base(default, false, status)
        {
            
        }
    }
}
