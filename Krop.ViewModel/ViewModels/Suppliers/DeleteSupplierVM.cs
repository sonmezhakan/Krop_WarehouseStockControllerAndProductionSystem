using Krop.DTO.Dtos.Suppliers;

namespace Krop.ViewModel.ViewModel.Suppliers
{
    public record DeleteSupplierVM
    {
        public List<GetSupplierComboBoxDTO>? GetSupplierComboBoxDTO { get; init; }
        public Guid? Id { get; init; }
    }
}
