using Krop.DTO.Dtos.Branches;
using Krop.DTO.Dtos.Productions;
using Krop.DTO.Dtos.ProductReceipts;
using Krop.DTO.Dtos.Products;

namespace Krop.ViewModel.ViewModels.Productions
{
    public record CreateProductionVM
    {
        public List<GetProductComboBoxDTO>? GetProductComboBoxDTOs { get; init; }
        public List<GetBranchComboBoxDTO>? GetBranchComboBoxDTOs { get; init; }
        public List<GetProductReceiptListDTO>? GetProductReceiptListDTOs { get; init; }
        public CreateProductionDTO? CreateProductionDTO { get; init; }
        public Guid? ProduceProductId { get; init; }
    }
}
