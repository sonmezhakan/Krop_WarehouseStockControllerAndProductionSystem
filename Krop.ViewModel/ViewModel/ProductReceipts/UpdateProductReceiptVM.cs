using Krop.DTO.Dtos.ProductReceipts;
using Krop.DTO.Dtos.Products;

namespace Krop.ViewModel.ViewModel.ProductReceipts
{
    public record UpdateProductReceiptVM
    {
        public List<GetProductComboBoxDTO>? GetProductComboBoxDTOs { get; init; }
        public List<GetProductReceiptListDTO>? GetProductReceiptListDTOs { get; init; }
        public UpdateProductReceiptDTO? UpdateProductReceiptDTO { get; init; }
        public Guid? ProduceProductId { get; init; }
    }
}
