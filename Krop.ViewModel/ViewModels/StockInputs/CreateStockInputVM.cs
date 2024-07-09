using Krop.DTO.Dtos.Branches;
using Krop.DTO.Dtos.Products;
using Krop.DTO.Dtos.StockInputs;
using Krop.DTO.Dtos.Suppliers;

namespace Krop.ViewModel.ViewModels.StockInputs
{
    public record CreateStockInputVM
    {
        public List<GetBranchComboBoxDTO>? GetBranchComboBoxDTOs { get; init; }
        public List<GetProductComboBoxDTO>? GetProductComboBoxDTOs { get; init; }
        public List<GetSupplierComboBoxDTO>? GetSupplierComboBoxDTOs { get; init; }
        public CreateStockInputDTO? CreateStockInputDTO { get; init; }
        public Guid? ProductId { get; init; }
    }
}
