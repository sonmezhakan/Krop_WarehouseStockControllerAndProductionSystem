namespace Krop.Business.Features.Products.Dtos
{
    public record class GetProductListDTO
    {
        public Guid Id { get; init; }
        public string ProductName { get; init; }
        public string ProductCode { get; init; }
        public string CategoryName { get; init; }
        public string BrandName { get; init; }
        public decimal UnitPrice { get; init; }
        public Guid Image { get; init; }
        public int CriticalStock { get; init; }
        public string Description { get; init; }
    }
}
