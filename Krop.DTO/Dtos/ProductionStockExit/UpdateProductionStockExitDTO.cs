namespace Krop.DTO.Dtos.ProductionStockExit
{
    public record  UpdateProductionStockExitDTO
    {
        public Guid Id{ get; init; }
        public Guid ProductionId{ get; init; }
        public Guid ProductId{ get; init; }
        public int QuantityExit{ get; init; }
        public DateTime ExitDate{ get; init; }
    }
}
