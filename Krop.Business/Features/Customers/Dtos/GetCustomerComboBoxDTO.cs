namespace Krop.Business.Features.Customers.Dtos
{
    public record class GetCustomerComboBoxDTO
    {
        public Guid Id { get; init; }
        public string CompanyName { get; init; }
    }
}
