namespace Krop.DTO.Dtos.Productions
{
    public record  GetProductionListDTO
    {
        public Guid Id{ get; init; }
        public string ProductName{ get; init; }
        public string ProductCode{ get; init; }
        public string BranchName{ get; init; }
        public int ProductionQuantity{ get; init; }
        public DateTime ProductionDate{ get; init; }
        public string Description{ get; init; }
        public string UserName{ get; init; }
    }
}
