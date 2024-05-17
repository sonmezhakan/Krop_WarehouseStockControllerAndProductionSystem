using Krop.Entities.Enums;

namespace Krop.Business.Features.Customers.Dtos
{
    public record class GetCustomerDTO
    {
        public Guid Id { get; init; }
        public string CompanyName { get; init; }
        public string? ContactName { get; init; }
        public string? ContactTitle { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Email { get; init; }
        public string? Country { get; init; }
        public string? City { get; init; }
        public string? Address { get; init; }
        public InvoiceEnum Invoice { get; init; }
    }
}
