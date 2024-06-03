namespace Krop.DTO.Dtos.ProductReceipts
{
    public class GetProductReceiptDTO
    {
        public Guid ProduceProductId { get; init; }
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }
    }
}
