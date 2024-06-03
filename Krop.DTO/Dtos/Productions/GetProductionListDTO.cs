namespace Krop.DTO.Dtos.Productions
{
    public record class GetProductionListDTO
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string BranchName { get; set; }
        public int ProductionQuantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
    }
}
