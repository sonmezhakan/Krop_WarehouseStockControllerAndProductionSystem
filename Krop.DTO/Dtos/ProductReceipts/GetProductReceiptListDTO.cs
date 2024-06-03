namespace Krop.DTO.Dtos.ProductReceipts
{
    public class GetProductReceiptListDTO
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; init; }
        public string ProductCode { get; init; }
        public int Quantity { get; init; }
    }
}
