namespace Krop.Common.Utilits.Result
{
    public interface IResult
    {
        public bool Success { get; }
        public string Detail { get; }

        public int Status { get; }
    }
}
