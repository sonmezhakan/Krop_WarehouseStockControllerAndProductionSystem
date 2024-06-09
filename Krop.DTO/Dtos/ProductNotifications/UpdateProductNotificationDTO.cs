namespace Krop.DTO.Dtos.ProductNotifications
{
    public record class UpdateProductNotificationDTO
    {
        public Guid Id { get; init; }
        public Guid ProductId { get; init; }
        public Guid BranchId { get; init; }
        public Guid SenderEmployeeId { get; init; }
        public Guid SentEmployeeId { get; init; }
        public string Description { get; init; }
    }
}
