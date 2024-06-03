namespace Krop.DTO.Dtos.Customers
{
    public record class GetCustomerComboBoxDTO
    {
        public Guid Id { get; init; }
        public string CompanyName { get; init; }
    }
}
