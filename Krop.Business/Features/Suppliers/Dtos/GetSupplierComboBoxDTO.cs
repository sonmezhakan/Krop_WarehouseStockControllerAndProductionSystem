namespace Krop.Business.Features.Suppliers.Dtos
{
    public record class GetSupplierComboBoxDTO
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
    }
}
