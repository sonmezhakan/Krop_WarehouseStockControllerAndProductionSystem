namespace Krop.Common.Models
{
    public class SuccessDataListResponseViewModel<T>
    {
        public List<T> Data { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
