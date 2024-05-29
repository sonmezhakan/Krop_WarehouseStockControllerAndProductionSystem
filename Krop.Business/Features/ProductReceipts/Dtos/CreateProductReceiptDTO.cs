namespace Krop.Business.Features.ProductReceipts.Dtos
{
    public record class CreateProductReceiptDTO
    {
        public Guid ProduceProductId { get; init; }
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }
    }
}
