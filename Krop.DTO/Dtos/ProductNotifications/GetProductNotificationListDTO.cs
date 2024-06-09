namespace Krop.DTO.Dtos.ProductNotifications
{
    public record class GetProductNotificationListDTO
    {
        public Guid Id { get; init; }
        public string ProductName { get; init; }
        public string ProductCode { get; init; }
        public int UnitsInStock { get; init; }
        public int CriticalStock { get; init; }
        public string BranchName { get; init; }
        public string Description { get; init; }
        public string SenderUserName { get; init; }
        public string SentUserName { get; init; }
        public DateTime SenderNotificationDate { get; init; }
    }
}
