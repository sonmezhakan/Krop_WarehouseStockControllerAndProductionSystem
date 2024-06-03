﻿namespace Krop.DTO.Dtos.Productions
{
    public record class GetProductionDTO
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid BranchId { get; set; }
        public Guid AppUserId { get; set; }
        public int ProductionQuantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public string Description { get; set; }
    }
}
