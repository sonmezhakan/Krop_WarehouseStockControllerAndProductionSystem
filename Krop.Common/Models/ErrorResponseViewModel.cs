namespace Krop.Common.Models
{
    public class ErrorResponseViewModel
    {
        public string? Title { get; set; }
        public int Status { get; set; }
        public string Detail { get; set; }
        public bool Success { get; set; }
    }
}
