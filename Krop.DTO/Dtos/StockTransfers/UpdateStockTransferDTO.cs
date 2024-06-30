namespace Krop.DTO.Dtos.StockTransfers
{
    public record  UpdateStockTransferDTO
    {
        public Guid Id{ get; init; }
        public Guid SenderBranchId{ get; init; }
        public Guid SentBranchId{ get; init; }
        public Guid ProductId{ get; init; }
        public Guid TransactorAppUserId{ get; init; }
        public string? InvoiceNumber{ get; init; }
        public int Quantity{ get; init; }
        public string? Description{ get; init; }
        public DateTime TransferDate{ get; init; }
    }
}
