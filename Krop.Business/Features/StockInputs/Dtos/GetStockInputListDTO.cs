namespace Krop.Business.Features.StockInputs.Dtos
{
    public record class GetStockInputListDTO
    {
        public Guid Id { get; init; }
        public string BranchName { get; init; }
        public string ProductName { get; init; }
        public string ProductCode { get; set; }
        public string CompanyName { get; init; }
        public string InvoiceNumber { get; init; }
        public decimal UnitPrice { get; init; }
        public int Quantity { get; init; }
        public string Description { get; init; }
        public DateTime InputDate { get; init; }
        public string UserName { get; init; }
    }
}
