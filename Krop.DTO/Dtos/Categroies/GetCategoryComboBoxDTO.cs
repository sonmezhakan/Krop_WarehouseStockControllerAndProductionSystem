namespace Krop.DTO.Dtos.Categroies
{
    public record  GetCategoryComboBoxDTO
    {
        public Guid Id{ get; init; }
        public string CategoryName{ get; init; }
    }
}
