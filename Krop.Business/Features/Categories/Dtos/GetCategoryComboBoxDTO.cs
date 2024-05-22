namespace Krop.Business.Features.Categories.Dtos
{
    public record GetCategoryComboBoxDTO
    {
        public Guid Id { get; init; }
        public string CategoryName { get; init; }
    }
}
