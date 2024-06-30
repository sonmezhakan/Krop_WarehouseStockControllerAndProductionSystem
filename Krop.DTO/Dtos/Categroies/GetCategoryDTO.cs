namespace Krop.DTO.Dtos.Categroies
{
    public record  GetCategoryDTO
    {
        public Guid Id{ get; init; }
        public string CategoryName{ get; init; }
    }
}
