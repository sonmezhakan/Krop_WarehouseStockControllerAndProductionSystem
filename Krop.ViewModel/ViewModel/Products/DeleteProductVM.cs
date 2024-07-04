using Krop.DTO.Dtos.Products;

namespace Krop.ViewModel.ViewModel.Products
{
    public record DeleteProductVM
    {
        public List<GetProductComboBoxDTO>? GetProductComboBoxDTO { get; init; }
        public Guid? Id { get; init; }
    }
}
