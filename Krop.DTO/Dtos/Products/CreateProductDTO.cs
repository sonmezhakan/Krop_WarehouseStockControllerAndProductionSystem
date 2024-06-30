namespace Krop.DTO.Dtos.Products
{
    public record  CreateProductDTO
    {
        public string ProductName{ get; init; }
        public string ProductCode{ get; init; }
        public Guid CategoryId{ get; init; }
        public Guid BrandId{ get; init; }
        public decimal? UnitPrice{ get; init; }
        public Guid? Image{ get; init; }
        public int? CriticalStock{ get; init; }
        public string? Description{ get; init; }
    }
}
