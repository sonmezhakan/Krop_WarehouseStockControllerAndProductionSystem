namespace Krop.DTO.Dtos.Products
{
    public record class GetProductDTO
    {
        public Guid Id { get; init; }
        public string ProductName { get; init; }
        public string ProductCode { get; init; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public decimal UnitPrice { get; init; }
        public Guid Image { get; init; }
        public int CriticalStock { get; init; }
        public string Description { get; init; }
    }
}
