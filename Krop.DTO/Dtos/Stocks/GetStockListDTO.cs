namespace Krop.DTO.Dtos.Stocks
{
    public record  GetStockListDTO
    {
        public Guid Id{ get; init; }
        public string BranchName{ get; init; }
        public string ProductName{ get; init; }
        public string ProductCode{ get; init; }
        public int UnitsInStock{ get; init; }
        public int CriticalStock{ get; init; }
    }
}
