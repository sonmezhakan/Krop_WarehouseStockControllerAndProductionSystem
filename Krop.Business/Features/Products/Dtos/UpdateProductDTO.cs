﻿namespace Krop.Business.Features.Products.Dtos
{
    public record class UpdateProductDTO
    {
        public Guid Id { get; init; }
        public string ProductName { get; init; }
        public string ProductCode { get; init; }
        public Guid CategoryId { get; init; }
        public decimal? UnitPrice { get; init; }
        public Guid? Image { get; init; }
        public int CriticalStock { get; init; }
        public string Description { get; init; }
    }
}
