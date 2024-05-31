namespace Krop.Business.Features.StockTransfers.Dtos
{
    public record class GetStockTransferListDTO
    {
        public Guid Id { get; set; }
        public string SenderBranchName { get; set; }
        public string SentBranchName { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string InvoiceNumber { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public DateTime TransferDate { get; set; }
        public string SenderAppUserName { get; set; }
    }
}
