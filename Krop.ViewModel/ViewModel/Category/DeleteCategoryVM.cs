using Krop.DTO.Dtos.Categroies;

namespace Krop.ViewModel.ViewModel.Category
{
    public record DeleteCategoryVM
    {
        public List<GetCategoryDTO>? GetCategoryDTO { get; set; }
        public Guid? Id { get; init; }
    }
}
