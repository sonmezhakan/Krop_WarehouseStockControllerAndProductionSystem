namespace Krop.Common.Utilits.Result
{
    public class DataResult<T>:Result,IDataResult<T>
    {
        public DataResult(T data, bool success,int status, string detail) : base(success, status, detail)
        {
            Data = data;
        }
        public DataResult(T data, bool success,int status) :base(success, status)
        {
            Data = data;   
        }

        public T Data { get; }
    }
}
