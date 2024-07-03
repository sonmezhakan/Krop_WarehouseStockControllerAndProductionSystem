using Krop.DTO.Dtos.Brands;

namespace Krop.ViewModel.ViewModel.Brands
{
    public record DeleteBrandVM
    {
        public List<GetBrandComboBoxDTO>? GetBrandComboBoxDTO { get; init; }
        public Guid? Id { get; init; }
    }
}
