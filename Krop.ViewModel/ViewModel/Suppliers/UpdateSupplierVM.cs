using Krop.DTO.Dtos.Suppliers;

namespace Krop.ViewModel.ViewModel.Suppliers
{
    public record UpdateSupplierVM
    {
        public List<GetSupplierComboBoxDTO>? GetSupplierComboBoxDTO { get; init; }
        public UpdateSupplierDTO? UpdateSupplierDTO { get; init; }
    }
}
