namespace Krop.Business.Features.Categories.Dtos
{
    public record class UpdateCategoryDTO
    {
        public Guid Id { get; init; }
        public string CategoryName { get; init; }
    }
}
