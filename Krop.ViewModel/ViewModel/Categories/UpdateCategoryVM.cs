using Krop.DTO.Dtos.Categroies;

namespace Krop.ViewModel.ViewModel.Category
{
    public record UpdateCategoryVM
    {
        public List<GetCategoryDTO>? GetCategoryDTO { get; init; }
        public UpdateCategoryDTO? UpdateCategoryDTO { get; init; }
    }
}
