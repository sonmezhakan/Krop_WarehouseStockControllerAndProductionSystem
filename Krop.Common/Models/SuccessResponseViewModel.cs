namespace Krop.Common.Models
{
    public class SuccessResponseViewModel<T>
    {
        public List<T> Data { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
