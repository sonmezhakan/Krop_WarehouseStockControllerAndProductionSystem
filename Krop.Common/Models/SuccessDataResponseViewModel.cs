namespace Krop.Common.Models
{
    public record class SuccessDataResponseViewModel<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public bool Success { get; set; }
    }
}
