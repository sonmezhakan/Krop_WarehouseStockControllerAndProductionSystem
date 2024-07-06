using Krop.DTO.Dtos.ProductReceipts;
using Krop.DTO.Dtos.Products;

namespace Krop.ViewModel.ViewModel.ProductReceipts
{
    public record CreateProductReceiptVM
    {
        public List<GetProductComboBoxDTO>? GetProductComboBoxDTOs { get; init; }
        public List<GetProductReceiptListDTO>? GetProductReceiptListDTOs { get; init; }
        public CreateProductReceiptDTO? CreateProductReceiptDTO { get; init; }
        public  Guid? ProduceProductId { get; init; }
        public  Guid? ProductId { get; init; }
    }
}
