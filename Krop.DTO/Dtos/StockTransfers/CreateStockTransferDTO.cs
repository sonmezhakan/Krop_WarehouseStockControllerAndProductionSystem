namespace Krop.DTO.Dtos.StockTransfers
{
    public record class CreateStockTransferDTO
    {
        public Guid SenderBranchId { get; set; }
        public Guid SentBranchId { get; set; }
        public Guid ProductId { get; set; }
        public Guid TransactorAppUserId { get; set; }
        public string? InvoiceNumber { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public DateTime TransferDate { get; set; }
    }
}
