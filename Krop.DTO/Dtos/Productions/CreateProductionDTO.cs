namespace Krop.DTO.Dtos.Productions
{
    public record  CreateProductionDTO
    {
        public Guid ProductId{ get; init; }
        public Guid BranchId{ get; init; }
        public Guid AppUserId{ get; init; }
        public int ProductionQuantity{ get; init; }
        public DateTime ProductionDate{ get; init; }
        public string? Description{ get; init; }
    }
}
