namespace Krop.Common.Models
{
    public record class EmailViewModel
    {
        public string subject { get; set; }
        public string? textBody { get; set; }
        public string? htmlBody { get; set; }
        public string toEmail { get; set; }
    }
}
