namespace Krop.Common.Utilits.Result
{
    public interface IResult
    {
        public bool Success { get; }
        public string Message { get; }

        public int StatusCode { get; }
    }
}
