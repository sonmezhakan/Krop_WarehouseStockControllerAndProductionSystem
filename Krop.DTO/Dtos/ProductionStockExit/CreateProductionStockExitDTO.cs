namespace Krop.DTO.Dtos.ProductionStockExit
{
    public record  CreateProductionStockExitDTO
    {
        public Guid ProductionId{ get; init; }
        public Guid ProductId{ get; init; }
        public int QuantityExit{ get; init; }
        public DateTime ExitDate{ get; init; }
    }
}
