namespace Krop.DTO.Dtos.Categroies
{
    public record class UpdateCategoryDTO
    {
        public Guid Id { get; init; }
        public string CategoryName { get; init; }
    }
}
