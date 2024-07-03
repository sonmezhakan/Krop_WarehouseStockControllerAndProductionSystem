using Krop.DTO.Dtos.Categroies;

namespace Krop.ViewModel.ViewModel.Category
{
    public record UpdateCategoryVM
    {
        public List<GetCategoryDTO>? GetCategoryDTO { get; set; }
        public UpdateCategoryDTO? UpdateCategoryDTO { get; init; }
    }
}
