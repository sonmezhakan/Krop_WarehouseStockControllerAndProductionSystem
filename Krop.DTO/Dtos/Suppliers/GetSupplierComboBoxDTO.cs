namespace Krop.DTO.Dtos.Suppliers
{
    public record  GetSupplierComboBoxDTO
    {
        public Guid Id{ get; init; }
        public string CompanyName{ get; init; }
    }
}
