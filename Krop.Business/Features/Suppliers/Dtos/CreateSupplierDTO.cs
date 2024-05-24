namespace Krop.Business.Features.Suppliers.Dtos
{
    public record class CreateSupplierDTO
    {
        public string CompanyName { get; init; }
        public string? ContactName { get; init; }
        public string? ContactTitle { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Email { get; init; }
        public string? Country { get; init; }
        public string? City { get; init; }
        public string? Addres { get; init; }
        public string? WebSite { get; init; }
    }
}
