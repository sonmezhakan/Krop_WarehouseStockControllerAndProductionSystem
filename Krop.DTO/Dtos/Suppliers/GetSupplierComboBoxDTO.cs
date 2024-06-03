namespace Krop.DTO.Dtos.Suppliers
{
    public record class GetSupplierComboBoxDTO
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
    }
}
