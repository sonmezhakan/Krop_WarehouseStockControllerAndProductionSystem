namespace Krop.DTO.Dtos.StockInputs
{
    public record  GetStockInputDTO
    {
        public Guid ProductId{ get; init; }
        public Guid SupplierId{ get; init; }
        public Guid BranchId{ get; init; }
        public string InvoiceNumber{ get; init; }
        public decimal UnitPrice{ get; init; }
        public int Quantity{ get; init; }
        public string Description{ get; init; }
        public DateTime InputDate{ get; init; }
    }
}
