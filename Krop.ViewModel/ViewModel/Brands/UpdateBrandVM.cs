using Krop.DTO.Dtos.Brands;

namespace Krop.ViewModel.ViewModel.Brands
{
    public record UpdateBrandVM
    {
        public List<GetBrandComboBoxDTO>? GetBrandComboBoxDTO { get; init; }
        public UpdateBrandDTO? UpdateBrandDTO { get; init; }
    }
}
