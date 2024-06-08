namespace Krop.Common.Models
{
    public record class SuccessDataResponseViewModel<T>
    {
        public T Data { get; set; }
        public string Detail { get; set; }
        public int Status { get; set; }
        public bool Success { get; set; }
    }
}
