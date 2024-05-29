namespace Krop.Business.Features.ProductReceipts.Dtos
{
    public class GetProductReceiptListDTO
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; init; }
        public string ProductCode { get; init; }
        public int Quantity { get; init; }
    }
}
