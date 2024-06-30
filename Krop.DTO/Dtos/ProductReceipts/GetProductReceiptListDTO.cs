namespace Krop.DTO.Dtos.ProductReceipts
{
    public record  GetProductReceiptListDTO
    {
        public Guid ProductId{ get; init; }
        public string ProductName{ get; init; }
        public string ProductCode{ get; init; }
        public int Quantity{ get; init; }
    }
}
