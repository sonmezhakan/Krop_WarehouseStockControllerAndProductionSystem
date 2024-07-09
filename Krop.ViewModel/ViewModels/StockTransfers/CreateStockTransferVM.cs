using Krop.DTO.Dtos.Branches;
using Krop.DTO.Dtos.Products;
using Krop.DTO.Dtos.StockTransfers;

namespace Krop.ViewModel.ViewModels.StockTransfers
{
    public record CreateStockTransferVM
    {
        public List<GetBranchComboBoxDTO>? GetBranchComboBoxDTOs { get; init; }
        public List<GetProductComboBoxDTO>? GetProductComboBoxDTOs { get; init; }
        public CreateStockTransferDTO? CreateStockTransferDTO { get; init; }
    }
}
