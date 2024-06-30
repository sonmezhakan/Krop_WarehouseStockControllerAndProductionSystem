namespace Krop.DTO.Dtos.Categroies
{
    public record  UpdateCategoryDTO
    {
        public Guid Id{ get; init; }
        public string CategoryName{ get; init; }
    }
}
