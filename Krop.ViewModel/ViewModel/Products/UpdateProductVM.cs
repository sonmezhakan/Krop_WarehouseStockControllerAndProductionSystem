using Krop.DTO.Dtos.Brands;
using Krop.DTO.Dtos.Categroies;
using Krop.DTO.Dtos.Products;

namespace Krop.ViewModel.ViewModel.Products
{
    public record UpdateProductVM
    {
        public List<GetProductComboBoxDTO>? GetProductComboBoxDTO { get; init; }
        public List<GetCategoryDTO>? GetCategoryDTO { get; init; }
        public List<GetBrandComboBoxDTO>? GetBrandComboBoxDTO { get; init; }
        public UpdateProductDTO? UpdateProductDTO { get; init; }
    }
}
