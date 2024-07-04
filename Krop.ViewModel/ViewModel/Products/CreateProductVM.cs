using Krop.DTO.Dtos.Brands;
using Krop.DTO.Dtos.Categroies;
using Krop.DTO.Dtos.Products;

namespace Krop.ViewModel.ViewModel.Products
{
    public record CreateProductVM
    {
        public List<GetCategoryDTO>? GetCategoryDTO { get; init; }
        public List<GetBrandComboBoxDTO>? GetBrandComboBoxDTO { get; init; }
        public CreateProductDTO? CreateProductDTO { get; init; }
    }
}
