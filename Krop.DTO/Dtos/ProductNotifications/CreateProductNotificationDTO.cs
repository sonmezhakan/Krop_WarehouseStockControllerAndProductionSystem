namespace Krop.DTO.Dtos.ProductNotifications
{
    public record  CreateProductNotificationDTO
    {
        public Guid ProductId{ get; init; }
        public Guid BranchId{ get; init; }
        public Guid SenderAppUserId{ get; init; }
        public Guid SentAppUserId{ get; init; }
        public string Description{ get; init; }
    }
}
