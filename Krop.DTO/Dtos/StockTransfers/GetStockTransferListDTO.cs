namespace Krop.DTO.Dtos.StockTransfers
{
    public record  GetStockTransferListDTO
    {
        public Guid Id{ get; init; }
        public string SenderBranchName{ get; init; }
        public string SentBranchName{ get; init; }
        public string ProductName{ get; init; }
        public string ProductCode{ get; init; }
        public string InvoiceNumber{ get; init; }
        public int Quantity{ get; init; }
        public string Description{ get; init; }
        public DateTime TransferDate{ get; init; }
        public string SenderAppUserName{ get; init; }
    }
}
